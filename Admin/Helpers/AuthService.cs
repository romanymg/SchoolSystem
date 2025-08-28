using Blazored.LocalStorage;
using Common.Helpers;
using Common.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Admin.Helpers
{
    public static class ServiceProviderExtensions
    {
        public static T Get<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T).BaseType);
    }
    public class AuthService : AuthenticationStateProvider
    {
        private readonly string USER_SESSION_OBJECT_KEY;
        private readonly ILocalStorageService session;
        private readonly NavigationManager nav;
        private readonly ICurrentRequest _currentRequest;

        private AdminEntity? _currentUser { get; set; }
        public AuthService(ILocalStorageService _session, NavigationManager _nav, ICurrentRequest currentRequest)
        {
            USER_SESSION_OBJECT_KEY = $"OpenBanking_session_obj_{currentRequest.Host}";


            session = _session;
            nav = _nav;
            _currentRequest = currentRequest;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AdminEntity? _currentUser = await GetUserSession();

            if (_currentUser != null)
            {
                return await GenerateAuthenticationState(_currentUser);
            }
            else
            {
                nav.NavigateTo($"{_currentRequest.BaseUrl}/login");
                return await GenerateEmptyAuthenticationState();
            }
        }
        public async Task LoginAsync(AdminEntity user)
        {
            await SetUserSession(user);

            NotifyAuthenticationStateChanged(GenerateAuthenticationState(user));
        }
        public async Task LogoutAsync()
        {
            await SetUserSession(null);
            nav.NavigateTo($"{_currentRequest.BaseUrl}/login");
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }
        public async Task<AdminEntity?> GetUserSession()
        {
            if (_currentUser != null)
                return _currentUser;

            string? localUserJson = await session.GetItemAsync<string?>(USER_SESSION_OBJECT_KEY);

            if (string.IsNullOrEmpty(localUserJson))
            {
                _currentUser = null;
                await LogoutAsync();
                return null;
            }
            AdminEntity? user = JsonConvert.DeserializeObject<AdminEntity?>(localUserJson);
            _currentUser = user;

            return user;
        }
        private async Task SetUserSession(AdminEntity? user)
        {
            if (user != null)
            {
                await session.SetItemAsync(USER_SESSION_OBJECT_KEY, JsonConvert.SerializeObject(user));
                _currentUser = user;
            }
            else
            {
                await session.RemoveItemAsync(USER_SESSION_OBJECT_KEY);
                _currentUser = null;
            }
        }
        private Task<AuthenticationState> GenerateAuthenticationState(AdminEntity user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserId", user.Id.ToString()),
                new Claim("RoleId", user.RoleId.ToString()),
            }, "apiauth_type");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
    }
}
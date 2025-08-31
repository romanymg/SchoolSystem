using Common.Helpers;
using Common.Models;

namespace Admin.Helpers
{
    public class CurrentRequest : ICurrentRequest
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _serviceProvider;

        public CurrentRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _serviceProvider = serviceProvider;
        }

        public string? BaseUrl => _configuration["Settings:BaseUrl"] ?? "";
        public string? PhotoPath => _configuration["Settings:PhotoPath"] ?? "";

        public string? Host => _httpContextAccessor.HttpContext?.Request.Host.ToString();
        public string? UserIp => _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        public string? Origin
        {
            get
            {
                try
                {
                    if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("origin", out var _value))
                    {
                        return _value.ToString();
                    }
                }
                catch { }
                return "";
            }
        }
        public string Platform
        {
            get
            {
                try
                {
                    if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Platform", out var _value))
                    {
                        return _value.ToString();
                    }
                }
                catch { }
                return "";
            }
        }
        public bool IsArabic
        {
            get
            {
                try
                {
                    if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("lang", out var lang))
                    {
                        return lang.ToString().ToLower() == "ar";
                    }
                }
                catch { }
                return false;
            }
        }

        public long CurrentUserId
        {
            get
            {
                AdminEntity? user = _serviceProvider.Get<AuthService>().GetUserSession().Result;
                if (user != null)
                {
                    return user.Id;
                }
                else
                {
                    return 0;
                }
            }

        }
        public string CurrentUserName
        {
            get
            {
                AdminEntity? user = _serviceProvider.Get<AuthService>().GetUserSession().Result;
                if (user != null)
                {
                    return user.Name;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}

using Admin.Helpers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using System.Data;
using Common.Helpers;
using BAL.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(options =>
{
    options.MaximumReceiveMessageSize = 100 * 1024 * 1024;
});


builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddControllers();

AddServices();

AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

void AddServices()
{
    var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
    builder.Services.AddDbContext<DAL.DBContext>(db => db.UseSqlServer(connectionString, o => o.UseCompatibilityLevel(120)), ServiceLifetime.Transient);
    builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(connectionString));

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();

    builder.Services.AddScoped<ICurrentRequest, CurrentRequest>();
    builder.Services.AddScoped<JScript>();
    builder.Services.AddTransient<GridFilter>();

    if ((builder.Configuration["Settings:BackgroundService"] ?? "0") == "1")
    {
        //builder.Services.AddHostedService<BackgroundServices>();
    }

    builder.Services.AddScoped<UserService>();
}

void AddMudServices()
{
    builder.Services.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

        config.SnackbarConfiguration.PreventDuplicates = true;
        config.SnackbarConfiguration.NewestOnTop = true;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.VisibleStateDuration = 3000;
        config.SnackbarConfiguration.HideTransitionDuration = 300;
        config.SnackbarConfiguration.ShowTransitionDuration = 300;
        config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    });
}
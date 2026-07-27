using AccountMInfrastructureConfiguration;
using BlogMInfrastructureConfiguration;
using BookM.Infrastructure.Configuration;
using CommentMInfrastructureConfiguration;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Services.Application;
using Services.Application.AuthHelper;
using Services.Application.HashPassword;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("DbBookMarket")
    ?? throw new InvalidOperationException("Connection string 'DbBookMarket' not found.");

AccountMInfrastructureConfigurationBootstraper.Configure(builder.Services, connectionString);
BookMInfrastructureConfigurationBootstrapper.Configure(builder.Services, connectionString);
CommentMInfrastructureConfigurationBootstraper.Configure(builder.Services, connectionString);

// NOTE: Blog is now bootstrapped inside BookMInfrastructureConfigurationBootstrapper (shared BlogDbContext).
// Do NOT call BlogMInfrastructureConfigurationBootstraper.Configure separately here — it will register
// a duplicate DbContext that is incomplete.

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.Configure<HashingOptions>(o => o.Iterations = 100_000);

builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddScoped<IFileUploader, FileUploader>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.ExpireTimeSpan = TimeSpan.FromDays(30);
        o.SlidingExpiration = true;
        o.LoginPath = new PathString("/Accounts/login");
        o.LogoutPath = new PathString("/Accounts/logout");
        o.AccessDeniedPath = new PathString("/AccessDenied");
        o.Cookie.HttpOnly = true;
        o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        o.Cookie.SameSite = SameSiteMode.Lax;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole(Roles.Admin));
});

builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.Filters.Add<SecurityPageFilter>();
    })
    .AddRazorPagesOptions(options =>
    {
        // Default: require authentication for everything
        options.Conventions.AuthorizeFolder("/");

        // Anonymous pages
        options.Conventions.AllowAnonymousToPage("/Index");
        options.Conventions.AllowAnonymousToPage("/About");
        options.Conventions.AllowAnonymousToPage("/Privacy");
        options.Conventions.AllowAnonymousToPage("/Error");
        options.Conventions.AllowAnonymousToPage("/AccessDenied");
        options.Conventions.AllowAnonymousToPage("/Book/Index");
        options.Conventions.AllowAnonymousToPage("/Book/BookDetails");
        options.Conventions.AllowAnonymousToPage("/Blog/Index");
        options.Conventions.AllowAnonymousToPage("/Blog/BLogDetails");
        options.Conventions.AllowAnonymousToPage("/Accounts/login");
        options.Conventions.AllowAnonymousToPage("/Search/Index");
        options.Conventions.AllowAnonymousToPage("/Product");
        options.Conventions.AllowAnonymousToPage("/Cart");
        options.Conventions.AllowAnonymousToPage("/WishList");

        // Admin area: require Admin policy
        options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

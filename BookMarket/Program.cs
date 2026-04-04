using AccountMInfrastructureConfiguration;
using BlogMInfrastructureConfiguration;
using BookMarket;
using BookMInfrastucureConfigoration;
using CommentMInfrastructureConfiguration;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Services.Application;
using Services.Application.AuthHelper;
using Services.Application.Categoreis;
using Services.Application.HashPassword;
using Services.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");
AccountMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BlogMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BookMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
CommentMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
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
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        builder => builder.RequireRole(new List<string> { Roles.Admin }));
});

builder.Services.AddRazorPages().AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");


    });



// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseAuthentication(); // احراز هویت (در صورتی که دارید).
app.UseHttpsRedirection(); // اطمینان از استفاده از HTTPS.
app.UseStaticFiles(); // برای سرویس‌دهی فایل‌های استاتیک.

app.UseCookiePolicy(); // اعمال سیاست‌های مربوط به کوکی‌ها.




app.UseRouting(); // مسیریابی درخواست‌ها.
app.UseAuthorization(); // مجوزها و دسترسی‌ها.

app.MapControllers(); // نقشه‌برداری از کنترلرها.
app.MapRazorPages(); // نقشه‌برداری از صفحات Razor.

app.Run(); // اجرای برنامه.
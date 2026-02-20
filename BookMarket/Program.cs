using BlogM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using AccountMInfrastructureConfiguration;
using BlogMInfrastructureConfiguration;
using BookMInfrastucureConfigoration;
using CommentMInfrastructureConfiguration;
using Services;
using Services.Model;
using Book.Infrastructure.EFCore;
using AccountM.Infrastructure.EFCore;
using BookM.Infrastructure.EFCore;
using CommentM.Infrastructure.EFCore;
using BookM.ClientQueries.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");
AccountMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BlogMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BookMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
CommentMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);



// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFileUploader, FileUploader>();

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
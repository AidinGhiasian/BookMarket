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

var builder = WebApplication.CreateBuilder(args);
var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");
AccountMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BlogMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BookMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
CommentMInfrastructureConfigurationB.Configure(builder.Services, contectionstring);

builder.Services.AddDbContext<BlogDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BlogConnection"));
});
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AccountConnection"));
});




// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFileUploader, FileUploader>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

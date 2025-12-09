
using AccountM.Infrastructure.Configuration;
using BlogM.Infrastructure.Configuration;
using BookM.Infrastucure.Configoration;
using CommentM.Infrastructure.Configuration;
using Services;
using Services.Model;
var builder = WebApplication.CreateBuilder(args);
var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");
AccountMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BlogMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
BookMInfrastructureConfigurationBootstraper.Configure(builder.Services, contectionstring);
CommentMInfrastructureConfiguration.Configure(builder.Services, contectionstring);

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

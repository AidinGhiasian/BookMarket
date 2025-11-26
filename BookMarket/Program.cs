using AM.Infrastructure.Configoration;
using BM.Infrastructure.Configoration;
using Services;
using Services.Model;
var builder = WebApplication.CreateBuilder(args);
var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFileUploader, FileUploader>();

AMInfrastructureConfigorationBootstraper.Configure(builder.Services,contectionstring);
BMInfrastructureConfigorationBootstraper.Configure(builder.Services,contectionstring);

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

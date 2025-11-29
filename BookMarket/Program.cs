
using Services;
using Services.Model;
var builder = WebApplication.CreateBuilder(args);
var contectionstring = builder.Configuration.GetConnectionString("DbBookMarket");

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

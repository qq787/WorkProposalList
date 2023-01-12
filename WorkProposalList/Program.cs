using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DevExpress.Blazor;
using WorkProposalList.States;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();
builder.Services.AddLocalization();
builder.Services.AddScoped<ResponsibleState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCulture = new[] { "ru-RU" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCulture[0])
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

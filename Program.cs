using Microsoft.EntityFrameworkCore;
using SisSistemasWeb.Data;
using SisSistemasWeb.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using SisSistemasWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var supportedCultures = new[] { new CultureInfo("pt-BR") };
var localizationOptions = new RequestLocalizationOptions {
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IHoraExtraService, HoraExtraService>();

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

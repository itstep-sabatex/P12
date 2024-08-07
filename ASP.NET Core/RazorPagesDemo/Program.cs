using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo;
using RazorPagesDemo.Data;
using RazorPagesDemo.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
   ;
builder.Services.AddRazorPages();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options => {
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(DataAnotationSharedResorce));
});
builder.Services.AddSingleton<IEmailSender, GmailSender>();
builder.Services.AddSingleton<IMyLogger,MyLogger>();
builder.Services.AddScoped<MyLogger>();
builder.Services.AddTransient<MyLogger>();
//var mailServiceProvider = builder.Configuration.GetSection("MailServiceProvider").Value;
//if (mailServiceProvider == null)
//{
//    // bilder.Services.AddSingleton<IEmailSender,VirtualToFile>()


//}else
//{
//    if (mailServiceProvider == "Google")
//    {

//    }
//}
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("uk-UA") };
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    //
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    options.LoginPath = "/Identity/Account/Login";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseRequestLocalization(new RequestLocalizationOptions()
{ ApplyCurrentCultureToResponseHeaders = true }
.AddSupportedCultures(new[] { "en-US", "uk-UA" })
.AddSupportedUICultures(new[] { "en-US", "uk-UA" })
.SetDefaultCulture("en-US"));

app.MapRazorPages();
app.MapControllers();

app.Run();

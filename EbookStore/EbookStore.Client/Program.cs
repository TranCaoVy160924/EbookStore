using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using EbookStore.Client.ExternalService.EbookHostService;
using EbookStore.Client.ExternalService.ImageHostService;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Auth/AccessDenied";
        opt.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.MaxValue;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

string baseUrl = "https://localhost:7186/api";
builder.Services.AddRefitClient<IUserClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IBookClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IGenreClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<ISaleClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IWishlistClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<ICartlistClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

builder.Services.AddSingleton<IImageHostHelper, CloudinaryHelper>();
builder.Services.AddTransient<IEbookHostHelper, DropboxHelper>();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMvcCore()
    .AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// 📌 Veritabanı ve Identity konfigürasyonu
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser, WriterRole>()
    .AddEntityFrameworkStores<Context>();

// 📌 Yetkilendirme politikası ekle
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

// 📌 Cookie ayarları (kimlik doğrulama için)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Güvenlik için HttpOnly ayarı
    options.ExpireTimeSpan = TimeSpan.FromMinutes(100); // Çerez süresi
    options.AccessDeniedPath = "/ErrorPage/Index/";
    options.LoginPath = "/Writer/Login/Index/"; // Giriş yapılacak sayfa
});

// 🌍 Uygulamayı yapılandır
var app = builder.Build();

// 📌 HTTP isteği ara yazılımı yapılandırması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Kimlik doğrulama middleware
app.UseAuthorization();  // Yetkilendirme middleware

// 📌 Cache kontrolü
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});

// 📌 Alanlar ve varsayılan route yapılandırması
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// 🚀 Uygulamayı başlat
app.Run();

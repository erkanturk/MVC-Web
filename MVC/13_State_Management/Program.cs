var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
//AddDistributedMemoryCache metodu, uygulamanýn
//belleðinde oturum verilerini depolamak için gerekli olan daðýtýlmýþ bellek önbellek hizmetini ekler.

builder.Services.AddSession(options =>
{
    options.IdleTimeout=TimeSpan.FromMinutes(10);//Session'ýn 10 dakika boyunca kullanýlmamasý durumunda sona erer.
    options.Cookie.HttpOnly = true; //Sadece HTTP isteklerinde eriþilebilir, JavaScript tarafýndan eriþilemez.
    options.Cookie.IsEssential = true; //Session'ýn temel iþlevsellik için gerekli olduðunu belirtir.
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

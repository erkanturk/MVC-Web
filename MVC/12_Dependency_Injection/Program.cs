using _12_Dependency_Injection.Services.Abstract;
using _12_Dependency_Injection.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/* IMyService ve MyService i Container a ekliyoruz
 * .NetCore da Dependency Injection (DI) da servislerin ömrü (lifecycle) belirtmek için 3 farklý yöntem kullanýlýr.
 * 1.AddTransient: Her istek için yeni bir örnek oluþturur. Kýsa ömürlü servisler için uygundur.1 2  4 3 6 
 * 2.AddScoped: Her istek (request) için bir örnek oluþturur. 
 * Ayný istek içinde servis tekrar çaðrýlýrsa ayný örnek döner. Web uygulamalarýnda genellikle tercih edilir. 1 1  2 2
 * 3.AddSingleton: Uygulama ömrü boyunca tek bir örnek oluþturur ve tüm isteklerde ayný örneði döner. Uzun ömürlü servisler için uygundur. 1 1 1 1
 
 */

builder.Services.AddTransient<IMyService, MyService>();// Servis kaydý container a ekleniyor

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

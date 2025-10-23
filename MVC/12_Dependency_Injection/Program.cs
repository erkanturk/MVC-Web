using _12_Dependency_Injection.Services.Abstract;
using _12_Dependency_Injection.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/* IMyService ve MyService i Container a ekliyoruz
 * .NetCore da Dependency Injection (DI) da servislerin �mr� (lifecycle) belirtmek i�in 3 farkl� y�ntem kullan�l�r.
 * 1.AddTransient: Her istek i�in yeni bir �rnek olu�turur. K�sa �m�rl� servisler i�in uygundur.1 2  4 3 6 
 * 2.AddScoped: Her istek (request) i�in bir �rnek olu�turur. 
 * Ayn� istek i�inde servis tekrar �a�r�l�rsa ayn� �rnek d�ner. Web uygulamalar�nda genellikle tercih edilir. 1 1  2 2
 * 3.AddSingleton: Uygulama �mr� boyunca tek bir �rnek olu�turur ve t�m isteklerde ayn� �rne�i d�ner. Uzun �m�rl� servisler i�in uygundur. 1 1 1 1
 
 */

builder.Services.AddTransient<IMyService, MyService>();// Servis kayd� container a ekleniyor

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

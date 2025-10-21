var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();//Bu uygulamanýn Otomatik bir router sistemi kullamasýný saðlayan yapý

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(//Kedi özel oluþturduðum rotamý=>/Hakkýmýzda route olarak abouta gidecek
    name: "about",
    pattern:"hakkimizda",
    defaults: new{controller="Home",action="About"});
app.MapControllerRoute(
    name:"blogDetails",//route verilen eriþim deðeri
    pattern:"blog/details/{id}",//Eþlemmesi gereken url deseni
    defaults: new { controller="Blog",action="Details"},
    constraints: new {id=@"\d+" }//'id' parametresi sadece sayýlardan(0-9) doluþmalý
    
    );
app.Run();

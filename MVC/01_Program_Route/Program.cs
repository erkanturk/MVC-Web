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

app.UseRouting();//Bu uygulaman�n Otomatik bir router sistemi kullamas�n� sa�layan yap�

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(//Kedi �zel olu�turdu�um rotam�=>/Hakk�m�zda route olarak abouta gidecek
    name: "about",
    pattern:"hakkimizda",
    defaults: new{controller="Home",action="About"});
app.MapControllerRoute(
    name:"blogDetails",//route verilen eri�im de�eri
    pattern:"blog/details/{id}",//E�lemmesi gereken url deseni
    defaults: new { controller="Blog",action="Details"},
    constraints: new {id=@"\d+" }//'id' parametresi sadece say�lardan(0-9) dolu�mal�
    
    );
app.Run();

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

app.UseRouting();

app.UseAuthorization();

//he modificado el routing para que la pagina que se abra por defecto sea MiCurriculum index.
//si se pone en la url https://localhost:7138/MiCurriculum tambien la abre correctamente
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MiCurriculum}/{action=Index}/{id?}");


app.Run();

using Microsoft.EntityFrameworkCore;
using ProwayWebMvc.DependencyInjections;
using ProwayWebMvc.Middlewares;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.DependecyInjections;
using SupermercadoServicos.DependecyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .ConfigureDatabase(builder.Configuration)
    .ConfigureAutoMapper()
    .AddServices()
    .AddRepositories()
    .AddControllersWithViews();

// Configurar a sessão para conseguir realizar o login
builder.Services.AddSession(options =>
{
    // Configurar o tempo em que o usuário n tem interação com o sistema
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseAuthorization();
app.UseSession();

app.UseMiddleware<AutenticacaoMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using(var scopo = app.Services.CreateScope())
{
    // Irá aplicar automaticamente as migrações quando a aplicação subir,
    // ou seja, vai criar o banco de dados com as tabelas mapeadas
    var contexto = scopo.ServiceProvider.GetService<SupermercadoContexto>();
    contexto?.Database.Migrate();
}
app.Run();

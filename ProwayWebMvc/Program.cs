using Microsoft.EntityFrameworkCore;
using SupermercadoRepositorios.BancoDados;
using SupermercadoRepositorios.Repositorios;
using SupermercadoServicos.Interfaces;
using SupermercadoServicos.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SupermercadoContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar as classes que implementam as interfaces de serviço e repositório
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ICategoriaServico, CategoriaServico>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
builder.Services.AddScoped<IEstanteRepositorio, EstanteRepositorio>();
builder.Services.AddScoped<IEstanteServico, EstanteServico>();
builder.Services.AddScoped<IArquivoUploadServico, ArquivoUploadServico>();

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

using(var scopo = app.Services.CreateScope())
{
    // Irá aplicar automaticamente as migrações quando a aplicação subir,
    // ou seja, vai criar o banco de dados com as tabelas mapeadas
    var contexto = scopo.ServiceProvider.GetService<SupermercadoContexto>();
    contexto?.Database.Migrate();
}
app.Run();

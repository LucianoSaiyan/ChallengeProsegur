using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Application.Abstractions;
using ChallengeProsegur.Application.Implementations;
using ChallengeProsegur.DataAccess.Implementations;
using ChallengeProsegur.Repository.Abstractions;
using ChallengeProsegur.Repository.Implementations;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
try
{

#if true
    #region Instanciador Scrutor
    var AssemblyApplication = Assembly.GetAssembly(typeof(Application<>));
    builder.Services.Scan(scan =>
        scan.FromAssemblies(AssemblyApplication)
        .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Application")))
        .AsImplementedInterfaces()
        .WithTransientLifetime());

    builder.Services.Scan(scan =>
        scan.FromAssemblies(Assembly.GetAssembly(typeof(Repository<>)))
        .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithTransientLifetime());

    builder.Services.Scan(scan =>
       scan.FromAssemblies(Assembly.GetAssembly(typeof(DbContext<>)))
       .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DbContext")))
       .AsImplementedInterfaces()
       .WithTransientLifetime());

    #endregion
#else
    #region Instancias Genericas
    builder.Services.AddScoped(typeof(IApplication<>), typeof(Application<>));
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));

    var applicationAssembly = Assembly.GetAssembly(typeof(Application<>));

    // Escanea y registra las clases que terminan con "Application"
    builder.Services.Scan(scan =>
    {
        scan.FromAssemblies(applicationAssembly)
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Application")))
            .AsImplementedInterfaces()
            .WithTransientLifetime();
    });
    #endregion
#endif





}
catch (Exception ex)
{
    throw ex;
}


//se obtiene el conection string y se establece el valor al apidbcontext
builder.Services.AddDbContext<ApiDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    m => m.MigrationsAssembly("ChallengeProsegur.Server")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//se configuran los cors para que el front nos de el permiso para mostrar los datos
app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7088")
           .AllowAnyMethod()
           .AllowAnyHeader();
});


app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

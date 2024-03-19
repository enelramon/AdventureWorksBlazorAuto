using AdventureWorksBlazorAuto.Client.Pages;
using AdventureWorksBlazorAuto.Client.Services;
using AdventureWorksBlazorAuto.Components;
using AdventureWorksBlazorAuto.DAL;
using AdventureWorksBlazorAuto.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<AdventureWorks2019Context>(op =>
    op.UseSqlServer(ConStr)
    );

builder.Services.AddScoped<DepartmentsService>();


builder.Services.AddScoped(c =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["RutaApi"] ?? "https://localhost:7242")
    }
);
builder.Services.AddHttpClient();


builder.Services.AddScoped<DepartmentService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AdventureWorksBlazorAuto.Client._Imports).Assembly);

app.MapControllers();

app.Run();

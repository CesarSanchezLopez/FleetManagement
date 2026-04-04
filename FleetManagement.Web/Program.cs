using FleetManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar Razor Pages
builder.Services.AddRazorPages();

// Leer la URL de la API desde appsettings
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

// Configurar HttpClient para consumir la API
builder.Services.AddHttpClient<CompaniesService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<DriversService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<VehiclesService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Habilitar CORS para que Razor pueda consumir la API si está en otro puerto
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Pipeline de ASP.NET
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
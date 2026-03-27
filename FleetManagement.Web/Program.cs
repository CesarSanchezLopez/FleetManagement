using FleetManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configurar HttpClient para consumir la API
builder.Services.AddHttpClient<CompaniesService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7200/"); // URL de tu API
});

builder.Services.AddHttpClient<DriversService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7200/"); // URL de tu API
});

builder.Services.AddHttpClient<VehiclesService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7200/"); // tu URL de API
});

// Si luego agregas más servicios, solo agrega más HttpClient aquí.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
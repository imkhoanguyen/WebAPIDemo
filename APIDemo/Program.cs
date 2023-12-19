var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Routing
app.MapGet("/shirts", () =>
{
    return "Reading all the shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading all the shirts: {id}";
});

app.MapPost("/shirts", () =>
{
    return "Creating a shirt";
});

app.MapPut("/shirts", (int id) =>
{
    return $"Updating shirt with ID: {id}";
});

app.MapDelete("/shirts", (int id) =>
{
    return $"Deleting shirt with ID: {id}";
});

app.Run();

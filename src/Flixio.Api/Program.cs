var builder = WebApplication.CreateBuilder(args);

builder.SetupOtlp();

builder.Services
    .RegisterFlixioDbContext()
    .RegisterMiddleware()
    .SetupAllowAllCors();

var app = builder.Build();

app.SetupFlixio();

await app.SetupDatabase();

await app.RunAsync();



var builder = WebApplication.CreateBuilder(args);

builder.SetupOtlp();

builder.Services
    .RegisterFlixioDbContext()
    .RegisterMiddleware();

var app = builder.Build();

app.SetupFlixio();

await app.LogStartup();

await app.RunAsync();



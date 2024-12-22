var builder = WebApplication.CreateBuilder(args);

builder.SetupOtlp();

builder.Configuration
    .AddAuthenticationConfiguration()
    .AddCorsConfiguration();

builder.Services
    .RegisterFlixioDbContext()
    .RegisterMiddleware()
    .SetupAllowedOrigins(builder.Configuration)
    .RegisterAuthenticationConfiguration(builder.Configuration);

var app = builder.Build();

app.SetupFlixio();

await app.SetupDatabase();
await app.LogConfigurationValues();

await app.RunAsync();



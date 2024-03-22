using Api.Auth;
using Api.Middlewares;
using DataAccess;
using DataAccess.DataContexts;
using DataAccess.DataContexts.Interfaces;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;

namespace Api.Extensions;

public static class MigrationExtensions
{
    public static void AddMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
        migrator?.MigrateUp();
    }

    public static void ConfigureMigrator(this IMigrationRunnerBuilder migrationRunnerBuilder, ConfigurationManager config)
    {
        DbFactory.GetMigrationSetuper(config, migrationRunnerBuilder)(migrationRunnerBuilder);
    }
}

public static class AuthAppExtensions
{
    public static void AddAuthenticationWithOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };
            });
    }
}

public static class SwaggerAppExtensions
{
    public static void AddSwaggerOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = @"Введите JWT токен авторизации.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {new OpenApiSecurityScheme {Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}}, new List<string>()}
            });
        });
    }
}

public static class WebAppConfigurationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.AddMigrations();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.MapControllers();

        if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Local"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
    }

    public static void Configure(this WebApplicationBuilder builder)
    {
        Console.WriteLine(builder.Configuration["PGConnection"]);

        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(c => c.ConfigureMigrator(builder.Configuration))
            .AddLogging();

        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.AddAuthenticationWithOptions();
        builder.ConfigureService();
        builder.AddSwaggerOptions();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(AppMappingProfile));
    }

    private static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransientGroup();
        builder.Services.AddScopedGroup();
        builder.Services.AddSingletonGroup();
    }

    private static void AddTransientGroup(this IServiceCollection services)
    {
        services.AddTransient<IFileContentService, FileContentService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IFileContainerService, FileContainerService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IViolationService, ViolationService>();
    }

    private static void AddScopedGroup(this IServiceCollection services)
    {
        services.AddScoped<IFileContentRepository, FileContentRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileContainerRepository, FileContainerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IViolationRepository, ViolationRepository>();
    }

    private static void AddSingletonGroup(this IServiceCollection services)
    {
        services.AddSingleton<IDataContext, DapperContext>();
    }
}
using API.Inventory.Application.Internal.CommandService;
using API.Inventory.Application.Internal.QueryService;
using API.Inventory.Domain.Repository;
using API.Inventory.Domain.Service;
using API.Inventory.Infrastructure.Persistance.EFC.Repositories;
using API.Inventory.Interfaces.ACL.Services;
using API.Inventory.Interfaces.ACL.Services.Services;
using API.Observability.Application.Internal.CommandServices;
using API.Observability.Application.Internal.OutboundServices.ACL;
using API.Observability.Domain.Repository;
using API.Observability.Domain.Service;
using API.Observability.Infrastructure.Persistance.EFC.Repositories;
using API.Shared.Domain.Repositories;
using API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using API.Shared.Infrastructure.Persistance.EFC.Configuration;
using API.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });


builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = " IRRIOT API",
                Description = " IRRIOT ",
                TermsOfService = new Uri("https://IRRIOT.com/tos"),
             
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();
builder.Services.AddScoped<IThingQueryService, ThingQueryService>();
builder.Services.AddScoped<IThingContextFacade, ThingContextFacade>();
builder.Services.AddScoped<IThingStateRepository, ThingStateRepository>();
builder.Services.AddScoped<IThingStateCommandService, ThingStateCommandService>();
builder.Services.AddScoped<ExternalThingService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
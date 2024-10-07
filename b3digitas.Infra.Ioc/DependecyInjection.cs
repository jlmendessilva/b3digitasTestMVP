using b3digitas.Application.Interfaces;
using b3digitas.Application.Mappings;
using b3digitas.Application.Services;
using b3digitas.Domain.Interfaces;
using b3digitas.Infra.Data.Context;
using b3digitas.Infra.Data.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;

namespace b3digitas.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {

            // Configurações do CosmosDB
            string connectionString = config["CosmosDb:ConnectionString"];
            string databaseId = config["CosmosDb:DatabaseId"];
            string containerId = config["CosmosDb:ContainerId"];

            // Adicionar o CosmosClient ao contêiner de serviços
            services.AddSingleton(s => new CosmosClient(connectionString));

            // Adicionar o Container do CosmosDB ao contêiner de serviços
            services.AddSingleton<Container>(s =>
            {
                var cosmosClient = s.GetRequiredService<CosmosClient>();
                var database = cosmosClient.GetDatabase(databaseId);
                var container = database.GetContainer(containerId);
                return container;
            });

            services.AddScoped<DbConnection>(sp => new NpgsqlConnection(config.GetConnectionString("pgsql")));

            services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(config.GetConnectionString("pgsql"),
                p => p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddAutoMapper(typeof(DomainMapDtoProfile));

            return services;
        }

    }
}

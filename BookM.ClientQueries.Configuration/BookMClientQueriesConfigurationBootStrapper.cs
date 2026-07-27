using Microsoft.Extensions.DependencyInjection;

namespace BookM.ClientQueries.Configuration
{
    public static class BookMClientQueriesConfigurationBootStrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            // Queries are already registered in per-module bootstrappers
            // (AccountMInfrastructureConfiguration / BookMInfrastructureConfiguration / CommentMInfrastructureConfiguration).
            // Left here as an extension point for future cross-cutting query concerns.
        }
    }
}

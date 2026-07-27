// NOTE: Blog subsystems are now bootstrapped from
// BookM.Infrastructure.Configuration.BookMInfrastructureConfigurationBootstrapper
// which registers Book.Infrastructure.EFCore.BlogDbContext once.
// This file is intentionally left empty to avoid double-registration.
// (Kept for backwards compat with any external references.)

using Microsoft.Extensions.DependencyInjection;

namespace BlogMInfrastructureConfiguration
{
    public static class BlogMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            // No-op: handled by BookMInfrastructureConfigurationBootstrapper.
        }
    }
}

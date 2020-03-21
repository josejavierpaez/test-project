using GatewayApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GatewayApi.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<GSMGateway> GSMGateways { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}

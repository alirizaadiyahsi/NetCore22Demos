using Microsoft.EntityFrameworkCore;
using NetCore22Demos.Models;

namespace NetCore22Demos.Data
{
    public class NetCore22DemosContext : DbContext
    {
        public NetCore22DemosContext(DbContextOptions<NetCore22DemosContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

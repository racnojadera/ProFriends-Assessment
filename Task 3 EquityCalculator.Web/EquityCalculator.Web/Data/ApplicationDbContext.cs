using EquityCalculator.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquityCalculator.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EquityStatus> EquityStatuses { get; set; }
    }
}

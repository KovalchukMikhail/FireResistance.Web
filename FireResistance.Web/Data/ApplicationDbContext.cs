using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FireResistance.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ColumnFireIsWithFourSidesData> ColumnFireIsWithFourSidesData { get; set; }
        public DbSet<SlabWithRigidConnectionData> SlabWithRigidConnectionData { get; set; }
    }
}
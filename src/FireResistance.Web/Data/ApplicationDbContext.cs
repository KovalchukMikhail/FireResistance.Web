using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace FireResistance.Web.Data
{
    /// <summary>Класс содержит описание сеанса с баззой данных и может использоваться для запроса и сохранения экземпляров сущностей </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Database.EnsureCreated();
        }
        // Так как в классе наследуемом от DbContext определено свойство типа DbSet для класса ColumnFireIsWithFourSidesData будет создана таблица в базе данных
        public DbSet<ColumnFireIsWithFourSidesData> ColumnFireIsWithFourSidesData { get; set; }
        // Так как в классе наследуемом от DbContext определено свойство типа DbSet для класса SlabWithRigidConnectionData будет создана таблица в базе данных
        public DbSet<SlabWithRigidConnectionData> SlabWithRigidConnectionData { get; set; }
    }
}
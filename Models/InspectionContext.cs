using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using APHIS.Models.Mapping;

namespace APHIS.Models
{
    public partial class InspectionContext : DbContext
    {
        static InspectionContext()
        {
            Database.SetInitializer<InspectionContext>(null);
        }

        public InspectionContext()
            : base("Name=InspectionContext")
        {
        }

        public DbSet<inspection> inspections { get; set; }
        public DbSet<inspectionDetail> inspectionDetails { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new inspectionMap());
            modelBuilder.Configurations.Add(new inspectionDetailMap());
            modelBuilder.Configurations.Add(new StatusMap());
        }
    }
}

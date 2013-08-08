using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APHIS.Models.Mapping
{
    public class inspectionMap : EntityTypeConfiguration<inspection>
    {
        public inspectionMap()
        {
            // Primary Key
            this.HasKey(t => t.IID);

            // Properties
            this.Property(t => t.InspectionDate)
                .HasMaxLength(30);

            this.Property(t => t.InspectionInventoryAnimalsCommonName)
                .HasMaxLength(50);

            this.Property(t => t.USDACertificateNumber)
                .HasMaxLength(9);

            // Table & Column Mappings
            this.ToTable("inspection", "APHIS");
            this.Property(t => t.IID).HasColumnName("IID");
            this.Property(t => t.CountCitations).HasColumnName("CountCitations");
            this.Property(t => t.CustomerNumber).HasColumnName("CustomerNumber");
            this.Property(t => t.InspectionDate).HasColumnName("InspectionDate");
            this.Property(t => t.InspectionID).HasColumnName("InspectionID");
            this.Property(t => t.InspectionInventoryAnimalsCommonName).HasColumnName("InspectionInventoryAnimalsCommonName");
            this.Property(t => t.InspectionInventoryCount).HasColumnName("InspectionInventoryCount");
            this.Property(t => t.USDACertificateNumber).HasColumnName("USDACertificateNumber");
        }
    }
}

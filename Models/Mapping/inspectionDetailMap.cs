using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APHIS.Models.Mapping
{
    public class inspectionDetailMap : EntityTypeConfiguration<inspectionDetail>
    {
        public inspectionDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.DetailID);

            // Properties
            this.Property(t => t.USDACertificateNumber)
                .HasMaxLength(9);

            this.Property(t => t.CFRCitationSection)
                .HasMaxLength(50);

            this.Property(t => t.NCICFRCitationDescription)
                .HasMaxLength(150);

            this.Property(t => t.TypeofInspection)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("inspectionDetail", "APHIS");
            this.Property(t => t.DetailID).HasColumnName("DetailID");
            this.Property(t => t.InspectionID).HasColumnName("InspectionID");
            this.Property(t => t.USDACertificateNumber).HasColumnName("USDACertificateNumber");
            this.Property(t => t.CFRCitationSection).HasColumnName("CFRCitationSection");
            this.Property(t => t.NCICFRCitationDescription).HasColumnName("NCICFRCitationDescription");
            this.Property(t => t.TypeofInspection).HasColumnName("TypeofInspection");
        }
    }
}

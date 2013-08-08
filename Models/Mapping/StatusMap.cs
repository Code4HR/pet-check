using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APHIS.Models.Mapping
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            // Primary Key
            this.HasKey(t => t.cid);

            // Properties
            this.Property(t => t.cid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.USDACertificateNumber)
                .HasMaxLength(9);

            this.Property(t => t.USDACertificateCurrentStatus)
                .HasMaxLength(9);

            this.Property(t => t.USDACertificateBeginDate)
                .HasMaxLength(24);

            this.Property(t => t.USDACertificateCurrentStatusDate)
                .HasMaxLength(24);

            // Table & Column Mappings
            this.ToTable("Status", "APHIS");
            this.Property(t => t.cid).HasColumnName("cid");
            this.Property(t => t.CustomerNumber).HasColumnName("CustomerNumber");
            this.Property(t => t.USDACertificateNumber).HasColumnName("USDACertificateNumber");
            this.Property(t => t.USDACertificateCurrentStatus).HasColumnName("USDACertificateCurrentStatus");
            this.Property(t => t.USDACertificateBeginDate).HasColumnName("USDACertificateBeginDate");
            this.Property(t => t.USDACertificateCurrentStatusDate).HasColumnName("USDACertificateCurrentStatusDate");
        }
    }
}

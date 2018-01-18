using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using QDICodeChallenge.Models;

namespace QDICodeChallenge.Data
{
    public class ZipCodeConfiguration : EntityTypeConfiguration<ZipCode>
    {
        public ZipCodeConfiguration()
        {
            this.HasKey(p => p.zipcodeid);

            this.Property(p => p.city)
                .HasMaxLength(100);

            this.Property(p => p.state)
                .HasMaxLength(100);

            this.Property(p => p.country)
                .HasMaxLength(100);

            this.Property(p => p.updated)
                .IsRequired()
                .HasColumnType("datetime");

            this.Property(p => p.updatedby)
                .IsRequired();
        }
    }
}

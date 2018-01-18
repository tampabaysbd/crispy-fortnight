using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using QDICodeChallenge.Models;

namespace QDICodeChallenge.Data
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            this.Property(p => p.id)
                .HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);

            this.Property(p => p.firstname)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.lastname)
                .IsRequired()
                .HasMaxLength(100);

            this.HasRequired(t => t.zipcode);
        }
    }
}

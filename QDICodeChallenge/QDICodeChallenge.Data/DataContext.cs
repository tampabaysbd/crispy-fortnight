using System.Configuration;
using System.Data.Entity;
using QDICodeChallenge.Models;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace QDICodeChallenge.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["DataContextConnection"] ?? "DefaultConnection";
            }
        }

        public DataContext() : base(DataContext.ConnectionStringName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // context configuartion and convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("qdicc");

            // model Configurations
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new ZipCodeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

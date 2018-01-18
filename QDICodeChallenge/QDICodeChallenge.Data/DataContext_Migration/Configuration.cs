namespace QDICodeChallenge.Data.DataContext_Migration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using QDICodeChallenge.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<QDICodeChallenge.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext_Migration";
        }

        protected override void Seed(QDICodeChallenge.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            bool seedFlag = false;
            if (seedFlag)
            {
                context.ZipCodes.AddOrUpdate(
                    new ZipCode { zipcodeid = "99999", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "33569", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "33511", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "90020", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "73344", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "75001", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "60415", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "60416", updated = DateTime.Now, updatedby = "seed" },
                    new ZipCode { zipcodeid = "10032", updated = DateTime.Now, updatedby = "seed" }
                );

                context.Contacts.AddOrUpdate(
                    new Contact { firstname = "John", lastname = "Smith", zipcodeid = "99999" },
                    new Contact { firstname = "James", lastname = "Johnson", zipcodeid = "33569" },
                    new Contact { firstname = "George", lastname = "Clooney", zipcodeid = "33511" },
                    new Contact { firstname = "Susan", lastname = "SaintJames", zipcodeid = "90020" },
                    new Contact { firstname = "Sam", lastname = "Samuelson", zipcodeid = "73344" },
                    new Contact { firstname = "Daisy", lastname = "Duke", zipcodeid = "75001" },
                    new Contact { firstname = "Nichole", lastname = "Smith", zipcodeid = "75001" },
                    new Contact { firstname = "Bill", lastname = "Samples", zipcodeid = "60415" },
                    new Contact { firstname = "Amanda", lastname = "Davis", zipcodeid = "60416" },
                    new Contact { firstname = "Albert", lastname = "Jackson", zipcodeid = "10032" }
                );
            }
        }
    }
}

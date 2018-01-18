namespace QDICodeChallenge.Data.DataContext_Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "qdicc.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstname = c.String(nullable: false, maxLength: 100),
                        lastname = c.String(nullable: false, maxLength: 100),
                        zipcode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("qdicc.Contact");
        }
    }
}

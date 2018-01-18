namespace QDICodeChallenge.Data.DataContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "qdicc.Contact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(nullable: false, maxLength: 100),
                        lastname = c.String(nullable: false, maxLength: 100),
                        zipcodeid = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("qdicc.ZipCode", t => t.zipcodeid, cascadeDelete: true)
                .Index(t => t.zipcodeid);
            
            CreateTable(
                "qdicc.ZipCode",
                c => new
                    {
                        zipcodeid = c.String(nullable: false, maxLength: 128),
                        city = c.String(maxLength: 100),
                        state = c.String(maxLength: 100),
                        country = c.String(maxLength: 100),
                        updated = c.DateTime(nullable: false),
                        updatedby = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.zipcodeid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("qdicc.Contact", "zipcodeid", "qdicc.ZipCode");
            DropIndex("qdicc.Contact", new[] { "zipcodeid" });
            DropTable("qdicc.ZipCode");
            DropTable("qdicc.Contact");
        }
    }
}

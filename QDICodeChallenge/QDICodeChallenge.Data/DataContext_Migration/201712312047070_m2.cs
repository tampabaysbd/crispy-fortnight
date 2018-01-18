namespace QDICodeChallenge.Data.DataContext_Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("qdicc.Contact", "zipcodeid", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("qdicc.Contact", "zipcodeid");
            AddForeignKey("qdicc.Contact", "zipcodeid", "qdicc.ZipCode", "zipcodeid", cascadeDelete: true);
            DropColumn("qdicc.Contact", "zipcode");
        }
        
        public override void Down()
        {
            AddColumn("qdicc.Contact", "zipcode", c => c.String(maxLength: 10));
            DropForeignKey("qdicc.Contact", "zipcodeid", "qdicc.ZipCode");
            DropIndex("qdicc.Contact", new[] { "zipcodeid" });
            DropColumn("qdicc.Contact", "zipcodeid");
            DropTable("qdicc.ZipCode");
        }
    }
}

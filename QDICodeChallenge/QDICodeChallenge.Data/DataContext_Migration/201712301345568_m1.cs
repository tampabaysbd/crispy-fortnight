namespace QDICodeChallenge.Data.DataContext_Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("qdicc.Contact", "zipcode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("qdicc.Contact", "zipcode", c => c.String(maxLength: 10, fixedLength: true, unicode: false));
        }
    }
}

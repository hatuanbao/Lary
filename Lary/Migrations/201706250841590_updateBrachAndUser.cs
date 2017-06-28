namespace Lary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBrachAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
            DropColumn("dbo.Branches", "IsDelete");
        }
    }
}

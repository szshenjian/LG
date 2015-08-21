namespace Longgan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productAddPriority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "PriorityNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "PriorityNum");
        }
    }
}

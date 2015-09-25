namespace Longgan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCaseAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SetCase", "PriorityNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SetCase", "PriorityNum");
        }
    }
}

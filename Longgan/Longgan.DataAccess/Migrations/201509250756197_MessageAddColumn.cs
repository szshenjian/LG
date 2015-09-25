namespace Longgan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "Qq", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "Qq");
        }
    }
}

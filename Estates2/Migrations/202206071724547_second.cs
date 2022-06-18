namespace Estates2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "Name");
        }
    }
}

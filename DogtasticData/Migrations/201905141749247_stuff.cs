namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Playdate");
            AddColumn("dbo.Playdate", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Playdate", "ParentName", c => c.String(nullable: false));
            AddColumn("dbo.Playdate", "DogName", c => c.String(nullable: false));
            AddColumn("dbo.Playdate", "DogSize", c => c.Int(nullable: false));
            AddColumn("dbo.Playdate", "AgeLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Playdate", "AddressOfEvent", c => c.String(nullable: false));
            AddColumn("dbo.Playdate", "LeaveAMessage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Playdate", "PlaydateID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Playdate", "UserID");
            DropColumn("dbo.Playdate", "Name");
            DropColumn("dbo.Playdate", "Address");
            DropColumn("dbo.Playdate", "CreatedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playdate", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Playdate", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Playdate", "Name", c => c.String(nullable: false));
            DropPrimaryKey("dbo.Playdate");
            AlterColumn("dbo.Playdate", "PlaydateID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Playdate", "LeaveAMessage");
            DropColumn("dbo.Playdate", "AddressOfEvent");
            DropColumn("dbo.Playdate", "AgeLevel");
            DropColumn("dbo.Playdate", "DogSize");
            DropColumn("dbo.Playdate", "DogName");
            DropColumn("dbo.Playdate", "ParentName");
            DropColumn("dbo.Playdate", "UserID");
            AddPrimaryKey("dbo.Playdate", "PlaydateID");
        }
    }
}

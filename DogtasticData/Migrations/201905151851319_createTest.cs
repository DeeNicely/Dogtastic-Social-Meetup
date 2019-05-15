namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTest : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Playdate");
            AddColumn("dbo.Playdate", "DogID", c => c.Int(nullable: false));
            AlterColumn("dbo.Playdate", "PlaydateID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Playdate", "PlaydateID");
            CreateIndex("dbo.Playdate", "DogID");
            AddForeignKey("dbo.Playdate", "DogID", "dbo.Dog", "DogID", cascadeDelete: true);
            DropColumn("dbo.Playdate", "ParentName");
            DropColumn("dbo.Playdate", "DogName");
            DropColumn("dbo.Playdate", "DogSize");
            DropColumn("dbo.Playdate", "AgeLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playdate", "AgeLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Playdate", "DogSize", c => c.Int(nullable: false));
            AddColumn("dbo.Playdate", "DogName", c => c.String(nullable: false));
            AddColumn("dbo.Playdate", "ParentName", c => c.String(nullable: false));
            DropForeignKey("dbo.Playdate", "DogID", "dbo.Dog");
            DropIndex("dbo.Playdate", new[] { "DogID" });
            DropPrimaryKey("dbo.Playdate");
            AlterColumn("dbo.Playdate", "PlaydateID", c => c.Int(nullable: false));
            DropColumn("dbo.Playdate", "DogID");
            AddPrimaryKey("dbo.Playdate", "UserID");
        }
    }
}

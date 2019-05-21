namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentplaydateinfo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Playdate", "UserID");
            AddForeignKey("dbo.Playdate", "UserID", "dbo.Parent", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playdate", "UserID", "dbo.Parent");
            DropIndex("dbo.Playdate", new[] { "UserID" });
        }
    }
}

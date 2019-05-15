namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idontknow : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Parent");
            AddColumn("dbo.Parent", "UserID", c => c.Guid(nullable: false));
            DropColumn("dbo.Parent", "ParentID");
            AddColumn("dbo.Parent", "ParentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Parent", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Parent");
            DropColumn("dbo.Parent", "ParentID");
            AddColumn("dbo.Parent", "ParentID", c => c.Int(nullable: false));
            DropColumn("dbo.Parent", "UserID");
            AddPrimaryKey("dbo.Parent", "ParentID");
        }
    }
}

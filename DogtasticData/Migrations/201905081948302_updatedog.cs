namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedog : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Dog");
            DropColumn("dbo.Dog", "UserID");
            AddColumn("dbo.Dog", "UserID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Dog", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Dog");
            DropColumn("dbo.Dog", "UserID");
            AddColumn("dbo.Dog", "UserID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Dog", "UserID");
        }
    }
}

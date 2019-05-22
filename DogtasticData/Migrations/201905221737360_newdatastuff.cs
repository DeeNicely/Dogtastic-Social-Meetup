namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatastuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Playdate", "Timer", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Playdate", "Timer", c => c.String(nullable: false));
        }
    }
}

namespace DogtasticData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimePicker : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Playdate", "EventDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Playdate", "EventDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}

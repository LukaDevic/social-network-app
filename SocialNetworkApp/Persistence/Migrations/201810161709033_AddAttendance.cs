namespace SocialNetworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ConcertId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ConcertId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Concerts", t => t.ConcertId)
                .Index(t => t.ConcertId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "ConcertId", "dbo.Concerts");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "ConcertId" });
            DropTable("dbo.Attendances");
        }
    }
}

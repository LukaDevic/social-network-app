namespace SocialNetworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConvenctionsForConcertAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Concerts", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Concerts", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Concerts", new[] { "Artist_Id" });
            DropIndex("dbo.Concerts", new[] { "Genre_Id" });
            AlterColumn("dbo.Concerts", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Concerts", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Concerts", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Concerts", "Artist_Id");
            CreateIndex("dbo.Concerts", "Genre_Id");
            AddForeignKey("dbo.Concerts", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Concerts", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerts", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Concerts", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Concerts", new[] { "Genre_Id" });
            DropIndex("dbo.Concerts", new[] { "Artist_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Concerts", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Concerts", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Concerts", "Venue", c => c.String());
            CreateIndex("dbo.Concerts", "Genre_Id");
            CreateIndex("dbo.Concerts", "Artist_Id");
            AddForeignKey("dbo.Concerts", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Concerts", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

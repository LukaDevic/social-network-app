namespace SocialNetworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToConcert : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Concerts", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Concerts", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Concerts", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Concerts", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Concerts", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Concerts", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Concerts", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Concerts", name: "ArtistId", newName: "Artist_Id");
        }
    }
}

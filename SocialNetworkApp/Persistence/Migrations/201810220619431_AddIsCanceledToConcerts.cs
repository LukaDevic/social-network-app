namespace SocialNetworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToConcerts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Concerts", "IsCanceled");
        }
    }
}

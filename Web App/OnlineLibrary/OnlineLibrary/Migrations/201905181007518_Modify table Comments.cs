namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifytableComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Author");
            DropColumn("dbo.Comments", "Rating");
        }
    }
}

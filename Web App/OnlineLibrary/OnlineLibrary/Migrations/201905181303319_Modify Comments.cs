namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "BookId", "dbo.Book");
            AddForeignKey("dbo.Comments", "BookId", "dbo.Book", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BookId", "dbo.Book");
            AddForeignKey("dbo.Comments", "BookId", "dbo.Book", "ID");
        }
    }
}

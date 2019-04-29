namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldFilePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "FilePath");
        }
    }
}

namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNumberOfBookToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "NumberOfBooks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "NumberOfBooks");
        }
    }
}

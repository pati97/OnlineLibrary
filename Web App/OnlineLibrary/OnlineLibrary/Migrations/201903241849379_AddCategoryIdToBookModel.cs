namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryIdToBookModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Book", new[] { "Category_ID" });
            RenameColumn(table: "dbo.Book", name: "Category_ID", newName: "CategoryID");
            AlterColumn("dbo.Book", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "CategoryID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Book", new[] { "CategoryID" });
            AlterColumn("dbo.Book", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Book", name: "CategoryID", newName: "Category_ID");
            CreateIndex("dbo.Book", "Category_ID");
        }
    }
}

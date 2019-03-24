namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSeedMethod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "YearOfPublication", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "YearOfPublication", c => c.DateTime(nullable: false));
        }
    }
}

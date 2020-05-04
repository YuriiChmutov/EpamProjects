namespace EpamLecturePracticeProducts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfBookMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Type");
        }
    }
}

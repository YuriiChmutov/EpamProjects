namespace EpamLecturePracticeProducts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddISN1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ISN", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Type", c => c.String());
            DropColumn("dbo.Book", "ISN");
        }
    }
}

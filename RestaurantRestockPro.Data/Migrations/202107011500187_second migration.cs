namespace RestaurantRestockPro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockItem",
                c => new
                    {
                        StockItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFood = c.Boolean(nullable: false),
                        ItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StockItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockItem");
        }
    }
}

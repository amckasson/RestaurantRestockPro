namespace RestaurantRestockPro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockOrder",
                c => new
                    {
                        StockOrderId = c.Int(nullable: false, identity: true),
                        Manager = c.String(nullable: false),
                        OrderCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        OrderUpdated = c.DateTimeOffset(nullable: false, precision: 7),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockOrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockOrder");
        }
    }
}

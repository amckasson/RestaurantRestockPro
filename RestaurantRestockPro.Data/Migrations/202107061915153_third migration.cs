namespace RestaurantRestockPro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restock",
                c => new
                    {
                        RestockId = c.Int(nullable: false, identity: true),
                        StockOrderId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestockId)
                .ForeignKey("dbo.StockItem", t => t.StockItemId, cascadeDelete: true)
                .ForeignKey("dbo.StockOrder", t => t.StockOrderId, cascadeDelete: true)
                .Index(t => t.StockOrderId)
                .Index(t => t.StockItemId);
            
            AddColumn("dbo.Restaurant", "StockOrderId", c => c.Int(nullable: false));
            AddColumn("dbo.StockOrder", "Restaurant_RestaurantId", c => c.Int());
            CreateIndex("dbo.StockOrder", "Restaurant_RestaurantId");
            AddForeignKey("dbo.StockOrder", "Restaurant_RestaurantId", "dbo.Restaurant", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOrder", "Restaurant_RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Restock", "StockOrderId", "dbo.StockOrder");
            DropForeignKey("dbo.Restock", "StockItemId", "dbo.StockItem");
            DropIndex("dbo.Restock", new[] { "StockItemId" });
            DropIndex("dbo.Restock", new[] { "StockOrderId" });
            DropIndex("dbo.StockOrder", new[] { "Restaurant_RestaurantId" });
            DropColumn("dbo.StockOrder", "Restaurant_RestaurantId");
            DropColumn("dbo.Restaurant", "StockOrderId");
            DropTable("dbo.Restock");
        }
    }
}

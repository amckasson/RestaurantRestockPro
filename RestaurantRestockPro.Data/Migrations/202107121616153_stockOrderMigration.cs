namespace RestaurantRestockPro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockOrderMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockOrder", "Restaurant_RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.StockOrder", new[] { "Restaurant_RestaurantId" });
            CreateTable(
                "dbo.StockOrderRestaurant",
                c => new
                    {
                        StockOrder_StockOrderId = c.Int(nullable: false),
                        Restaurant_RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StockOrder_StockOrderId, t.Restaurant_RestaurantId })
                .ForeignKey("dbo.StockOrder", t => t.StockOrder_StockOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.Restaurant_RestaurantId, cascadeDelete: true)
                .Index(t => t.StockOrder_StockOrderId)
                .Index(t => t.Restaurant_RestaurantId);
            
            AddColumn("dbo.StockOrder", "RestaurantId", c => c.Int(nullable: false));
            DropColumn("dbo.StockOrder", "Restaurant_RestaurantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockOrder", "Restaurant_RestaurantId", c => c.Int());
            DropForeignKey("dbo.StockOrderRestaurant", "Restaurant_RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.StockOrderRestaurant", "StockOrder_StockOrderId", "dbo.StockOrder");
            DropIndex("dbo.StockOrderRestaurant", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.StockOrderRestaurant", new[] { "StockOrder_StockOrderId" });
            DropColumn("dbo.StockOrder", "RestaurantId");
            DropTable("dbo.StockOrderRestaurant");
            CreateIndex("dbo.StockOrder", "Restaurant_RestaurantId");
            AddForeignKey("dbo.StockOrder", "Restaurant_RestaurantId", "dbo.Restaurant", "RestaurantId");
        }
    }
}

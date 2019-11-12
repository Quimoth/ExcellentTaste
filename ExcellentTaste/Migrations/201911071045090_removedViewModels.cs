namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedViewModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", "dbo.ProductOrderModel");
            DropIndex("dbo.ProductOrderModel", new[] { "KitchenViewModel_ProductOrderId" });
            DropColumn("dbo.ProductOrderModel", "Discriminator");
            DropColumn("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", c => c.Int());
            AddColumn("dbo.ProductOrderModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId");
            AddForeignKey("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", "dbo.ProductOrderModel", "ProductOrderId");
        }
    }
}

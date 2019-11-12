namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrderModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", c => c.Int());
            CreateIndex("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId");
            AddForeignKey("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", "dbo.ProductOrderModel", "ProductOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId", "dbo.ProductOrderModel");
            DropIndex("dbo.ProductOrderModel", new[] { "KitchenViewModel_ProductOrderId" });
            DropColumn("dbo.ProductOrderModel", "KitchenViewModel_ProductOrderId");
            DropColumn("dbo.ProductOrderModel", "Discriminator");
        }
    }
}

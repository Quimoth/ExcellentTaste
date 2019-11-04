namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderadjusted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.TableModel", "OrderViewModel_OrderId", c => c.Int());
            CreateIndex("dbo.TableModel", "OrderViewModel_OrderId");
            AddForeignKey("dbo.TableModel", "OrderViewModel_OrderId", "dbo.OrderModel", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableModel", "OrderViewModel_OrderId", "dbo.OrderModel");
            DropIndex("dbo.TableModel", new[] { "OrderViewModel_OrderId" });
            DropColumn("dbo.TableModel", "OrderViewModel_OrderId");
            DropColumn("dbo.OrderModel", "Discriminator");
        }
    }
}

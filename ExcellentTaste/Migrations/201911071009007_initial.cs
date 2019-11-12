namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderModel",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        TimeStamp = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.ProductModel",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ProductType = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        OrderViewModel_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.OrderModel", t => t.OrderViewModel_OrderId)
                .Index(t => t.OrderViewModel_OrderId);
            
            CreateTable(
                "dbo.TableModel",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        TableStatus = c.Int(nullable: false),
                        OrderViewModel_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.TableId)
                .ForeignKey("dbo.OrderModel", t => t.OrderViewModel_OrderId)
                .Index(t => t.OrderViewModel_OrderId);
            
            CreateTable(
                "dbo.ProductOrderModel",
                c => new
                    {
                        ProductOrderId = c.Int(nullable: false, identity: true),
                        ProductOrderStatus = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                        OrderModel_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductOrderId)
                .ForeignKey("dbo.ProductModel", t => t.Product_ProductId)
                .ForeignKey("dbo.OrderModel", t => t.OrderModel_OrderId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.OrderModel_OrderId);
            
            CreateTable(
                "dbo.UserModel",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OrderModelTableModel",
                c => new
                    {
                        OrderModel_OrderId = c.Int(nullable: false),
                        TableModel_TableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderModel_OrderId, t.TableModel_TableId })
                .ForeignKey("dbo.OrderModel", t => t.OrderModel_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.TableModel", t => t.TableModel_TableId, cascadeDelete: true)
                .Index(t => t.OrderModel_OrderId)
                .Index(t => t.TableModel_TableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableModel", "OrderViewModel_OrderId", "dbo.OrderModel");
            DropForeignKey("dbo.OrderModelTableModel", "TableModel_TableId", "dbo.TableModel");
            DropForeignKey("dbo.OrderModelTableModel", "OrderModel_OrderId", "dbo.OrderModel");
            DropForeignKey("dbo.ProductOrderModel", "OrderModel_OrderId", "dbo.OrderModel");
            DropForeignKey("dbo.ProductOrderModel", "Product_ProductId", "dbo.ProductModel");
            DropForeignKey("dbo.ProductModel", "OrderViewModel_OrderId", "dbo.OrderModel");
            DropIndex("dbo.OrderModelTableModel", new[] { "TableModel_TableId" });
            DropIndex("dbo.OrderModelTableModel", new[] { "OrderModel_OrderId" });
            DropIndex("dbo.ProductOrderModel", new[] { "OrderModel_OrderId" });
            DropIndex("dbo.ProductOrderModel", new[] { "Product_ProductId" });
            DropIndex("dbo.TableModel", new[] { "OrderViewModel_OrderId" });
            DropIndex("dbo.ProductModel", new[] { "OrderViewModel_OrderId" });
            DropTable("dbo.OrderModelTableModel");
            DropTable("dbo.UserModel");
            DropTable("dbo.ProductOrderModel");
            DropTable("dbo.TableModel");
            DropTable("dbo.ProductModel");
            DropTable("dbo.OrderModel");
        }
    }
}

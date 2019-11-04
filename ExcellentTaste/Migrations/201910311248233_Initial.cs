namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                    })
                .PrimaryKey(t => t.OrderId);
            
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
                "dbo.ProductModel",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ProductType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.TableModel",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        TableStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableId);
            
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
                "dbo.TableModelOrderModel",
                c => new
                    {
                        TableModel_TableId = c.Int(nullable: false),
                        OrderModel_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TableModel_TableId, t.OrderModel_OrderId })
                .ForeignKey("dbo.TableModel", t => t.TableModel_TableId, cascadeDelete: true)
                .ForeignKey("dbo.OrderModel", t => t.OrderModel_OrderId, cascadeDelete: true)
                .Index(t => t.TableModel_TableId)
                .Index(t => t.OrderModel_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableModelOrderModel", "OrderModel_OrderId", "dbo.OrderModel");
            DropForeignKey("dbo.TableModelOrderModel", "TableModel_TableId", "dbo.TableModel");
            DropForeignKey("dbo.ProductOrderModel", "OrderModel_OrderId", "dbo.OrderModel");
            DropForeignKey("dbo.ProductOrderModel", "Product_ProductId", "dbo.ProductModel");
            DropIndex("dbo.TableModelOrderModel", new[] { "OrderModel_OrderId" });
            DropIndex("dbo.TableModelOrderModel", new[] { "TableModel_TableId" });
            DropIndex("dbo.ProductOrderModel", new[] { "OrderModel_OrderId" });
            DropIndex("dbo.ProductOrderModel", new[] { "Product_ProductId" });
            DropTable("dbo.TableModelOrderModel");
            DropTable("dbo.UserModel");
            DropTable("dbo.TableModel");
            DropTable("dbo.ProductModel");
            DropTable("dbo.ProductOrderModel");
            DropTable("dbo.OrderModel");
        }
    }
}

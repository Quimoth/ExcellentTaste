namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModel", "ProductString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderModel", "ProductString");
        }
    }
}

namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        CreatedDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        Brand_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.ShoesStyles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoesStyleShoes",
                c => new
                    {
                        ShoesStyle_Id = c.Guid(nullable: false),
                        Shoes_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoesStyle_Id, t.Shoes_Id })
                .ForeignKey("dbo.ShoesStyles", t => t.ShoesStyle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Shoes", t => t.Shoes_Id, cascadeDelete: true)
                .Index(t => t.ShoesStyle_Id)
                .Index(t => t.Shoes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoesStyleShoes", "Shoes_Id", "dbo.Shoes");
            DropForeignKey("dbo.ShoesStyleShoes", "ShoesStyle_Id", "dbo.ShoesStyles");
            DropForeignKey("dbo.Shoes", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.ShoesStyleShoes", new[] { "Shoes_Id" });
            DropIndex("dbo.ShoesStyleShoes", new[] { "ShoesStyle_Id" });
            DropIndex("dbo.Shoes", new[] { "Brand_Id" });
            DropTable("dbo.ShoesStyleShoes");
            DropTable("dbo.ShoesStyles");
            DropTable("dbo.Shoes");
            DropTable("dbo.Brands");
        }
    }
}

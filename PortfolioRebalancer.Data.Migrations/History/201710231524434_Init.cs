namespace PortfolioRebalancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                        ModelId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        ModelId = c.String(nullable: false, maxLength: 36),
                        RregulationId = c.String(nullable: false, maxLength: 36),
                        Ratio = c.Double(nullable: false),
                        Regulation_Id = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => new { t.ModelId, t.RregulationId })
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Regulations", t => t.Regulation_Id)
                .Index(t => t.ModelId)
                .Index(t => t.Regulation_Id);
            
            CreateTable(
                "dbo.Regulations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        HouseholdId = c.String(maxLength: 36),
                        RegulationId = c.String(maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Households", t => t.HouseholdId)
                .ForeignKey("dbo.Regulations", t => t.RegulationId)
                .Index(t => t.HouseholdId)
                .Index(t => t.RegulationId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        PortfolioId = c.String(maxLength: 36),
                        StockId = c.String(maxLength: 36),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId)
                .ForeignKey("dbo.Stocks", t => t.StockId)
                .Index(t => t.PortfolioId)
                .Index(t => t.StockId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Symbol = c.String(nullable: false, maxLength: 5),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rules", "Regulation_Id", "dbo.Regulations");
            DropForeignKey("dbo.Portfolios", "RegulationId", "dbo.Regulations");
            DropForeignKey("dbo.Positions", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Positions", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Rules", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Households", "ModelId", "dbo.Models");
            DropIndex("dbo.Positions", new[] { "StockId" });
            DropIndex("dbo.Positions", new[] { "PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "RegulationId" });
            DropIndex("dbo.Portfolios", new[] { "HouseholdId" });
            DropIndex("dbo.Rules", new[] { "Regulation_Id" });
            DropIndex("dbo.Rules", new[] { "ModelId" });
            DropIndex("dbo.Households", new[] { "ModelId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Positions");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Regulations");
            DropTable("dbo.Rules");
            DropTable("dbo.Models");
            DropTable("dbo.Households");
        }
    }
}

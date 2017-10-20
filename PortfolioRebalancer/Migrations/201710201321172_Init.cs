namespace PortfolioRebalancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseholdModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        HouseholdModelId = c.String(maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HouseholdModels", t => t.HouseholdModelId)
                .Index(t => t.HouseholdModelId);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        HouseholdId = c.String(maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                        PortfolioModelId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Households", t => t.HouseholdId)
                .ForeignKey("dbo.PortfolioModels", t => t.PortfolioModelId)
                .Index(t => t.HouseholdId)
                .Index(t => t.PortfolioModelId);
            
            CreateTable(
                "dbo.PortfolioModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelMaps",
                c => new
                    {
                        HouseholdModelId = c.String(nullable: false, maxLength: 36),
                        PortfolioModelId = c.String(nullable: false, maxLength: 36),
                        Ratio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseholdModelId, t.PortfolioModelId })
                .ForeignKey("dbo.HouseholdModels", t => t.HouseholdModelId, cascadeDelete: true)
                .ForeignKey("dbo.PortfolioModels", t => t.PortfolioModelId, cascadeDelete: true)
                .Index(t => t.HouseholdModelId)
                .Index(t => t.PortfolioModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Portfolios", "PortfolioModelId", "dbo.PortfolioModels");
            DropForeignKey("dbo.ModelMaps", "PortfolioModelId", "dbo.PortfolioModels");
            DropForeignKey("dbo.ModelMaps", "HouseholdModelId", "dbo.HouseholdModels");
            DropForeignKey("dbo.Portfolios", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Households", "HouseholdModelId", "dbo.HouseholdModels");
            DropIndex("dbo.ModelMaps", new[] { "PortfolioModelId" });
            DropIndex("dbo.ModelMaps", new[] { "HouseholdModelId" });
            DropIndex("dbo.Portfolios", new[] { "PortfolioModelId" });
            DropIndex("dbo.Portfolios", new[] { "HouseholdId" });
            DropIndex("dbo.Households", new[] { "HouseholdModelId" });
            DropTable("dbo.ModelMaps");
            DropTable("dbo.PortfolioModels");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Households");
            DropTable("dbo.HouseholdModels");
        }
    }
}

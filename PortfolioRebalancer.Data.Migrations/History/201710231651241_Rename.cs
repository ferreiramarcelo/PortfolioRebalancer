namespace PortfolioRebalancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rules", "Regulation_Id", "dbo.Regulations");
            DropIndex("dbo.Rules", new[] { "Regulation_Id" });
            RenameColumn(table: "dbo.Rules", name: "Regulation_Id", newName: "RegulationId");
            DropPrimaryKey("dbo.Rules");
            AlterColumn("dbo.Rules", "RegulationId", c => c.String(nullable: false, maxLength: 36));
            AddPrimaryKey("dbo.Rules", new[] { "ModelId", "RegulationId" });
            CreateIndex("dbo.Rules", "RegulationId");
            AddForeignKey("dbo.Rules", "RegulationId", "dbo.Regulations", "Id", cascadeDelete: true);
            DropColumn("dbo.Rules", "RregulationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rules", "RregulationId", c => c.String(nullable: false, maxLength: 36));
            DropForeignKey("dbo.Rules", "RegulationId", "dbo.Regulations");
            DropIndex("dbo.Rules", new[] { "RegulationId" });
            DropPrimaryKey("dbo.Rules");
            AlterColumn("dbo.Rules", "RegulationId", c => c.String(maxLength: 36));
            AddPrimaryKey("dbo.Rules", new[] { "ModelId", "RregulationId" });
            RenameColumn(table: "dbo.Rules", name: "RegulationId", newName: "Regulation_Id");
            CreateIndex("dbo.Rules", "Regulation_Id");
            AddForeignKey("dbo.Rules", "Regulation_Id", "dbo.Regulations", "Id");
        }
    }
}

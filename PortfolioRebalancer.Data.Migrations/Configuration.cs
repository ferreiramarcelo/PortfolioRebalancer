namespace PortfolioRebalancer.Data.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Infrastructure.Annotations;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using TestData;

	internal sealed class Configuration : DbMigrationsConfiguration<AppDataContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			MigrationsDirectory = "History";
		}

		///<summary>
		///This method will be called after migrating to the latest version.
		///
		///You can use the DbSet<T>.AddOrUpdate() helper extension method 
		///to avoid creating duplicate seed data. E.g.
		///
		///  context.People.AddOrUpdate(
		///    p => p.FullName,
		///    new Person { FullName = "Andrew Peters" },
		///    new Person { FullName = "Brice Lambson" },
		///    new Person { FullName = "Rowan Miller" }
		///  );
		///</summary>
		///<param name="context">Db Context</param>
		protected override void Seed(AppDataContext context)
		{
			context.Regulations.RemoveRange(context.Regulations);
			context.Models.RemoveRange(context.Models);
			context.Rules.RemoveRange(context.Rules);
			context.Portfolios.RemoveRange(context.Portfolios);
			context.Households.RemoveRange(context.Households);

			context.SaveChanges();

			var regulations = DataGenerator.CreateRegulations(7);
			var models = DataGenerator.CreateModels(1);
			var households = DataGenerator.CreateHouseholds(1, models, regulations);
			var portfolios = DataGenerator.CreatePortfolios(households);

			context.Regulations.AddOrUpdate(regulations);
			context.Models.AddOrUpdate(models);
			context.Households.AddOrUpdate(households.ToArray());
			context.Portfolios.AddOrUpdate(portfolios);

			var singleReg = new Regulation
			{
				Id = Guid.Empty.ToString(),
				Name = "Single Portfolio"
			};

			var singlModel = new Model
			{
				Id = Guid.Empty.ToString(),
				Name = "Single Portfolio"
			};

			var singleRule = new Rule {ModelId = singlModel.Id, RegulationId = singleReg.Id, Ratio = 1};

			var singleHh = new Household
			{
				Id = Guid.Empty.ToString(),
				Name = "Single Portfolio",
				ModelId = singlModel.Id
			};

			//context.Regulations.AddOrUpdate(singleReg);
			//context.Models.AddOrUpdate(singlModel);
			//context.Rules.AddOrUpdate(singleRule);
			//context.Households.AddOrUpdate(singleHh);

			context.Portfolios.AddOrUpdate(DataGenerator.CreatePortfolios(15));
		}
	}
}

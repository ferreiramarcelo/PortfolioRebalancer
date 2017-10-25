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

		protected override void Seed(AppDataContext context)
		{

			context.Regulations.RemoveRange(context.Regulations);
			context.Models.RemoveRange(context.Models);
			context.Rules.RemoveRange(context.Rules);
			context.Households.RemoveRange(context.Households);

			context.SaveChanges();

			var regulations = context.Add
			(
				7,
				index => new Regulation
				{
					Id = DataGenerator.CreateId(),
					Name = $"Regulation {index + 1}"
				},
				regulation => regulation.Name
			);

			var models = context.Add
			(
				5,
				index =>
				{
					Model model = new Model
					{
						Id = DataGenerator.CreateId(),
						Name = $"Model {index + 1}"
					};

					return model;
				},
				model => model.Name
			);

			var random = new Random();

			var min = 2;
			var max = regulations.Length + 1;

			var households = new List<Household>();

			foreach (var model in models)
			{
				foreach (var regulation in regulations.Take(random.Next(min, max)).ToArray())
				{
					var rule = new Rule { ModelId = model.Id , RegulationId = regulation.Id};
					model.Rules.Add(rule);
				}

				for (var index = 0; index < 5; index++)
				{
					var household = new Household
					{
						Id = DataGenerator.CreateId(),
						Name = $"Household {index + households.Count + 1}",
						ModelId = model.Id
					};

					households.Add(household);
				}
			}

			context.Households.AddOrUpdate(households.ToArray());

			//var regulations = DataGenerator.CreateRegulation(7);
			//var models = DataGenerator.CreateModels(5, regulations);
			//context.Models.AddOrUpdate(models);

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}

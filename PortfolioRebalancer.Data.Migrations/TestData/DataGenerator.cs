namespace PortfolioRebalancer.Data.Migrations.TestData
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;

	public static class DataGenerator
	{
		public static string CreateId()
		{
			return Guid.NewGuid().ToString("D");
		}

		public static Regulation[] CreateRegulations(int count)
		{
			var regulations = new Regulation[count];

			for (var index = 0; index < count; index++)
			{
				regulations[index] = new Regulation
				{
					Id = DataGenerator.CreateId(),
					Name = $"Regulation {index + 1}"
				};
			}

			return regulations;
		}

		public static Model[] CreateModels(int count, params Regulation[] regulations)
		{
			var models = new Model[count];

			for (var index = 0; index < count; index++)
			{
				models[index] = new Model
				{
					Id = DataGenerator.CreateId(),
					Name = $"Model {index + 1}"
				};
			}
			return models;
		}

		public static Household[] CreateHouseholds(int countPerModel, Model[] models, Regulation[] regulations)
		{
			var random = new Random();

			var min = 2;
			var max = regulations.Length + 1;

			var households = new List<Household>();

			foreach (var model in models)
			{
				foreach (var regulation in regulations.Take(random.Next(min, max)).ToArray())
				{
					var rule = new Rule { ModelId = model.Id, RegulationId = regulation.Id };
					model.Rules.Add(rule);
				}

				for (var index = 0; index < countPerModel; index++)
				{
					var household = new Household
					{
						Id = DataGenerator.CreateId(),
						Name = $"Household {households.Count + 1}",
						Model = model
					};

					households.Add(household);
				}
			}

			return households.ToArray();
		}

		public static Portfolio[] CreatePortfolios(Household[] households)
		{
			var portfolios = new List<Portfolio>();

			foreach (var household in households)
			{
				foreach (var rule in household.Model.Rules)
				{
					var portfolio = CreatePortfolio(household, rule);
					portfolios.Add(portfolio);
				}
			}

			return portfolios.ToArray();
		}

		public static Portfolio CreatePortfolio(Household household = null, Rule rule = null)
		{
			var portfolioId = CreateId();

			var portfolio = new Portfolio
			{
				Id = portfolioId,
				Name = $"Portfolio {portfolioId.Substring(0, 8)}",
				HouseholdId = household?.Id ?? Guid.Empty.ToString(),
				RegulationId = rule?.RegulationId ?? Guid.Empty.ToString()
			};

			return portfolio;
		}

		public static Portfolio[] CreatePortfolios(int count)
		{
			var portfolios = new Portfolio[count];

			for (int index = 0; index < count; index++)
			{
				portfolios[index] = CreatePortfolio();
			}

			return portfolios;
		}

	}
}

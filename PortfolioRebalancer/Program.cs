namespace PortfolioRebalancer
{
	using System;
	using System.Collections.Generic;
	using Data;
	using System.Linq;

	class Program
	{
		private static readonly Random _random = new Random();

		static void Main(string[] args)
		{

			var portfolioModels = CreatePortfolioModels(7);
			var householdModels = CreateHouseholdModels(5, portfolioModels);
			var households = CreateHouseholds(5, householdModels);
			var portfolioses = CreatePortfolios(households).ToArray();

			//var portfoliosWithoutHousehold = CreatePortfoliosWithoutHousehold(count: 10);

			using (var db = new AppDataContext())
			{
				db.HouseholdModels.AddRange(householdModels);
				db.SaveChanges();
			}
		}

		private static Portfolio[] CreatePortfoliosWithoutHousehold(int count)
		{
			var portfolios = new Portfolio[count];

			for (int index = 0; index < count; index++)
			{
				var portfolioId = AppDataContext.NewId();

				var newPortfolio = new Portfolio
				{
					Id = portfolioId,
					Name = $"Portfolio {portfolioId.Substring(0, 8)}"
				};

				portfolios[index] = newPortfolio;
			}

			return portfolios;
		}

		private static PortfolioModel[] CreatePortfolioModels(int count)
		{
			var portfolioModels = new PortfolioModel[count];

			for (int index = 0; index < count; index++)
			{
				var portfolioModelId = AppDataContext.NewId();

				var portfolioModel = new PortfolioModel
				{
					Id = portfolioModelId,
					Name = $"PModel {portfolioModelId.Substring(0, 8)}"
				};

				portfolioModels[index] = portfolioModel;
			}

			return portfolioModels;
		}

		private static HouseholdModel[] CreateHouseholdModels(int count, PortfolioModel[] portfolioModels)
		{

			var householdModels = new HouseholdModel[count];

			for (var index = 0; index < count; index++)
			{
				var skip = _random.Next(0, portfolioModels.Length / 2);
				var take = _random.Next(2, portfolioModels.Length - skip);
				var section = portfolioModels.Skip(skip).Take(take).ToArray();

				var householdModelId = AppDataContext.NewId();
				var householdModel = new HouseholdModel
				{
					Id = householdModelId,
					Name = $"HhModel {householdModelId.Substring(0, 8)}",
				};

				foreach (var portfolioModel in section)
				{
					householdModel.ModelMaps.Add(new ModelMap { HouseholdModel = householdModel, HouseholdModelId = householdModelId, PortfolioModelId = portfolioModel.Id, PortfolioModel = portfolioModel });
				}

				householdModels[index] = householdModel;
			}

			return householdModels;
		}

		private static Household[] CreateHouseholds(int count, HouseholdModel[] householdModels)
		{
			var households = new List<Household>(count * householdModels.Length);

			foreach (var householdModel in householdModels)
			{
				for (int index = 0; index < count; index++)
				{
					var hoseholdId = AppDataContext.NewId();

					var household = new Household
					{
						Id = hoseholdId,
						Name = $"Household {hoseholdId.Substring(0, 8)}",
						HouseholdModel = householdModel,
						HouseholdModelId=householdModel.Id
					};

					householdModel.Households.Add(household);
					households.Add(household);
				}
			}

			return households.ToArray();
		}

		private static IEnumerable<Portfolio[]> CreatePortfolios(Household[] households)
		{
			foreach (var household in households)
			{
				var portfolios = CreatePortfoliosWithoutHousehold(household.HouseholdModel.ModelMaps.Count);

				foreach (var map in household.HouseholdModel.ModelMaps)
				{
					var portfolioId = AppDataContext.NewId();

					var portfolio = new Portfolio
					{
						Name = $"Portfolio {portfolioId.Substring(0, 8)}",
						Id = portfolioId,
						PortfolioModel = map.PortfolioModel,
						PortfolioModelId = map.PortfolioModelId,
						Household = household,
						HouseholdId = household.Id
					};

					household.Portfolios.Add(portfolio);
				}

				yield return portfolios;
			}
		}
	}
}

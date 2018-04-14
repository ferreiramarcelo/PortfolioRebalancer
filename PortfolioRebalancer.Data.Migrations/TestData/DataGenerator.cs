namespace PortfolioRebalancer.Data.Migrations.TestData
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using LinqToExcel;

	public static class DataGenerator
	{
		class SecurityComparer : IEqualityComparer<Security>
		{
			public bool Equals(Security x, Security y)
			{
				return string.Compare(x?.Symbol, y?.Symbol, StringComparison.Ordinal) == 0;
			}

			public int GetHashCode(Security obj)
			{
				return obj.Symbol.GetHashCode();
			}
		}

		private static readonly HashSet<Security> Storage = new HashSet<Security>(new SecurityComparer());

		private static Random random = new Random();

		static DataGenerator()
		{
			Parallel.Invoke(() => AddToStorage("companylist"),
				() => AddToStorage("companylist (1)"),
				() => AddToStorage("companylist (2)"),
				() => AddToStorage("companylist (3)"));
		}

		public static string CreateId()
		{
			return Guid.NewGuid().ToString("D");
		}

		public static Model[] CreateModels(int count)
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

		public static Household[] CreateHouseholds(int countPerModel, Model[] models, Regulation[] regulations)
		{
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

		public static Portfolio[] CreatePortfolios(int count)
		{
			var portfolios = new Portfolio[count];

			for (int index = 0; index < count; index++)
			{
				portfolios[index] = CreatePortfolio();
			}

			return portfolios;
		}

		public static Portfolio CreatePortfolio(Household household = null, Rule rule = null)
		{
			var portfolioId = CreateId();

			var portfolio = new Portfolio
			{
				Id = portfolioId,
				Name = $"Portfolio {portfolioId.Substring(0, 8)}",
				HouseholdId = household?.Id,
				RegulationId = rule?.RegulationId,
			};

			portfolio.Positions = CreatePositions(portfolio);

			return portfolio;
		}

		public static Position[] CreatePositions(Portfolio portfolio)
		{
			random = new Random();
			var positionsCount = random.Next(5, 11);
			var positions = new Position[positionsCount];

			for (var i = 0; i < positions.Length; i++)
			{
				var security = GetSecurity(positions);

				positions[i] = new Position();
				var position = positions[i];
				position.Id = CreateId();
				position.SecurityId = security.Id;
				position.PortfolioId = portfolio.Id;
			}

			return positions;
		}

		private static Security GetSecurity(Position[] positions)
		{
			Security security;
			do
			{
				security = Storage.Skip(random.Next(Storage.Count)).Take(1).Single();

			} while (positions.Any(p => p != null && p.Security.Symbol == security.Symbol));

			return security;
		}

		public static IEnumerable<Security> GetSecurities()
		{
			return Storage;
		}

		private static void AddToStorage(string fileName)
		{
			string pathToExcelFile = $@".\{fileName}.xls";
			var excelFile = new ExcelQueryFactory(pathToExcelFile);
			excelFile.AddMapping<Security>(item => item.Price, "LastSale");

			foreach (var ticker in from ticker in excelFile.Worksheet<Security>(fileName) select ticker)
			{
				var context = new ValidationContext(ticker, null, null);
				var results = new Collection<ValidationResult>();

				if (!Validator.TryValidateObject(ticker, context, results, true))
				{
					foreach (var result in results)
					{
						Trace.WriteLine($@"{string.Join(",", result.MemberNames)} {result.ErrorMessage}");
					}

					continue;
				}

				lock (Storage)
				{
					if (Storage.Add(ticker))
					{
						ticker.Id = CreateId();
					}
				}
			}
		}
	}
}

namespace PortfolioRebalancer.Data.Migrations.TestData
{
	using System;
	using System.Linq;

	public static class DataGenerator
	{
		public static string CreateId()
		{
			return Guid.NewGuid().ToString("D");
		}

		public static Regulation[] CreateRegulation(int count)
		{
			var regulations = new Regulation[count];

			for (int index = 0; index < count; index++)
			{
				regulations[index] = new Regulation
				{
					Id = CreateId(),
					Name = $"{nameof(Regulation)} - {index + 1}"
				};
			}

			return regulations;
		}

		public static Model[] CreateModels(int count, params Regulation[] regulations)
		{
			var models = new Model[count];

			var random = new Random();

			for (int index = 0; index < count; index++)
			{
				var regulationCount = random.Next(2, regulations.Length + 1);

				var modelId = CreateId();

				var model = new Model
				{
					Id = modelId,
					Name = $"Model - { index + 1}",
				};

				models[index] = model;

				AddRulesToModel(model, regulations.Take(regulationCount).ToArray());
			}

			return models;
		}

		public static void AddRulesToModel(Model model, params Regulation[] regulations)
		{
			foreach (var regulation in regulations)
			{
				var rule = new Rule
				{
					ModelId = model.Id,
					Model = model,
					RegulationId = regulation.Id,
					Regulation = regulation,
					Ratio = 0
				};

				model.Rules.Add(rule);
			}
		}


	}
}

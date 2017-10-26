namespace PortfolioRebalancer
{
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Data;

	class Program
	{
		static void Main(string[] args)
		{
			object portfolios;

			using (var db = new AppDataContext())
			{
				portfolios = db.Portfolios
					.AsNoTracking()
					.Include(p => p.Household)
					.Select(portfolio => new
					{
						portfolio.Id,
						portfolio.Name,
						HhId = portfolio.Household.Id,
						HhName = portfolio.Household.Name,
						ModelName = portfolio.Household.Model.Name,
						x = portfolio.Household.Model.Rules
					}).ToList();
			}
		}
	}
}

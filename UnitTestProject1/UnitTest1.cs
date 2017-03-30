namespace UnitTestProject1
{
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using PortfolioRebalancer.Models;

	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var container = new List<RebalanceItemContainerBase>();

			Household household = new Household();
			household.Add(new Portfolio());

			container.Add(household);

			Position cash = new Cash(1500.5m);
			Position mutualFund = new MutualFund("MMX", 2800.2m);
			Portfolio portfolio = new Portfolio();

			portfolio.Add(cash);
			portfolio.Add(mutualFund);

			container.Add(portfolio);

			//container.Add(new Position());

			var households = container.Where(item => item.Type == NodeType.Household).ToArray();

			var portfolios = container.Where(item => item.Type == NodeType.Portfolio).ToArray();

			foreach (RebalanceItem item in container)
			{
				
			}

		}
	}
}

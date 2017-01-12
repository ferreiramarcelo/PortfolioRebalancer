namespace UnitTestProject1
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using PortfolioRebalancer.Models;

	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Container container = new Container();
			Household household = new Household();
			household.Add(new Portfolio());

			Position position = new Position();
			Portfolio portfolio = new Portfolio();
			portfolio.Add(position);
			container.Add(portfolio);

			

		}
	}
}

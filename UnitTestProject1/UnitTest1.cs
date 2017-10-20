namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PortfolioRebalancer.Models.Abstraction;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var household = ItemContainerBase.CreateHousehold();
            var portfolio1 = ItemContainerBase.CreatePortfolio();
            household.Add(portfolio1);

            portfolio1.Add(Position.CreateCash(1500m));
            portfolio1.Add(Position.CreateMutualFund("MMX", 2500m));
            portfolio1.Add(Position.CreateStock(200, new Security("GOOG", 18.5m)));

            var portfolio2 = ItemContainerBase.CreatePortfolio();
            var portfolio3 = ItemContainerBase.CreatePortfolio();

            household.Add(portfolio1);
            household.Add(portfolio2);

            var container = new List<ItemContainerBase>();
            container.Add(household);
            container.Add(portfolio3);

            //Household household = new Household();
            //household.Add(new Portfolio());

            //container.Add(household);

            //Position cash = new Cash(1500.5m);
            //Position mutualFund = new MutualFund("MMX", 2800.2m);
            //Portfolio portfolio = new Portfolio();

            //portfolio.Add(cash);
            //portfolio.Add(mutualFund);

            //container.Add(portfolio);

            ////container.Add(new Position());

            //var households = container.Where(item => item.Type == NodeType.Household).ToArray();

            //var portfolios = container.Where(item => item.Type == NodeType.Portfolio).ToArray();

            foreach (Item item in container)
            {

            }
        }
    }
}

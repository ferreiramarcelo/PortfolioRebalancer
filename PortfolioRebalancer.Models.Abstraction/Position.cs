namespace PortfolioRebalancer.Models.Abstraction
{
	using System;

	public class Position : Item
	{
		public Position(Portfolio portfolio, int quantity)
		{

			if (Portfolio == null)
			{
				throw new ArgumentNullException(nameof(portfolio));
			}

			Portfolio = portfolio;
			Quantity = quantity;
		}

		public int Quantity { get; }

		public Portfolio Portfolio { get; }
	}
}

namespace PortfolioRebalancer.Models.Abstraction
{
	public class Security
	{
		public Security(string symbol, decimal price)
		{
			Symbol = symbol;
			Price = price;
		}

		public string Symbol { get; }

		public decimal Price { get; }
	}
}
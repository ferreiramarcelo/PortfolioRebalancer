namespace PortfolioRebalancer.Models
{
	public class Stock : Position
	{
		public Stock(int quantity, Security security)
			: base(NodeType.Stock, quantity, security)
		{
		}
	}
}
namespace PortfolioRebalancer.Models
{
	public class Cash : SinglePosition
	{
		public Cash(decimal price) : base(NodeType.Cash, new Security("Cash", price))
		{
		}
	}
}
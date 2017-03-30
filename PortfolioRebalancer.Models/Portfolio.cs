namespace PortfolioRebalancer.Models
{
	public class Portfolio : RebalanceItemContainer<Position>
	{
		public Portfolio() : base(NodeType.Portfolio)
		{
		}
	}
}

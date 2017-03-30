namespace PortfolioRebalancer.Models
{
	public sealed class Portfolio : RebalanceItemContainer<Position>
	{
		public Portfolio() : base(NodeType.Portfolio)
		{
		}
	}
}

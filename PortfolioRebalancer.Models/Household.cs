namespace PortfolioRebalancer.Models
{
	public sealed class Household : RebalanceItemContainer<Portfolio>
	{
		public Household() : base(NodeType.Household)
		{
		}

	}
}

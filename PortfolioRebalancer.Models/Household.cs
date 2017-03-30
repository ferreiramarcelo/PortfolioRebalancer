namespace PortfolioRebalancer.Models
{
	public class Household : RebalanceItemContainer<Portfolio>
	{
		public Household() : base(NodeType.Household)
		{
		}

	}
}

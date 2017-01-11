namespace PortfolioRebalancer.Models
{
	public abstract class RebalanceItemContainer : RebalanceItem
	{
		protected RebalanceItemContainer(NodeType type) : base(type)
		{
		}
	}
}

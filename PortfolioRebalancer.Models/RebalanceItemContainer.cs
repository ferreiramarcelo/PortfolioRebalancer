namespace PortfolioRebalancer.Models
{
	public abstract class RebalanceItemContainer<TItem> : RebalanceItemContainerBase
		where TItem : RebalanceItem
	{
		protected RebalanceItemContainer(NodeType type) : base(type)
		{
		}

		public void Add(TItem item)
		{
			base.Add(item);
		}
	}
}

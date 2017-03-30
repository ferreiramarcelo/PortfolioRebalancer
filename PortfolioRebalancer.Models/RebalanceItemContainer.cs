namespace PortfolioRebalancer.Models
{
	public abstract class RebalanceItemContainer<TItem> : RebalanceItemContainerBase, IRebalanceItemContainerManager<TItem>
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

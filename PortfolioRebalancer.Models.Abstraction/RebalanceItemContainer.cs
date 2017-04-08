namespace PortfolioRebalancer.Models.Abstraction
{
    public class RebalanceItemContainer<TItem> : RebalanceItemContainerBase
        where TItem : RebalanceItem
    {
        internal RebalanceItemContainer(NodeType type) : base(type)
        {
        }

        public void Add(TItem item)
        {
            base.Add(item);
        }
    }
}

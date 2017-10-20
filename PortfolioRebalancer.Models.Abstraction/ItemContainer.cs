namespace PortfolioRebalancer.Models.Abstraction
{
    public class ItemContainer<TItem> : ItemContainerBase
        where TItem : Item
    {
        internal ItemContainer(NodeType type) : base(type)
        {
        }

        public void Add(TItem item)
        {
            base.Add(item);
        }
    }
}

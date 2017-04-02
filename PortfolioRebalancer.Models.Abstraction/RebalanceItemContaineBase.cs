namespace PortfolioRebalancer.Models.Abstraction
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public abstract class RebalanceItemContainerBase : RebalanceItem, IEnumerable<RebalanceItem>
    {
        private readonly ICollection<RebalanceItem> _items;


        protected RebalanceItemContainerBase(NodeType type)
         : base(type)
        {
            _items = new Collection<RebalanceItem>();
        }

        internal virtual void Add(RebalanceItem item)
        {
            item.Owner = this;
            _items.Add(item);
        }

        public IEnumerator<RebalanceItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

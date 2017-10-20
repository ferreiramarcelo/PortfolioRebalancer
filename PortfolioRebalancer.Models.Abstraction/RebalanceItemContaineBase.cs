namespace PortfolioRebalancer.Models.Abstraction
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public abstract class ItemContainerBase : Item, IEnumerable<Item>
    {
        private readonly ICollection<Item> _items;


        public static ItemContainer<Position> CreatePortfolio()
        {
            return new ItemContainer<Position>(NodeType.Portfolio);
        }

        public static ItemContainer<ItemContainer<Position>> CreateHousehold()
        {
            return new ItemContainer<ItemContainer<Position>>(NodeType.Household);
        }

        internal ItemContainerBase(NodeType type)
         : base(type)
        {
            _items = new Collection<Item>();
        }

        internal void Add(Item item)
        {
            item.Owner = this;
            _items.Add(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

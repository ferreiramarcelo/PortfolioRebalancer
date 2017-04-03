namespace PortfolioRebalancer.Models.Abstraction
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public abstract class RebalanceItemContainerBase : RebalanceItem, IEnumerable<RebalanceItem>
	{
		private readonly ICollection<RebalanceItem> _items;


		public static RebalanceItemContainer<Position> CreatePortfolio()
		{
			return new RebalanceItemContainer<Position>(NodeType.Portfolio);
		}

		public static RebalanceItemContainer<RebalanceItemContainer<Position>> CreateHousehold()
		{
			return new RebalanceItemContainer<RebalanceItemContainer<Position>>(NodeType.Household);
		}

		internal RebalanceItemContainerBase(NodeType type)
		 : base(type)
		{
			_items = new Collection<RebalanceItem>();
		}

		internal void Add(RebalanceItem item)
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

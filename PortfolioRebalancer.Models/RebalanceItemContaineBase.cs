namespace PortfolioRebalancer.Models
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

		protected virtual void Add(RebalanceItem item)
		{
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

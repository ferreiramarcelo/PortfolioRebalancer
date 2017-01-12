namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public abstract class RebalanceItemContainer<TItem> : RebalanceItemContainerBase, IEnumerable<TItem>
		where TItem : RebalanceItem
	{
		protected RebalanceItemContainer(NodeType type) : base(type)
		{
			Items = new Collection<TItem>();
		}

		protected ICollection<TItem> Items { get; }

		public void Add(TItem item)
		{
			Items.Add(item);
		}

		public override IEnumerator<RebalanceItem> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}
}

namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public abstract class RebalanceItemContainer : RebalanceItem, IEnumerable, IEnumerable<RebalanceItem>
	{
		protected RebalanceItemContainer(NodeType type) : base(type)
		{
		}

		public abstract IEnumerator<RebalanceItem> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

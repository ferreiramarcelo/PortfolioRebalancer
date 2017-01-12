namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public abstract class RebalanceItemContainerBase : RebalanceItem, IEnumerable<RebalanceItem>
	{
		protected RebalanceItemContainerBase(NodeType type)
		 : base(type)
		{
		}

		public abstract IEnumerator<RebalanceItem> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

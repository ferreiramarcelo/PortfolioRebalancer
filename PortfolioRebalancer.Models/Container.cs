namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Container : IEnumerable, IEnumerable<RebalanceItemContainerBase>
	{
		private ICollection<RebalanceItemContainerBase> _container;

		public Container()
		{
			_container = new Collection<RebalanceItemContainerBase>();
		}

		public void Add(RebalanceItemContainerBase container)
		{
			_container.Add(container);
		}

		public IEnumerator<RebalanceItemContainerBase> GetEnumerator()
		{
			return _container.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

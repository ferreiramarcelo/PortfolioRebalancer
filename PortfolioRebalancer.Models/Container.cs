namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Container : IEnumerable, IEnumerable<RebalanceItemContainer>
	{
		private ICollection<RebalanceItemContainer> _container;

		public Container()
		{
			_container = new Collection<RebalanceItemContainer>();
		}

		public void Add(RebalanceItemContainer container)
		{
			_container.Add(container);
		}

		public IEnumerator<RebalanceItemContainer> GetEnumerator()
		{
			return _container.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

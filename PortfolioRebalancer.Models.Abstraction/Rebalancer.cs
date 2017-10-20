namespace PortfolioRebalancer.Models.Abstraction
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Rebalancer : IEnumerable<RebalanceItem>
	{
		private readonly ICollection<RebalanceItemContainerBase> _container;

		public Rebalancer()
		{
			_container = new Collection<RebalanceItemContainerBase>();
		}

		public RebalanceItemContainer<Position> CreatePortfolio()
		{
			var item = new RebalanceItemContainer<Position>(NodeType.Portfolio);
			_container.Add(item);
			return item;
		}

		public  RebalanceItemContainer<RebalanceItemContainer<Position>> CreateHousehold()
		{
			var item =  new RebalanceItemContainer<RebalanceItemContainer<Position>>(NodeType.Household);
			_container.Add(item);
			return item;
		}


		#region IEnumerable

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<RebalanceItem> GetEnumerator()
		{
			return _container.GetEnumerator();
		}

		#endregion
	}
}

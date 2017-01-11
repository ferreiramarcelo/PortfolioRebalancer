namespace PortfolioRebalancer.Models
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Household : RebalanceItemContainer, IEnumerable, IEnumerable<Portfolio>
	{
		public Household() : base(NodeType.Household)
		{
			Portfolios = new Collection<Portfolio>();
		}

		public ICollection<Portfolio> Portfolios { get; }

		public void Add(Portfolio portfolio)
		{
			Portfolios.Add(portfolio);
		}

		public IEnumerator<Portfolio> GetEnumerator()
		{
			return Portfolios.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

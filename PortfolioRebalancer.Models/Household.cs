namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Household : RebalanceItemContainer
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

		public override IEnumerator<RebalanceItem> GetEnumerator()
		{
			return Portfolios.GetEnumerator();
		}
	}
}

namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Portfolio : RebalanceItemContainer
	{
		public Portfolio() : base(NodeType.Portfolio)
		{
			Positions = new Collection<Position>();
		}

		public ICollection<Position> Positions { get; }

		public void Add(Position position)
		{
			Positions.Add(position);
		}

		public override IEnumerator<RebalanceItem> GetEnumerator()
		{
			return Positions.GetEnumerator();
		}
	}
}

namespace PortfolioRebalancer.Models
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Portfolio : RebalanceItemContainer, IEnumerable, IEnumerable<Position>
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

		public IEnumerator<Position> GetEnumerator()
		{
			return Positions.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Portfolio : RebalanceItemContainer<Position>
	{
		public Portfolio() : base(NodeType.Portfolio)
		{
		}
	}
}

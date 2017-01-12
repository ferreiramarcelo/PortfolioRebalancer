namespace PortfolioRebalancer.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class Household : RebalanceItemContainer<Portfolio>
	{
		public Household() : base(NodeType.Household)
		{
		}

	}
}

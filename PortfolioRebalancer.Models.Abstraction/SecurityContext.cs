namespace PortfolioRebalancer.Models.Abstraction
{
	using System;
	using System.Collections.Generic;

	public class SecurityContext : Item
	{
		public SecurityContext(Security security)
		{
			if (security == null)
			{
				throw new ArgumentNullException(nameof(security));
			}
		}

		public Security Security { get; set; }

		public IEnumerable<Item> Positions { get; set; }

	}
}
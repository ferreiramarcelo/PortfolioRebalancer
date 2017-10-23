namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Stock
	{
		public Stock()
		{
			Positions = new HashSet<Position>();
		}

		[StringLength(36)]
		public string Id { get; set; }

		[Required]
		[StringLength(5)]
		public string Symbol { get; set; }

		public decimal Price { get; set; }

		public virtual ICollection<Position> Positions { get; set; }
	}
}

namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Household
	{
		public Household()
		{
			Portfolios = new HashSet<Portfolio>();
		}

		[StringLength(36)]
		public string Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[StringLength(36)]
		public string ModelId { get; set; }

		public virtual Model Model { get; set; }

		public virtual ICollection<Portfolio> Portfolios { get; set; }
	}
}

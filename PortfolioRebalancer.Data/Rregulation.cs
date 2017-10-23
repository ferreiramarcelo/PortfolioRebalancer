namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Regulation
	{
		public Regulation()
		{
			Portfolios = new HashSet<Portfolio>();
			Rules = new HashSet<Rule>();
		}

		[StringLength(36)]
		public string Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public virtual ICollection<Portfolio> Portfolios { get; set; }

		public virtual ICollection<Rule> Rules { get; set; }
	}
}

namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Model
	{
		public Model()
		{
			Households = new HashSet<Household>();
			Rules = new HashSet<Rule>();
		}

		[StringLength(36)]
		public string Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public virtual ICollection<Household> Households { get; set; }

		public virtual ICollection<Rule> Rules { get; set; }
	}
}

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

		[StringLength(AppDataContext.IdLength)]
		public string Id { get; set; }

		[StringLength(AppDataContext.IdLength)]
		public string HouseholdModelId { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public virtual HouseholdModel HouseholdModel { get; set; }

		public virtual ICollection<Portfolio> Portfolios { get; set; }
	}
}

namespace PortfolioRebalancer.Data
{
	using System.ComponentModel.DataAnnotations;

	public class Portfolio
	{
		[StringLength(AppDataContext.IdLength)]
		public string Id { get; set; }

		[StringLength(AppDataContext.IdLength)]
		public string HouseholdId { get; set; }

		public virtual Household Household { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[StringLength(AppDataContext.IdLength)]
		public string PortfolioModelId { get; set; }

		public virtual PortfolioModel PortfolioModel { get; set; }
	}
}

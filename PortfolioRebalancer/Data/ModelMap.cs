namespace PortfolioRebalancer.Data
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ModelMap
	{
		[Key]
		[Column(Order = 0)]
		[StringLength(AppDataContext.IdLength)]
		public string HouseholdModelId { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(AppDataContext.IdLength)]
		public string PortfolioModelId { get; set; }

		public double Ratio { get; set; }

		public virtual HouseholdModel HouseholdModel { get; set; }

		public virtual PortfolioModel PortfolioModel { get; set; }
	}
}

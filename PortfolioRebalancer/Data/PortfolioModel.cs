namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class PortfolioModel
	{
		public PortfolioModel()
		{
			ModelMaps = new HashSet<ModelMap>();
		}

		[StringLength(AppDataContext.IdLength)]
		public string Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public virtual ICollection<ModelMap> ModelMaps { get; set; }
	}
}

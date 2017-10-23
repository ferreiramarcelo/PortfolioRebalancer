namespace PortfolioRebalancer.Data
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Portfolio
	{
		public Portfolio()
		{
			Positions = new HashSet<Position>();
		}

		[StringLength(36)]
		public string Id { get; set; }

		[StringLength(36)]
		public string HouseholdId { get; set; }

		public virtual Household Household { get; set; }

		[StringLength(36)]
		public string RegulationId { get; set; }

		public virtual Regulation Regulation { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		public virtual ICollection<Position> Positions { get; set; }
	}
}

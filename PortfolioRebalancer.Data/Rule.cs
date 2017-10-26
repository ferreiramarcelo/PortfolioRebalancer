namespace PortfolioRebalancer.Data
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Rule
	{
		[Key]
		[Column(Order = 0)]
		[StringLength(36)]
		public string ModelId { get; set; }

		public virtual Model Model { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(36)]
		public string RegulationId { get; set; }

		public virtual Regulation Regulation { get; set; }

		public double Ratio { get; set; }

	}
}

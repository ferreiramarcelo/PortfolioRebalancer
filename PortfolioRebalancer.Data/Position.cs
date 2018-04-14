namespace PortfolioRebalancer.Data
{
	using System.ComponentModel.DataAnnotations;

	public class Position
	{
		[StringLength(36)]
		public string Id { get; set; }

		[StringLength(36)]
		public string PortfolioId { get; set; }

		public virtual Portfolio Portfolio { get; set; }

		[StringLength(36)]
		public string SecurityId { get; set; }

		public virtual Security Security { get; set; }

		public int Quantity { get; set; }
	}
}

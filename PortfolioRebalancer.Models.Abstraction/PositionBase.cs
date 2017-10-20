namespace PortfolioRebalancer.Models.Abstraction
{
	public abstract class PositionBase
	{
		public Security Security { get; }

		public Owner Owner { get; set; }
	}
}
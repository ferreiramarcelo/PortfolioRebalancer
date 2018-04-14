namespace PortfolioRebalancer.ViewModels
{
	public class PortfolioViewModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string HouseholdId { get; set; }

		public HouseholdViewModel Household { get; set; }
	}
}

namespace PortfolioRebalancer.Models.Abstraction
{
	public interface IRebalanceItemContainerManager<TItem>
	{
		void Add(TItem item);
	}
}

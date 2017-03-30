namespace PortfolioRebalancer.Models
{
	public interface IRebalanceItemContainerManager<TItem>
	{
		void Add(TItem item);
	}
}

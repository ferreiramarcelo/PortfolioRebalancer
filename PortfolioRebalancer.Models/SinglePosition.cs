namespace PortfolioRebalancer.Models
{
	public abstract class SinglePosition : Position
	{
		protected SinglePosition(NodeType type, Security security)
			: base(type, 1, security)
		{
		}
	}
}
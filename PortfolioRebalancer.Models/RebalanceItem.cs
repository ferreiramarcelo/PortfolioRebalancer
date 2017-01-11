namespace PortfolioRebalancer.Models
{
	public abstract class RebalanceItem
	{
		protected RebalanceItem(NodeType type)
		{
			Type = type;
		}

		public NodeType Type { get;  }
	}
}

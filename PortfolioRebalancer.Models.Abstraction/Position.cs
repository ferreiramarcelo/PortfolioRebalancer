namespace PortfolioRebalancer.Models.Abstraction
{
	public abstract class Position : RebalanceItem
	{
		protected Position(NodeType type, int quantity, Security security) : base(type)
		{
			Quantity = quantity;
			Security = security;
		}

		public int Quantity { get; }

		public Security Security { get; }
	}
}

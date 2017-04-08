namespace PortfolioRebalancer.Models.Abstraction
{
    public class Position : RebalanceItem
    {
        public static Position CreateCash(decimal price)
        {
            return new Position(NodeType.Cash, 1, new Security("Cash", price));
        }

        public static Position CreateMutualFund(string symbol, decimal price)
        {
            return new Position(NodeType.MutualFund, 1, new Security(symbol, price));
        }

        public static Position CreateStock(int quantity, Security security)
        {
            return new Position(NodeType.Stock, quantity, security);
        }

        public Position(NodeType type, int quantity, Security security) : base(type)
        {
            Quantity = quantity;
            Security = security;
        }

        public int Quantity { get; }

        public Security Security { get; }
    }
}

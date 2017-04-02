namespace PortfolioRebalancer.Models
{
    using PortfolioRebalancer.Models.Abstraction;

    public class Stock : Position
    {
        public Stock(int quantity, Security security)
            : base(NodeType.Stock, quantity, security)
        {
        }
    }
}
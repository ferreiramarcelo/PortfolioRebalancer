namespace PortfolioRebalancer.Models
{
    using PortfolioRebalancer.Models.Abstraction;

    public class Cash : SinglePosition
    {
        public Cash(decimal price) : base(NodeType.Cash, new Security("Cash", price))
        {
        }
    }
}
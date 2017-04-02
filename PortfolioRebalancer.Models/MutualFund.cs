namespace PortfolioRebalancer.Models
{
    using PortfolioRebalancer.Models.Abstraction;

    public class MutualFund : SinglePosition
    {
        public MutualFund(string symbol, decimal price) : base(NodeType.MutualFund, new Security(symbol, price))
        {
        }
    }
}
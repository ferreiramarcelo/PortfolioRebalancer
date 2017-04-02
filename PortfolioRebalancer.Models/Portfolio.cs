namespace PortfolioRebalancer.Models
{
    using PortfolioRebalancer.Models.Abstraction;

    public sealed class Portfolio : RebalanceItemContainer<Position>
    {
        public Portfolio() : base(NodeType.Portfolio)
        {
        }
    }
}

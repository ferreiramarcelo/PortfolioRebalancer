namespace PortfolioRebalancer.Models
{
    using PortfolioRebalancer.Models.Abstraction;

    public sealed class Household : RebalanceItemContainer<Portfolio>
    {
        public Household() : base(NodeType.Household)
        {
        }
    }
}

namespace PortfolioRebalancer.Models.Abstraction
{
    public abstract class RebalanceItem
    {
        protected RebalanceItem(NodeType type)
        {
            Type = type;
        }

        public NodeType Type { get; }

        public RebalanceItem Owner { get; internal set; } = null;
    }

}

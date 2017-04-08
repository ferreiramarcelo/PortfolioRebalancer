namespace PortfolioRebalancer.Models.Abstraction
{
    using System.Collections.Generic;

    public class PositionLink : Position
    {
        public PositionLink(NodeType type, int quantity, Security security) : base(type, quantity, security)
        {
        }

        public ICollection<Position> Positions { get; set; }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace PortfolioRebalancer.Models.Abstraction
{
    public class Portfolio
    {
        public Portfolio()
        {
        }

        public string Model { get; set; }

        public string Name { get; set; }

        public void Add(Position postion)
        {

        }

        public IEnumerator<Position> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
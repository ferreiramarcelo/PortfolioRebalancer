using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioRebalancer.Models.Abstraction
{
	public struct Owner
	{
		public object Ref { get; set; }

		public int Count { get; set; }
	}
}
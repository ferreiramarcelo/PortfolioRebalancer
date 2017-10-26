namespace TestApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Position
    {
        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(36)]
        public string PortfolioId { get; set; }

        [StringLength(36)]
        public string StockId { get; set; }

        public int Quantity { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        public virtual Stock Stock { get; set; }
    }
}

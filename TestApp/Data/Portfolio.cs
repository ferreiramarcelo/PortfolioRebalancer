namespace TestApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio()
        {
            Positions = new HashSet<Position>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        [StringLength(36)]
        public string HouseholdId { get; set; }

        [StringLength(36)]
        public string RegulationId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public virtual Household Household { get; set; }

        public virtual Regulation Regulation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Position> Positions { get; set; }
    }
}

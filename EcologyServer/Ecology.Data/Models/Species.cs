using System;
using System.Collections.Generic;

namespace Ecology.Data.Models
{
    public partial class Species
    {
        public Species()
        {
            SpeciesDistribution = new HashSet<SpeciesDistribution>();
        }

        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }

        public virtual ICollection<SpeciesDistribution> SpeciesDistribution { get; set; }
    }
}

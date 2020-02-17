using System;
using System.Collections.Generic;

namespace AnimalHabitat.Data.Models
{
    public partial class EcoregionCountry
    {
        public EcoregionCountry()
        {
            SpeciesDistribution = new HashSet<SpeciesDistribution>();
        }

        public int EcoregionId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Ecoregion Ecoregion { get; set; }
        public virtual ICollection<SpeciesDistribution> SpeciesDistribution { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AnimalHabitat.Data.Models
{
    public partial class Ecoregion
    {
        public Ecoregion()
        {
            EcoregionCountry = new HashSet<EcoregionCountry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RealmId { get; set; }
        public int BiomeId { get; set; }

        public virtual RealmBiome RealmBiome { get; set; }
        public virtual ICollection<EcoregionCountry> EcoregionCountry { get; set; }
    }
}

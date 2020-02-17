using System;
using System.Collections.Generic;

namespace AnimalHabitat.Data.Models
{
    public partial class Biome
    {
        public Biome()
        {
            RealmBiome = new HashSet<RealmBiome>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RealmBiome> RealmBiome { get; set; }
    }
}

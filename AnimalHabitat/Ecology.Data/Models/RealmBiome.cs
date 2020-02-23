using System;
using System.Collections.Generic;

namespace Ecology.Data.Models
{
    public partial class RealmBiome
    {
        public RealmBiome()
        {
            Ecoregion = new HashSet<Ecoregion>();
        }

        public int RealmId { get; set; }
        public int BiomeId { get; set; }

        public virtual Biome Biome { get; set; }
        public virtual Realm Realm { get; set; }
        public virtual ICollection<Ecoregion> Ecoregion { get; set; }
    }
}

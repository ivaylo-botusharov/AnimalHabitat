using System;
using System.Collections.Generic;

namespace Ecology.Data.Models
{
    public partial class SpeciesDistribution
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int EcoregionId { get; set; }
        public int CountryId { get; set; }
        public int Population { get; set; }
        public string Description { get; set; }

        public virtual EcoregionCountry EcoregionCountry { get; set; }
        public virtual Species Species { get; set; }
    }
}

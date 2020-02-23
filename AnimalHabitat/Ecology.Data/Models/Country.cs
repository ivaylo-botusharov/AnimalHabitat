using System;
using System.Collections.Generic;

namespace Ecology.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            EcoregionCountry = new HashSet<EcoregionCountry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EcoregionCountry> EcoregionCountry { get; set; }
    }
}

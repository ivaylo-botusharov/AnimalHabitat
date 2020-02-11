using System;
using System.Collections.Generic;

namespace AnimalHabitat.Data.Models
{
    public partial class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public int Count { get; set; }
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
    }
}

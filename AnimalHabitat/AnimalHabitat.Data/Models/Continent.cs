using System;
using System.Collections.Generic;

namespace AnimalHabitat.Data.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Animal = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}

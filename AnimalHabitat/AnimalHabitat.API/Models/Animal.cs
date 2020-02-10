using System;

namespace AnimalHabitat.API.Models
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Species { get; set; }

        public string ContinentalHabitat { get; set; }

        public int Count { get; set; }
    }
}

namespace AnimalHabitat.API.Models
{
    public class SpeciesDistributionPostModel
    {
        public string SpeciesId { get; set; }

        public int EcoregionId { get; set; }

        public int CountryId { get; set; }

        public int Population { get; set; }
    }
}

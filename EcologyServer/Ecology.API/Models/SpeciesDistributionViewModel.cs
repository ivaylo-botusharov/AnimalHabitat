namespace Ecology.API.Models
{
    public class SpeciesDistributionViewModel
    {
        public int Id { get; set; }

        public string SpeciesCommonName { get; set; }

        public string SpeciesScientificName { get; set; }

        public string Realm { get; set; }

        public string Biome { get; set; }

        public string Ecoregion { get; set; }

        public string Country { get; set; }

        public int Population { get; set; }

        public int EcoregionId { get; set; }

        public int CountryId { get; set; }
    }
}

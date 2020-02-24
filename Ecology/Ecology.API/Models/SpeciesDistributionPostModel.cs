namespace Ecology.API.Models
{
    public class SpeciesDistributionPostModel
    {
        public int Population { get; set; }

        public int SpeciesId { get; set; }

        public int? EcoregionId { get; set; }

        public int? CountryId { get; set; }
    }
}

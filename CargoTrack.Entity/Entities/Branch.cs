using CargoTrack.Entity.Entities.Common;

namespace CargoTrack.Entity.Entities
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}

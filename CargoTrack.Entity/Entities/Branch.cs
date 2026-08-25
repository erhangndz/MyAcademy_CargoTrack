using CargoTrack.Entity.Entities.Common;

namespace CargoTrack.Entity.Entities
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }



        //Navigation Properties

        public City City { get; set; }
        public IList<Cargo> OriginCargos { get; set; }
        public IList<Cargo> DestinationCargos { get; set; }
    }
}

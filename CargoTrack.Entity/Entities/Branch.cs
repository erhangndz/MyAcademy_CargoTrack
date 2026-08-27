using CargoTrack.Entity.Entities.Common;

namespace CargoTrack.Entity.Entities
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }



        //Navigation Properties

        public virtual City City { get; set; }
        public virtual IList<Cargo> OriginCargos { get; set; }
        public virtual IList<Cargo> DestinationCargos { get; set; }
    }
}

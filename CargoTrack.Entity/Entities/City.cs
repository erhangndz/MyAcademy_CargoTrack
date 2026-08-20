using CargoTrack.Entity.Entities.Common;

namespace CargoTrack.Entity.Entities
{
    public class City: BaseEntity
    {
        public string Name { get; set; }
        public IList<Branch> Branches { get; set; }
    }
}

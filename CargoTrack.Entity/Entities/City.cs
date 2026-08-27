using CargoTrack.Entity.Entities.Common;

namespace CargoTrack.Entity.Entities
{
    public class City: BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Branch> Branches { get; set; }
    }
}

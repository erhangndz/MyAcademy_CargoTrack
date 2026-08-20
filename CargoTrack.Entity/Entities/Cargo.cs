using CargoTrack.Entity.Entities.Common;
using CargoTrack.Entity.Entities.Enums;

namespace CargoTrack.Entity.Entities;

public class Cargo: BaseEntity
{
    public string TrackCode { get; set; }
    public DateTime ShipmentDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public double Weight { get; set; }
    public CargoType CargoType { get; set; }

}

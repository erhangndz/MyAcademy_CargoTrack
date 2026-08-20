namespace CargoTrack.DTO.DTOs.BranchDtos
{
    public class UpdateBranchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}

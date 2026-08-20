using CargoTrack.DTO.DTOs.CityDtos;

namespace CargoTrack.DTO.DTOs.BranchDtos
{
    public class ResultBranchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public ResultCityDto City { get; set; }
    }
}

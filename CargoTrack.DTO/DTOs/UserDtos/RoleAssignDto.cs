namespace CargoTrack.DTO.DTOs.UserDtos
{
    public class RoleAssignDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}

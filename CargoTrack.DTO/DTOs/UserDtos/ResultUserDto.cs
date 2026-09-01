namespace CargoTrack.DTO.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}

namespace CargoTrack.DTO.DTOs.AboutDtos
{
    public class UpdateAboutDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}

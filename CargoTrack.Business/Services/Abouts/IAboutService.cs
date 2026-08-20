using CargoTrack.DTO.DTOs.AboutDtos;

namespace CargoTrack.Business.Services.Abouts
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<UpdateAboutDto> GetByIdAsync(Guid id);
        Task CreateAsync(CreateAboutDto createAboutDto);
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAsync(Guid id);

    }
}

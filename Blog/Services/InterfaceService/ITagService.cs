using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface ITagService
    {
        Task<List<TagResponseDTO>> GetAllAsync();
        Task<TagResponseDTO?> GetByIdAsync(int id);
        Task CreateAsync(TagRequestDTO tag);
        Task<bool> UpdateAsync(int id, TagRequestDTO tag);
        Task<bool> DeleteAsync(int id);
    }
}

using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface ITagRepository
    {
        Task<List<TagResponseDTO>> GetAllAsync();
        Task<TagResponseDTO?> GetByIdAsync(int id);
        Task CreateAsync(Tag tag);
        Task<int> UpdateAsync(int id, Tag tag);
        Task<int> DeleteAsync(int id);
    }
}

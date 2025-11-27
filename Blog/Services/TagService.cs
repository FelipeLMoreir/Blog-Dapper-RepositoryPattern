using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task<List<TagResponseDTO>> GetAllAsync()
            => _tagRepository.GetAllAsync();

        public Task<TagResponseDTO?> GetByIdAsync(int id)
            => _tagRepository.GetByIdAsync(id);

        public async Task CreateAsync(TagRequestDTO dto)
        {
            var tag = new Tag(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));
            await _tagRepository.CreateAsync(tag);
        }

        public async Task<bool> UpdateAsync(int id, TagRequestDTO dto)
        {
            var tag = new Tag(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));
            var rows = await _tagRepository.UpdateAsync(id, tag);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rows = await _tagRepository.DeleteAsync(id);
            return rows > 0;
        }
    }
}

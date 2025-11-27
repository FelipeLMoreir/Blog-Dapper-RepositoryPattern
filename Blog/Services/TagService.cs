using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class TagService : ITagService
    {
        private TagRepository _tagRepository;
        public TagService(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task CreateTagAsync(TagRequestDTO dto)
        {
            var tag = new Tag(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.CreateAsync(tag);
        }

        public async Task<bool> UpdateTagAsync(int id, TagRequestDTO dto)
        {
            var tag = new Tag(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));

            var rows = await _tagRepository.UpdateAsync(id, tag);
            return rows > 0;
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            var rows = await _tagRepository.DeleteAsync(id);
            return rows > 0;
        }
    }
}

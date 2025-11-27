using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface ITagController
    {
        Task<ActionResult<List<TagResponseDTO>>> GetAllTags();
        Task<ActionResult> CreateTag(TagRequestDTO dto);
        Task<ActionResult> UpdateTag(int id, TagRequestDTO dto);
        Task<ActionResult> DeleteTag(int id);
    }
}

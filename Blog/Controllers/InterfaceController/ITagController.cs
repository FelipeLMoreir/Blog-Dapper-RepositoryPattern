using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface ITagController
    {
        Task<ActionResult<List<TagResponseDTO>>> GetAll();
        Task<ActionResult<TagResponseDTO>> GetById(int id);
        Task<ActionResult> Create(TagRequestDTO dto);
        Task<ActionResult> Update(int id, TagRequestDTO dto);
        Task<ActionResult> Delete(int id);
    }
}

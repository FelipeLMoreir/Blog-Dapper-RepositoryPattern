using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase, ITagController
    {
        private TagService _tagService;
        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTags()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateTag(TagRequestDTO dto)
        {
            await _tagService.CreateTagAsync(dto);
            return Created(string.Empty, null);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTag(int id, TagRequestDTO dto)
        {
            var updated = await _tagService.UpdateTagAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            var deleted = await _tagService.DeleteTagAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}

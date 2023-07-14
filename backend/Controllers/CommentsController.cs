using gomomentus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gomomentus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly JsonPlaceholderService _jsonPlaceholderService;

        public CommentsController(JsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            try
            {
                var comments = _jsonPlaceholderService.LoadLocalComments();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving comments.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            try
            {
                var comments = _jsonPlaceholderService.LoadLocalComments();
                var comment = comments.FirstOrDefault(c => c.id == id);

                if (comment == null)
                {
                    return NotFound();
                }

                return Ok(comment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the comment.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            try
            {
                int newCommentId = GenerateCommentId();
                comment.id = newCommentId;

                var createdComment = await _jsonPlaceholderService.AddCommentAsync(comment);
                return CreatedAtAction(nameof(GetComment), new { id = createdComment.id }, createdComment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the comment.");
            }
        }

        private int GenerateCommentId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                await _jsonPlaceholderService.DeleteCommentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the comment.");
            }
        }
    }
}

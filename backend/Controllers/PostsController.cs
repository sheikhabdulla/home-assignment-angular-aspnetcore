using gomomentus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace gomomentus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly JsonPlaceholderService _jsonPlaceholderService;

        public PostsController(JsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet]
        public async Task<ActionResult<PostsResponse>> GetPosts()
        {
            try
            {
                var posts = await _jsonPlaceholderService.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the posts.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                var posts = await _jsonPlaceholderService.GetPostsAsync();
                var post = posts.FirstOrDefault(p => p.Post.id == id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the post.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _jsonPlaceholderService.DeletePostAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the post.");
            }
        }

        [HttpPost("{id}/favourite")]
        public async Task<IActionResult> UpdatePostFavourite(int id, [FromBody] Post postFav)
        {
            try
            {
                var post = await _jsonPlaceholderService.GetPostAsync(id);

                if (post == null)
                {
                    return NotFound();
                }

                post.favourite = postFav.favourite;

                await _jsonPlaceholderService.UpdatePostAsync(post);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the post favourite.");
            }
        }
    }
}

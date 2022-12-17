using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IBlogPostRepository _blogPostRepository;

        public PostsController(DataContext context, IBlogPostRepository blogPostRepository)
        {
            _context = context;
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<BlogPostResponseDto>> GetBlogPost(string slug)
        {  
           try
           {
           return Ok(await _blogPostRepository.GetBlogPost(slug));
           } catch(Exception)
           {
            return BadRequest();
           }
        }

        [HttpPost]
        public async Task<ActionResult<BlogPostResponseDto>> AddBlogPost(BlogPostRequestDto blogPostRequestDto)
        {   
            try
            { 
            var blogPost = await _blogPostRepository.AddBlogPost(blogPostRequestDto);
            return Ok(blogPost);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{slug}")]
        public async Task<ActionResult<BlogPostResponseDto>> UpdateBlogPost(string slug, BlogPostRequestDto blogPostRequestDto)
        {   
            try
            { 
            return Ok(await _blogPostRepository.UpdateBlogPost(slug, blogPostRequestDto));
            }catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{slug}")]
        public async Task<ActionResult> DeleteBlogPost(string slug) 
        {   
            try 
            { 
            await _blogPostRepository.DeleteBlogPost(slug);
            return Ok();
            }catch(Exception)
            {
              return BadRequest();
            }
        }
        
        // ?tag=AngularJS
        [HttpGet]
        public async Task<ActionResult<BlogPostListResponseDto>> ListBlogPosts([FromQuery]string tag)
        {   
            try
            { 
            if(tag != null)
            {   
                return Ok(await _blogPostRepository.ListBlogPostsByTag(tag));
            }
                return Ok(await _blogPostRepository.ListBlogPosts());
            } catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{slug}/comments")]
        public async Task<ActionResult<CommentResponseDto>> AddComment(string slug, CommentRequestDto commentRequestDto)
        {   
            try
            { 
            return Ok(await _blogPostRepository.AddComment(slug, commentRequestDto));
            }catch(Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{slug}/comments")]
        public async Task<ActionResult<List<CommentResponseDto>>> GetComments(string slug)
        {   
            try
            { 
            return Ok(await _blogPostRepository.GetComments(slug));
            }catch(Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{slug}/comments/{id}")]
        public async Task<ActionResult> DeleteComment(string slug, int id)
        {   
            try
            { 
            await _blogPostRepository.DeleteComment(slug, id);
            return Ok();
            }catch(Exception)
            {
                return BadRequest();
            }
        }
        
            


        

    }
}
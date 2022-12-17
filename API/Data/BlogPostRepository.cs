using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Slugify;

namespace API.Data
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public BlogPostRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<BlogPostResponseDto> GetBlogPost(string slug)
        {   
            
            var blogPost = await _context.Blogs.SingleOrDefaultAsync(x => x.Slug == slug);
            var blogPostResponseDto = _mapper.Map<BlogPostResponseDto>(blogPost);
            blogPostResponseDto.tagList = await GetTagsByBlogPost(blogPostResponseDto.slug);
            return blogPostResponseDto;
            
        }
        public async Task<BlogPostResponseDto> AddBlogPost(BlogPostRequestDto blogPostRequestDto)
        {
            var _slugHelper = new SlugHelper();
            var blogPost = new BlogPost
            {
                Slug = _slugHelper.GenerateSlug(blogPostRequestDto.title),
                Title = blogPostRequestDto.title,
                Description = blogPostRequestDto.description,
                Body = blogPostRequestDto.body
            };
            _context.Blogs.Add(blogPost);
            foreach (var tag in blogPostRequestDto.tagList)
            {
              var tagDb = await _context.Tags.SingleOrDefaultAsync(x => x.TagName == tag);
              if(tagDb == null)
              {
                var tmpTag = new Tag(Guid.NewGuid().ToString(), tag);
                _context.Tags.Add(tmpTag);
                _context.BlogPostTags.Add(new BlogPostTag(blogPost.Slug, tmpTag.Id, tmpTag.TagName));
              }
              else
              {
                _context.BlogPostTags.Add(new BlogPostTag(blogPost.Slug, tagDb.Id, tagDb.TagName));
              } 
            }
            await _context.SaveChangesAsync();
            var blogPostResponseDto = _mapper.Map<BlogPostResponseDto>(blogPostRequestDto);
            blogPostResponseDto.slug = blogPost.Slug;
            return blogPostResponseDto;
        }
        public async Task<BlogPostResponseDto> UpdateBlogPost(string slug, BlogPostRequestDto blogPostRequestDto)
        {
          var blogPost = await _context.Blogs.SingleOrDefaultAsync(x => x.Slug == slug);
          if(blogPostRequestDto.title != null)
          {
            var _slugHelper = new SlugHelper();
            var newSlug = _slugHelper.GenerateSlug(blogPostRequestDto.title);
          //  var listOfBlogPosts = await _context.BlogPostTags.Where(x => x.Slug == slug).ToListAsync();
            blogPost.Slug = newSlug;
            blogPost.Title = blogPostRequestDto.title;
          }
          if(blogPostRequestDto.description != null)
            blogPost.Description = blogPostRequestDto.description;
          if(blogPostRequestDto.body != null)
          blogPost.Body = blogPostRequestDto.body;
          blogPost.UpdatedAt = DateTime.Now;
          Update(blogPost);
          await _context.SaveChangesAsync();
          var blogPostResponseDto = _mapper.Map<BlogPostResponseDto>(blogPost);
          blogPostResponseDto.tagList = await GetTagsByBlogPost(blogPostResponseDto.slug);
          return blogPostResponseDto;
        }

        public async Task DeleteBlogPost(string slug)
        {
          var blogPost = await _context.Blogs.SingleOrDefaultAsync(x => x.Slug == slug);
          _context.Entry(blogPost).State = EntityState.Deleted;
          await _context.SaveChangesAsync();
        }

        public async Task<BlogPostListResponseDto> ListBlogPosts()
        { 
          var blogPosts = await _context.Blogs.OrderByDescending(bp => bp.CreatedAt).Take(3).ToListAsync();
          var returnLista = new List<BlogPostResponseDto>();
          foreach(var bp in blogPosts)
          { 
            var blogPostResponseDto = new BlogPostResponseDto
            {
              slug = bp.Slug,
              title = bp.Title,
              description = bp.Description,
              body = bp.Body,
              tagList = await GetTagsByBlogPost(bp.Slug),
              CreatedAt = bp.CreatedAt,
              UpdatedAt = bp.UpdatedAt
            };
            returnLista.Add(blogPostResponseDto);  
          }
        return new BlogPostListResponseDto(returnLista, 3);
        }
        public async Task<CommentResponseDto> AddComment(string slug, CommentRequestDto commentRequestDto)
        {
         var comment = new Comment()
          {
          Body = commentRequestDto.body,
          blogPostSlug = slug
          };
          _context.Comments.Add(comment);
          await _context.SaveChangesAsync();
          var lastComment = await _context.Comments.OrderByDescending(x => x.CreatedAt).FirstAsync();
          var commentResponseDto = new CommentResponseDto()
          {
            Id = lastComment.Id,
            CreatedAt = lastComment.CreatedAt,
            UpdatedAt = lastComment.UpdatedAt,
            Body = lastComment.Body
          };
          return commentResponseDto;
        } 

        public async Task<BlogPostListResponseDto> ListBlogPostsByTag(string tag)
        { 
          var blogPostResponseDtoList = new List<BlogPostResponseDto>();
          var counter = 0;
          var blogPostTags = await _context.BlogPostTags.Where(x => x.TagName == tag).ToListAsync();
          foreach(var blogPostTag in blogPostTags)
          {
            var blogPost = await _context.Blogs.SingleOrDefaultAsync(x => x.Slug == blogPostTag.Slug);
            var blogPostResponseDto = new BlogPostResponseDto
            {
              slug = blogPost.Slug,
              title = blogPost.Title,
              description = blogPost.Description,
              body = blogPost.Body,
              tagList = await GetTagsByBlogPost(blogPost.Slug),
              CreatedAt = blogPost.CreatedAt,
              UpdatedAt = blogPost.UpdatedAt
            };
            blogPostResponseDtoList.Add(blogPostResponseDto);
            ++counter;
          }
          return new BlogPostListResponseDto(blogPostResponseDtoList, counter);
        }

        public async Task<List<CommentResponseDto>>GetComments(string slug)
        {
          var commentList = await _context.Comments.Where(c => c.blogPostSlug == slug).ToListAsync();
          return _mapper.Map<List<CommentResponseDto>>(commentList);
        }

        public async Task DeleteComment(string slug, int id)
        {
          var comment = await _context.Comments.SingleOrDefaultAsync(x => x.blogPostSlug == slug && x.Id == id);
          _context.Entry(comment).State = EntityState.Deleted;
          await _context.SaveChangesAsync();
        }

        

         public void Update(BlogPost blogPost)
        {
            _context.Entry(blogPost).State = EntityState.Modified;
        }

        public async Task<List<String>> GetTagsByBlogPost(string slug)
        { 
          List<String> tagList = new List<String>();
          var listOfBlogPostsTags = await _context.BlogPostTags.Where(x => x.Slug == slug).ToListAsync();
          foreach(var blogPostTag in listOfBlogPostsTags)
          {
            tagList.Add(blogPostTag.TagName);
          }
          return tagList;
        }



    }
}
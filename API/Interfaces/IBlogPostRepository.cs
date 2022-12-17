using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPostResponseDto>GetBlogPost(string slug);
        Task<BlogPostResponseDto>AddBlogPost(BlogPostRequestDto blogPostJson);
        Task<BlogPostResponseDto>UpdateBlogPost(string slug, BlogPostRequestDto blogPostRequestDto);
        Task DeleteBlogPost(string slug);
        Task<BlogPostListResponseDto>ListBlogPosts();
        Task<BlogPostListResponseDto>ListBlogPostsByTag(string tag);
        Task<CommentResponseDto>AddComment(string slug, CommentRequestDto commentRequestDto);
        Task<List<CommentResponseDto>>GetComments(string slug);
        Task DeleteComment(string slug, int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class BlogPostListResponseDto
    {  
    
       public BlogPostListResponseDto(List<BlogPostResponseDto> blogPosts, int postsCount)
       {
        BlogPosts = blogPosts;
        PostsCount = postsCount;
       }

       public List<BlogPostResponseDto> BlogPosts { get; set; } 
       public int PostsCount { get; set; }
    }
}
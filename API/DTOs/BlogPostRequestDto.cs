using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class BlogPostRequestDto
    {   
        public BlogPostRequestDto() {} 

        public BlogPostRequestDto(string Title, string Description, string Body, List<String> TagList)
        {
            title = Title;
            description = Description;
            body = Body;
            tagList = TagList;
        } 
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public List<String> tagList { get; set; }

    
        
    }
}
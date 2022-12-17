using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class BlogPostRequestDto
    {
        
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public List<String> tagList { get; set; }

    
        
    }
}
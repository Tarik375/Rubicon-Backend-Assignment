using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Entities
{
    public class BlogPost
    {   
     public BlogPost() {}
      public BlogPost(string slug, string title, string description, string body)
      {
        Slug = slug;
        Title = title;
        Description = description;
        Body = body;
      }
        [Key]
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
     //   public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
      //  [Required]
       // public Comment Comment { get; set; }
    //    public IList<BlogPostTag> BlogPostTags { get; } = new List<BlogPostTag>();

      //  public ICollection<Comment> Comments { get; set; }


    }
}
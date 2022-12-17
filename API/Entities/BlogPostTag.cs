using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BlogPostTag
    {   
        public BlogPostTag(string slug, string tagId, string tagName)
        {
            Slug = slug;
            TagId = tagId;
            TagName = tagName;
        }
        public int Id { get; set; }
        [ForeignKey("blogPost")]
        public string Slug { get; set; }
        [Required]
        public BlogPost blogPost { get; set; }
        [ForeignKey("tag")]
        public string TagId { get; set; }
        public Tag tag { get; set; }
        public string TagName { get; set; } 

/*
         public int Id { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public string BlogPostSlug { get; set; }
        public BlogPost BlogPost { get; set; } */
    }
}
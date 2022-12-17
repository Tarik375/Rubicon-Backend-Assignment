using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
     
     public DataContext(DbContextOptions options) : base(options)
     {

     }


     public DbSet<BlogPost> Blogs { get; set; }
     public DbSet<Comment> Comments { get; set; }
     public DbSet<Tag> Tags { get; set; }
     public DbSet<BlogPostTag> BlogPostTags { get; set; }

        
    }
}
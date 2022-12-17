using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Slugify;

namespace API.Data
{
    public class Seed
    {    

        public static List<BlogPost> GenerateBlogPosts()
        {   var _slugHelper = new SlugHelper();
            List<BlogPost> lista = new List<BlogPost>();
            lista.Add(new BlogPost(_slugHelper.GenerateSlug("World Cup 2022"),"World Cup 2022", "Qatar22", "The most expensive World Cup in history!"));
            lista.Add(new BlogPost(_slugHelper.GenerateSlug("Izbori2022"),"Izbori2022", "Odlucujuci", "2. oktobar izbori"));
            lista.Add(new BlogPost(_slugHelper.GenerateSlug("Elektrotehnički fakultet"),"Elektrotehnički fakultet", "Univerzitet u Sarajevu", "Novi statut"));
            return lista;
        }
          public static async Task SeedUsers(DataContext context)
        {
            if(await context.Blogs.AnyAsync()) return;
            var lista = GenerateBlogPosts();
            foreach (var blog in lista)
            {   
                context.Blogs.Add(blog);  
            }
            var guid1 = Guid.NewGuid().ToString();
            var guid2 = Guid.NewGuid().ToString();
            var guid3 = Guid.NewGuid().ToString();
            var guid4 = Guid.NewGuid().ToString();
            context.Tags.Add(new Tag(guid1, "bih"));
            context.Tags.Add(new Tag(guid2, "sa"));
            context.Tags.Add(new Tag(guid3, "worldcup"));
            context.Tags.Add(new Tag(guid4, "unsa"));
            context.BlogPostTags.Add(new BlogPostTag(lista.ElementAt(0).Slug, guid3, "worldcup"));
            context.BlogPostTags.Add(new BlogPostTag(lista.ElementAt(1).Slug, guid2, "sa"));
            context.BlogPostTags.Add(new BlogPostTag(lista.ElementAt(1).Slug, guid4, "unsa"));
            context.BlogPostTags.Add(new BlogPostTag(lista.ElementAt(2).Slug, guid4, "unsa"));
            context.BlogPostTags.Add(new BlogPostTag(lista.ElementAt(2).Slug, guid1, "bih"));
            context.Comments.Add(new Comment("ovo je katastrofa", lista.ElementAt(1).Slug));
            await context.SaveChangesAsync();
        }
    }
}
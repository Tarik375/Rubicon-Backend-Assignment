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
            await context.SaveChangesAsync();
        }
    }
}
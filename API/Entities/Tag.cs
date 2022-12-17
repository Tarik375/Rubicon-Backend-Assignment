using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Tag
    {   
        public Tag(string id, string tagName)
        {   
            Id = id;
            TagName = tagName;
        }
        public string Id { get; set; }
        public string TagName { get; set; }
    }
}
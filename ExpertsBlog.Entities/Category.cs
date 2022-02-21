using System.Collections.Generic;

namespace ExpertsBlog.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public HashSet<BlogPost> BlogPosts { get; set; }
    }
}
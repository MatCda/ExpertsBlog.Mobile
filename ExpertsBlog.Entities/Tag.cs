using System.Collections.Generic;

namespace ExpertsBlog.Entities
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }
        public HashSet<BlogPost> BlogPosts { get; set; }
    }
}
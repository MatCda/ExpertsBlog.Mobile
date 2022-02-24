using System.Collections.Generic;

namespace ExpertsBlog.Entities
{
    public class BlogPost : EntityBase
    {
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public HashSet<Tag> Tags { get; } = new HashSet<Tag>() ;
        public HashSet<Address> Addresses { get; set; }= new HashSet<Address>() ;
    }
}
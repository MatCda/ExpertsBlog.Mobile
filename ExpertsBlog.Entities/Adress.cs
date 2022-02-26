using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExpertsBlog.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public BlogPost BlogPost { get; set; }
        public int BlogPostId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    public class Smile
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ImageMId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ImageM ImageM { get; set; }
    }
}

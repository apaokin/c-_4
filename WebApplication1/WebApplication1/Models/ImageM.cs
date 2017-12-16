using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
        public class ImageM
        {
            public int Id { get; set; }
            public string Path { get; set; }

            public virtual List<Smile> Smiles { get; set; }
            public virtual List<Body> Bodies { get; set; }
        }
}

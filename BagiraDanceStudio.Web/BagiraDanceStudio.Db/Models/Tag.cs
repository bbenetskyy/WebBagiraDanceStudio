using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public virtual Image Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

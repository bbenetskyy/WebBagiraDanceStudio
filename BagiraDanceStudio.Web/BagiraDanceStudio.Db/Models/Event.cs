using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public virtual EventToImage EventToImage { get; set; }
        public string Title { get; set; }
        public string HtmlDescription { get; set; }
    }
}

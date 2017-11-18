using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public virtual Tag TagId { get; set; }
        public virtual EventToImage EventToImage { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreationTime { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Image()
        {
            CreationTime = DateTime.Now;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class EventToImage : TableAbstract
    {
        public Guid Id { get; set; }
        public virtual Image Image { get; set; }
        public virtual Event Event { get; set; }

        public override Guid GetId()
        {
            return Id;
        }
    }
}

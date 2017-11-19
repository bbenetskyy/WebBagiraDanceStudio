using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class Role : TableAbstract
    {
        public Guid Id { get; set; }
        public virtual List<PersonData> PersonalsData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Role()
        {
            PersonalsData = new List<PersonData>();
        }

        public override Guid GetId()
        {
            return Id;
        }
    }
}

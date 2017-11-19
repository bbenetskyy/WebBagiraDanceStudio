using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class User : TableAbstract
    {
        public Guid Id { get; set; }
        public virtual Level Level { get; set; }
        public Manager Manager { get; set; }
        public PersonData PersonData { get; set; }
        public BillingHistory BillingHistory { get; set; }
        public long TrainingPoints { get; set; }
        public decimal Balance { get; set; }

        public override Guid GetId()
        {
            return Id;
        }
    }
}

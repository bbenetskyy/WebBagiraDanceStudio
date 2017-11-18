using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public virtual Level Level { get; set; }
        [NotMapped]
        public PersonData Manager { get; set; }
        public virtual PersonData PersonData { get; set; }
        public BillingHistory BillingHistory { get; set; }
        public long TrainingPoints { get; set; }
        public decimal Balance { get; set; }
    }
}

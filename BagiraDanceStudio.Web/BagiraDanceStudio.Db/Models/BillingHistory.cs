using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class BillingHistory : TableAbstract
    {
        public Guid Id { get; set; }
        public virtual User UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingTime { get; set; }
        public string Description { get; set; }
        public BillingHistory()
        {
            BillingTime = DateTime.Now;
        }
        public override Guid GetId()
        {
            return Id;
        }
    }
}

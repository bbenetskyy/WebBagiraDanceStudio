using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class Manager :TableAbstract
    {
        public Guid Id { get; set; }
        public Guid PersonDataId { get; set; }
        public List<User> Users { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal Salary { get; set; }

        public override Guid GetId()
        {
            return Id;
        }
    }
}

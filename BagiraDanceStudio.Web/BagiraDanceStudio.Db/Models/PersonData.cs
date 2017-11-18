using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class PersonData
    {
        public Guid Id { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public string AdditionalInformaion { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
    }
}

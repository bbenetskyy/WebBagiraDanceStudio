using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.ViewModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        //Level data
        public string LevelName { get; set; }

        // Person data for the user
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public string AdditionalInformaion { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }

        //Role data
        public string Name { get; set; }
        public int Priority { get; set; }

        public Guid IdManager { get; set; }
        //public PersonData Manager { get; set; }
        public Guid IdBillingHistory { get; set; }
        //public BillingHistory BillingHistory { get; set; }
        public long TrainingPoints { get; set; }
        public decimal Balance { get; set; }
    }
}

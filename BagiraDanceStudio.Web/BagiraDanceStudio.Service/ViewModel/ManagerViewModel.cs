using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.ViewModel
{
    public class ManagerViewModel
    {
        public Guid Id { get; set; }
        //Role data
        public string Name { get; set; }
        public int Priority { get; set; }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Service.ViewModel
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}

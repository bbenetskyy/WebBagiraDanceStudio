using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class ScheduleAssigned : TableAbstract
    {
        public Guid Id { get; set; }
        public virtual ScheduleAvailable SheduleAvailable { get; set; }
        public virtual User User { get; set; }
        public DateTime AssignedTime { get; set; }
        public string Status { get; set; }
        public override Guid GetId()
        {
            return Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BagiraDanceStudio.Db.Models
{
    public class ScheduleAvailable
    {
        public Guid Id { get; set; }
        public virtual Level Level { get; set; }
        public virtual PersonData Instructor { get; set; }
        public virtual List<ScheduleAssigned> SchedulesAssigned { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int MaxUsers { get; set; }
        public ScheduleAvailable()
        {
            SchedulesAssigned = new List<ScheduleAssigned>();
        }
    }
}

using HQSOFT.Configuration.HQTasks;
using System;

namespace HQSOFT.Configuration.HQTasks
{
    public class HQTaskExcelDto
    {
        public string Subject { get; set; }
        public string Project { get; set; }
        public StatusTask Status { get; set; }
        public PriorityTask Priority { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public double ExpectedTime { get; set; }
        public double Process { get; set; }
    }
}
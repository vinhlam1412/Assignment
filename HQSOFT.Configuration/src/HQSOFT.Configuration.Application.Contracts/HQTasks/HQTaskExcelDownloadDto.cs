using HQSOFT.Configuration.HQTasks;
using Volo.Abp.Application.Dtos;
using System;

namespace HQSOFT.Configuration.HQTasks
{
    public class HQTaskExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Subject { get; set; }
        public string? Project { get; set; }
        public StatusTask? Status { get; set; }
        public PriorityTask? Priority { get; set; }
        public DateTime? ExpectedStartDateMin { get; set; }
        public DateTime? ExpectedStartDateMax { get; set; }
        public DateTime? ExpectedEndDateMin { get; set; }
        public DateTime? ExpectedEndDateMax { get; set; }
        public double? ExpectedTimeMin { get; set; }
        public double? ExpectedTimeMax { get; set; }
        public double? ProcessMin { get; set; }
        public double? ProcessMax { get; set; }

        public HQTaskExcelDownloadDto()
        {

        }
    }
}
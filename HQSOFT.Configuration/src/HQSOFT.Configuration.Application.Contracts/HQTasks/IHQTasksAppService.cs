using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using HQSOFT.Configuration.Shared;

namespace HQSOFT.Configuration.HQTasks
{
    public interface IHQTasksAppService : IApplicationService
    {
        Task<PagedResultDto<HQTaskDto>> GetListAsync(GetHQTasksInput input);

        Task<HQTaskDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<HQTaskDto> CreateAsync(HQTaskCreateDto input);

        Task<HQTaskDto> UpdateAsync(Guid id, HQTaskUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(HQTaskExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}
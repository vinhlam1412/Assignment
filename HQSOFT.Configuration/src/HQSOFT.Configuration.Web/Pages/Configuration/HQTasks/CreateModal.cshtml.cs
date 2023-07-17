using HQSOFT.Configuration.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HQSOFT.Configuration.HQTasks;

namespace HQSOFT.Configuration.Web.Pages.Configuration.HQTasks
{
    public class CreateModalModel : ConfigurationPageModel
    {
        [BindProperty]
        public HQTaskCreateViewModel HQTask { get; set; }

        private readonly IHQTasksAppService _hQTasksAppService;

        public CreateModalModel(IHQTasksAppService hQTasksAppService)
        {
            _hQTasksAppService = hQTasksAppService;

            HQTask = new();
        }

        public async Task OnGetAsync()
        {
            HQTask = new HQTaskCreateViewModel();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _hQTasksAppService.CreateAsync(ObjectMapper.Map<HQTaskCreateViewModel, HQTaskCreateDto>(HQTask));
            return NoContent();
        }
    }

    public class HQTaskCreateViewModel : HQTaskCreateDto
    {
    }
}
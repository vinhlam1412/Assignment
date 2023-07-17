//using Blazorise;
//using DevExpress.Blazor;
//using HQSOFT.Configuration.Blazor.Pages.Configuration.Tasks;
//using HQSOFT.Configuration.HQAssigments;
//using HQSOFT.Configuration.HQShares;
//using HQSOFT.Configuration.HQTasks;
//using HQSOFT.Configuration.Shared;
//using HQSOFT.Configuration.Users;
//using Microsoft.AspNetCore.Components;
//using Nito.AsyncEx;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
//using Volo.Abp.BlazoriseUI.Components;
//using Volo.Abp.ObjectMapping;
//using static HQSOFT.Configuration.Permissions.ConfigurationPermissions;

//namespace HQSOFT.Configuration.Blazor.Components
//{
//    public partial class HQSOFTLeftSideForm
//    {
//        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
//        protected PageToolbar Toolbar { get; } = new PageToolbar();
//        private IReadOnlyList<HQAssigmentWithNavigationPropertiesDto> HQAssigmentList { get; set; }
//        private IReadOnlyList<HQShareWithNavigationPropertiesDto> HQShareList { get; set; }
//        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
//        private int CurrentPage { get; set; } = 1;
//        private string CurrentSorting { get; set; } = string.Empty;
//        private int TotalCount { get; set; }
//        private HQAssigmentCreateDto NewHQAssigment { get; set; }
//        private HQShareCreateDto NewHQShare { get; set; }
//        private Validations NewHQAssigmentValidations { get; set; } = new();
//        private Validations NewHQShareValidations { get; set; } = new();

//        private Modal CreateHQShareModal { get; set; } = new();

//        private Modal CreateHQAssigmentModal { get; set; } = new();

//        private Guid EditingHQAssigmentId { get; set; }
        
//        private GetHQAssigmentsInput Filter { get; set; }


//        protected string SelectedCreateTab = "hQAssigment-create-tab";
     

//        protected string SelectedCreateTab2 = "hQShare-create-tab";
//        private IReadOnlyList<LookupDto<Guid>> HQTasksCollection { get; set; } = new List<LookupDto<Guid>>();
//        private IReadOnlyList<LookupDto<Guid>> Users { get; set; } = new List<LookupDto<Guid>>();

//        private string SelectedUserId { get; set; }

//        private string SelectedUserText { get; set; }

//        public Guid TaskId { get; set; }

//        private List<LookupDto<Guid>> SelectedUsers { get; set; } = new List<LookupDto<Guid>>();


//        [Parameter]
//        public string Value { get; set; }


//        //[Parameter]
//        //public EventCallback AssignmentClick { get; set; }

//        //[Parameter]
//        //public Validations Validation { get; set; }
//        public HQSOFTLeftSideForm()
//        {
//            NewHQAssigment = new HQAssigmentCreateDto();
//            EditingHQAssigment = new HQAssigmentUpdateDto();
//            Filter = new GetHQAssigmentsInput
//            {
//                MaxResultCount = PageSize,
//                SkipCount = (CurrentPage - 1) * PageSize,
//                Sorting = CurrentSorting
//            };
//            HQAssigmentList = new List<HQAssigmentWithNavigationPropertiesDto>();
//        }
//        protected override async Task OnInitializedAsync()
//        {

//            if (Value != null && Value.Length > 0)
//            {
//                TaskId = Guid.Parse(Value);
//            }
//            if (TaskId != Guid.Empty)
//            {
//                NewHQAssigment.HQTaskId = TaskId;
//            }
//            await GetHQTaskCollectionLookupAsync();


//        }
//        private async Task GetHQAssigmentsAsync()
//        {
//            Filter.MaxResultCount = PageSize;
//            Filter.SkipCount = (CurrentPage - 1) * PageSize;
//            Filter.Sorting = CurrentSorting;

//            var result = await HQAssigmentsAppService.GetListAsync(Filter);
//            HQAssigmentList = result.Items;
//            TotalCount = (int)result.TotalCount;
//        }

//        private async Task OpenCreateHQAssigmentModalAsync()
//         {
//            //Truyền vào idTask để lấy assingment xem đã tồn tại chưa
//            var hQAssigment = await HQAssigmentsAppService.GetTaskAsync(TaskId);
            
//            //Tồn tại
//            if (hQAssigment != null)
//            {
//                //Lấy ra detail của assignment đó: 
//                // HQAssigment
//                // HQTask 
//                // List user
//                var hQAssigmentDetail = await HQAssigmentsAppService.GetWithNavigationPropertiesAsync(hQAssigment.Id);
            

//            //Lấy Id của Assignment
//            EditingHQAssigmentId = hQAssigmentDetail.HQAssigment.Id;

//            //Lấy Assignment để edit
//            EditingHQAssigment = ObjectMapper.Map<HQAssigmentDto, HQAssigmentUpdateDto>(hQAssigmentDetail.HQAssigment);

//            //Map NewHQAssigment từ Update sang Create
//            NewHQAssigment = ObjectMapper.Map<HQAssigmentUpdateDto, HQAssigmentCreateDto>(EditingHQAssigment);
//            SelectedUsers = hQAssigmentDetail.Users.Select(a => new LookupDto<Guid>{ Id = a.Id, DisplayName = a.Email}).ToList();
//            }

//            //Không tồn tại
//            else
//            {
//                //Tạo mới list user và Assigment
//                SelectedUsers = new List<LookupDto<Guid>>();

//                NewHQAssigment = new HQAssigmentCreateDto
//                {
//                    Completeby = DateTime.Now,
                    


//                };
//            }
//            //await NewHQAssigmentValidations.ClearAll();
//            await CreateHQAssigmentModal.Show();
//        }

//        private async Task CloseCreateHQAssigmentModalAsync()
//        {
//            NewHQAssigment = new HQAssigmentCreateDto
//            {
//                Completeby = DateTime.Now,


//            };
//            await CreateHQShareModal.Hide();
//        }

//        private async Task CreateHQAssigmentAsync()
//        {
//            try
//            {
//                if (await NewHQAssigmentValidations.ValidateAll() == false)
//                {
//                    return;
//                }
//                NewHQAssigment.UserIds = SelectedUsers.Select(x => x.Id).ToList();


//                if (EditingHQAssigmentId == Guid.Empty)
//                {
//                    NewHQAssigment.HQTaskId = TaskId;
//                    await HQAssigmentsAppService.CreateAsync(NewHQAssigment);
//                }
//                else
//                {
//                   await UpdateHQAssigmentAsync();

//                }
//                await GetHQAssigmentsAsync();
//                await CloseCreateHQAssigmentModalAsync();
//            }
//            catch (Exception ex)
//            {
//                await HandleErrorAsync(ex);
//            }
//        }

//        private void OnSelectedCreateTabChanged(string name)
//        {
//            SelectedCreateTab = name; 
//            SelectedCreateTab2 = name;
//        }

//        private async Task GetHQTaskCollectionLookupAsync(string? newValue = null)
//        {
//            HQTasksCollection = (await HQAssigmentsAppService.GetHQTaskLookupAsync(new LookupRequestDto { Filter = newValue })).Items;
//        }

//        private async Task GetUserLookupAsync(string? newValue = null)
//        {
//            Users = (await HQAssigmentsAppService.GetUserLookupAsync(new LookupRequestDto { Filter = newValue })).Items;
//        }

//        private async Task UpdateHQAssigmentAsync()
//        {
//            try
//            {
//                if (await NewHQAssigmentValidations.ValidateAll() == false)
//                {
//                    return;
//                }
//                EditingHQAssigment.UserIds = SelectedUsers.Select(x => x.Id).ToList();
//                await HQAssigmentsAppService.UpdateAsync(EditingHQAssigmentId, EditingHQAssigment);
//                await GetHQAssigmentsAsync();
//                await CreateHQShareModal.Hide();
//            }
//            catch (Exception ex)
//            {
//                await HandleErrorAsync(ex);
//            }
//        }


//        private async Task CloseCreateHQShareModalAsync()
//        {
//            NewHQShare = new HQShareCreateDto
//            {


//            };
//            await CreateHQShareModal.Hide();
//        }


//        private async Task CreateHQShareAsync()
//        {
//            try
//            {
//                if (await NewHQShareValidations.ValidateAll() == false)
//                {
//                    return;
//                }
//                NewHQShare.UserIds = SelectedUsers.Select(x => x.Id).ToList();

//                NewHQShare.IdAssigned = TaskId;
//                await HQSharesAppService.CreateAsync(NewHQShare);
//                await GetHQSharesAsync();
//                await CloseCreateHQShareModalAsync();
//            }
//            catch (Exception ex)
//            {
//                await HandleErrorAsync(ex);
//            }
//        }

//        private async Task GetHQSharesAsync()
//        {
//            Filter.MaxResultCount = PageSize;
//            Filter.SkipCount = (CurrentPage - 1) * PageSize;
//            Filter.Sorting = CurrentSorting;

//            var result = await HQSharesAppService.GetListAsync(FilterShare);
//            HQShareList = result.Items;
//            TotalCount = (int)result.TotalCount;
//        }

//        private async Task OpenCreateHQShareModalAsync()
//        {
//            SelectedUsers = new List<LookupDto<Guid>>();


//            NewHQShare = new HQShareCreateDto
//            {


//            };
//            await NewHQShareValidations.ClearAll();
//            await CreateHQShareModal.Show();
//        }


//        private void AddUser()
//        {
//            if (SelectedUserId.IsNullOrEmpty())
//            {
//                return;
//            }

//            if (SelectedUsers.Any(p => p.Id.ToString() == SelectedUserId))
//            {
//                UiMessageService.Warn(L["ItemAlreadyAdded"]);
//                return;
//            }

//            SelectedUsers.Add(new LookupDto<Guid>
//            {
//                Id = Guid.Parse(SelectedUserId),
//                DisplayName = SelectedUserText
//            });
//        }

//    }
//}

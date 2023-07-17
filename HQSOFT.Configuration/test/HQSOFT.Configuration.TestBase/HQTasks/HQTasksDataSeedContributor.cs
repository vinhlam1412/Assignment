using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using HQSOFT.Configuration.HQTasks;

namespace HQSOFT.Configuration.HQTasks
{
    public class HQTasksDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IHQTaskRepository _hQTaskRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public HQTasksDataSeedContributor(IHQTaskRepository hQTaskRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _hQTaskRepository = hQTaskRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _hQTaskRepository.InsertAsync(new HQTask
            (
                id: Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"),
                subject: "45872be9",
                project: "a5114305ba054b9e8528e2b56168abcdd771e7db94104bbf8641117503bd660e02487d4e6d",
                status: default,
                priority: default,
                expectedStartDate: new DateTime(2017, 1, 2),
                expectedEndDate: new DateTime(2005, 5, 20),
                expectedTime: 992088742,
                process: 1919125218
            ));

            await _hQTaskRepository.InsertAsync(new HQTask
            (
                id: Guid.Parse("36fc399b-c519-428d-9274-e85ba79de56a"),
                subject: "5303e773a60047e994424a658f4014ebdbbf6e",
                project: "7ab63ba1498f4ac1b094ec26820eda799cb6fef3d9c74cefb04060a6a2611f1b0228da3fc4124ba3ab3",
                status: default,
                priority: default,
                expectedStartDate: new DateTime(2014, 7, 19),
                expectedEndDate: new DateTime(2006, 6, 20),
                expectedTime: 1524224302,
                process: 687953297
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}
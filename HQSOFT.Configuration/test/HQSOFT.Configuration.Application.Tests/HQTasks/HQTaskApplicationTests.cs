using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace HQSOFT.Configuration.HQTasks
{
    public class HQTasksAppServiceTests : ConfigurationApplicationTestBase
    {
        private readonly IHQTasksAppService _hQTasksAppService;
        private readonly IRepository<HQTask, Guid> _hQTaskRepository;

        public HQTasksAppServiceTests()
        {
            _hQTasksAppService = GetRequiredService<IHQTasksAppService>();
            _hQTaskRepository = GetRequiredService<IRepository<HQTask, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _hQTasksAppService.GetListAsync(new GetHQTasksInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("36fc399b-c519-428d-9274-e85ba79de56a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _hQTasksAppService.GetAsync(Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new HQTaskCreateDto
            {
                Subject = "8570971f3333434ba5f9dfa",
                Project = "d70f4289b91d413b8242671c43caf15f1bf63e8d8d0f4cb684412159e0daef6232129bc59a9a4666956",
                Status = default,
                Priority = default,
                ExpectedStartDate = new DateTime(2001, 10, 23),
                ExpectedEndDate = new DateTime(2005, 4, 24),
                ExpectedTime = 1855716201,
                Process = 1601549740
            };

            // Act
            var serviceResult = await _hQTasksAppService.CreateAsync(input);

            // Assert
            var result = await _hQTaskRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Subject.ShouldBe("8570971f3333434ba5f9dfa");
            result.Project.ShouldBe("d70f4289b91d413b8242671c43caf15f1bf63e8d8d0f4cb684412159e0daef6232129bc59a9a4666956");
            result.Status.ShouldBe(default);
            result.Priority.ShouldBe(default);
            result.ExpectedStartDate.ShouldBe(new DateTime(2001, 10, 23));
            result.ExpectedEndDate.ShouldBe(new DateTime(2005, 4, 24));
            result.ExpectedTime.ShouldBe(1855716201);
            result.Process.ShouldBe(1601549740);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new HQTaskUpdateDto()
            {
                Subject = "34c1dbd21",
                Project = "01e37361033e41879b92a304fe67dcf64b",
                Status = default,
                Priority = default,
                ExpectedStartDate = new DateTime(2001, 11, 14),
                ExpectedEndDate = new DateTime(2019, 1, 10),
                ExpectedTime = 799699074,
                Process = 824867602
            };

            // Act
            var serviceResult = await _hQTasksAppService.UpdateAsync(Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"), input);

            // Assert
            var result = await _hQTaskRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Subject.ShouldBe("34c1dbd21");
            result.Project.ShouldBe("01e37361033e41879b92a304fe67dcf64b");
            result.Status.ShouldBe(default);
            result.Priority.ShouldBe(default);
            result.ExpectedStartDate.ShouldBe(new DateTime(2001, 11, 14));
            result.ExpectedEndDate.ShouldBe(new DateTime(2019, 1, 10));
            result.ExpectedTime.ShouldBe(799699074);
            result.Process.ShouldBe(824867602);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _hQTasksAppService.DeleteAsync(Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"));

            // Assert
            var result = await _hQTaskRepository.FindAsync(c => c.Id == Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"));

            result.ShouldBeNull();
        }
    }
}
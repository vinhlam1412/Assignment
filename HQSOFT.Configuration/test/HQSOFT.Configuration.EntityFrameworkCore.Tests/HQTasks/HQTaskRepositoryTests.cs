using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using HQSOFT.Configuration.HQTasks;
using HQSOFT.Configuration.EntityFrameworkCore;
using Xunit;

namespace HQSOFT.Configuration.HQTasks
{
    public class HQTaskRepositoryTests : ConfigurationEntityFrameworkCoreTestBase
    {
        private readonly IHQTaskRepository _hQTaskRepository;

        public HQTaskRepositoryTests()
        {
            _hQTaskRepository = GetRequiredService<IHQTaskRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _hQTaskRepository.GetListAsync(
                    subject: "45872be9",
                    project: "a5114305ba054b9e8528e2b56168abcdd771e7db94104bbf8641117503bd660e02487d4e6d",
                    status: default,
                    priority: default
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("728c44dc-8fee-4a0a-b739-e60d48b333c7"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _hQTaskRepository.GetCountAsync(
                    subject: "5303e773a60047e994424a658f4014ebdbbf6e",
                    project: "7ab63ba1498f4ac1b094ec26820eda799cb6fef3d9c74cefb04060a6a2611f1b0228da3fc4124ba3ab3",
                    status: default,
                    priority: default
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}
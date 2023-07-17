using HQSOFT.Configuration.HQTasks;
using HQSOFT.Configuration.CSAttributeDetails;
using HQSOFT.Configuration.CSAttributes;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HQSOFT.Configuration.EntityFrameworkCore;

[ConnectionStringName(ConfigurationDbProperties.ConnectionStringName)]
public interface IConfigurationDbContext : IEfCoreDbContext
{
    DbSet<HQTask> HQTasks { get; set; }
    DbSet<CSAttributeDetail> CSAttributeDetails { get; set; }
    DbSet<CSAttribute> CSAttributes { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
using System.Threading.Tasks;

namespace FlyBookingSystem.Data;

public interface IFlyBookingSystemDbSchemaMigrator
{
    Task MigrateAsync();
}

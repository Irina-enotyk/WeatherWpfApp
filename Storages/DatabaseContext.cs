using Microsoft.EntityFrameworkCore;
using WeatherWpfApp.Servises.GeoCoder;

namespace WeatherWpfApp.Storages
{
    public class DatabaseContext : DbContext
    {
        public DbSet<GeoLocation> Locations { get; set; }

        //прокидываем в базовый класс настройки : тип и строка состояния БД 
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //DB создастся, если ее еще не существует, старая не перезапишется.
            //
            //ИИ почему-то критикует создание бд в конструкторе, пишет, что по-хорошему, из-за проблем с обновлением данных
            //в реальных проектах нужно применять миграции (не разобралась).
            Database.EnsureCreated();
        }
    }
}

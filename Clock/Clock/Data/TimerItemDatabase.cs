using Clock.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Data
{
   public class TimerItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> LazyInitializer =
         new Lazy<SQLiteAsyncConnection>(() =>
         {
             return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
         });


        static SQLiteAsyncConnection Database => LazyInitializer.Value;
        static bool initialized = false;
        public TimerItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }


        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TimerItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TimerItem)).ConfigureAwait(false);
                }
            }
        }

        public Task<List<TimerItem>> GetTimersAsync()
        {
            return Database.Table<TimerItem>().ToListAsync();
        }

        public Task<int> SaveTimerAsync(TimerItem timer)
        {
            if(timer.ID != 0)
            {
                return Database.UpdateAsync(timer);
            }
            else
            {
               return Database.InsertAsync(timer);
            }

            

        }
        public Task<int> DeleteTimerAsync(TimerItem timer)
        {
            return Database.DeleteAsync(timer);
        }
    }
}

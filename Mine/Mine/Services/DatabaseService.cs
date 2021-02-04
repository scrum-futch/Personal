using System;
using System.Linq;
using System.Threading.Tasks;


using SQLite;

using Mine.Models;
using System.Collections.Generic;

namespace Mine.Services
{
    public class DatabaseService : IDataStore<ItemModel>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        /// <summary>
        /// Creates Items in a Database
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>boolean</returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.InsertAsync(item);
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Brings items from the Database to be updated
        /// </summary>
        /// <param name="item">Item </param>
        /// <returns>Boolean</returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.UpdateAsync(item);
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Deletes items from the Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var data = await ReadAsync(id);
            if (data == null)
            {
                return false;
            }

            var result = await Database.DeleteAsync(data);
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Brings items to the readpage from the database
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>results</returns>
        public Task<ItemModel> ReadAsync(string id)
        {
            if( id== null)
            {
                return null;
            }

            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));
            return result;
        }
        /// <summary>
        ///  Calls Items to the page
        /// </summary>
        /// <param name="forceRefresh">forcRefresh</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            var result = await Database.Table<ItemModel>().ToListAsync();
            return result;
        }

        //...
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Calculator.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;
        
        public Database(string dbPath)
        {
            
            database = new SQLiteAsyncConnection(dbPath);
            
            database.CreateTableAsync<Answer>().Wait();
        }
        
        public async Task Insert(Answer item)
        {
            
            await database.InsertAsync(item);
        }

        public async Task<Answer> GetAnswer()
        {
            return await database.Table<Answer>().FirstOrDefaultAsync();
        }

        public async Task DeleteAnswer(Answer item)
        {
            await database.DeleteAsync(item);
        }
    }
}

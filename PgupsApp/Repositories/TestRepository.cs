using PgupsApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Repositories
{
    public class TestRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection connection;

        public static string DbPath { get; } = System.IO.Path.Combine(FileSystem.AppDataDirectory, "tests.db3");
        public TestRepository()
        {
            _dbPath = DbPath;
        }

        private async Task Init()
        {
            if (connection != null)
                return;

            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Test>();
            await connection.CreateTableAsync<Question>();
            await connection.CreateTableAsync<Answer>();

        }

        public async Task<List<Test>> GetAllTests()
        {
            try
            {
                await Init();
                return await connection.Table<Test>().ToListAsync() ;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Test>();
        }

        public async Task<List<Question>> GetAllQuestions(int testId)
        {
            try
            {
                await Init();
                return await connection.Table<Question>().Where(quest => quest.TestId == testId).ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Question>();
        }

        public async Task<List<Answer>> GetAnswersForCurrent(int testId, int questionId)
        {
            try
            {
                await Init();
                return await connection.Table<Answer>().Where(ans => (ans.QuestionId == questionId) && (ans.TestId == testId)).ToListAsync();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Answer>();
        }
    }
}

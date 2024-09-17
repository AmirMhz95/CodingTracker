using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInputs;

namespace SqlOperations
{
    public class ReadOperation : ISqliteOperations
    {
        private readonly string _connectionString;

        public ReadOperation(string connectionString)
        {
            _connectionString = connectionString;

        }


        public void Execute()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string selectQuery = @"SELECT * FROM CodingTracker";

                IEnumerable<UserInput> userInputs = connection.Query<UserInput>(selectQuery);

                foreach (var userInput in userInputs)
                {
                    Console.WriteLine($"Id: {userInput.Id}, Date: {userInput.Date}, StartTime: {userInput.StartTime}, EndTime: {userInput.EndTime}, Duration: {userInput.Duration}");

                }
            }
        }
    }
}
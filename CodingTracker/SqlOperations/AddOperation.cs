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
    public class AddOperation : ISqliteOperations
    {
        private readonly string _connectionString;
        private readonly UserInputHandler _userInputHandler;


        public AddOperation(string connectionString, UserInputHandler userInputHandler)
        {
            _connectionString = connectionString;
            _userInputHandler = userInputHandler;

        }

        public void Execute()
        {
            UserInput userInput = _userInputHandler.GetUserInput();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO CodingTracker (Date, StartTime, EndTime) 
                    VALUES (@Date, @StartTime, @EndTime);
                ";

                var parameters = new
                {
                    Date = userInput.Date,
                    StartTime = userInput.StartTime,
                    EndTime = userInput.EndTime
                };

                connection.Execute(insertQuery, parameters);
            }
        }
    }
}

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
    public class UpdateOperation : ISqliteOperations
    {
        private readonly string _connectionString;
        private readonly UserInputHandler _userInputHandler;

        public UpdateOperation(string connectionString, UserInputHandler userInputHandler)
        {
            _connectionString = connectionString;
            _userInputHandler = userInputHandler;

        }

        public void Execute()
        {
            try
            {
                bool isRecordFound = false;

                while (!isRecordFound)
                {

                    Console.WriteLine("Enter the Id of the record you want to update: ");
                    int id = int.Parse(Console.ReadLine());

                    UserInput userInput = _userInputHandler.GetUserInput();
                    userInput.Id = id;

                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();

                        string updateQuery = @"
                    UPDATE CodingTracker
                    SET Date = @Date, StartTime = @StartTime, EndTime = @EndTime, Duration = @Duration
                    WHERE Id = @Id;
                ";

                        var parameters = new
                        {
                            Date = userInput.Date,
                            StartTime = userInput.StartTime,
                            EndTime = userInput.EndTime,
                            Duration = userInput.Duration,
                            Id = userInput.Id
                        };

                        int rowAffected = connection.Execute(updateQuery, parameters);

                        if (rowAffected > 0)
                        {
                            ConsoleMessages.ShowSuccessMessage("Record updated successfully");
                            isRecordFound = true;
                        }
                        else
                        {
                            ConsoleMessages.ShowErrorMessage("Record not found. Please try again or type 'Exit' to cancel");
                            string userInputString = Console.ReadLine();

                            if (userInputString.ToLower() == "exit")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleMessages.ShowErrorMessage(ex.Message);
            }
        }
    }
}
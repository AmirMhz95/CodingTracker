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
    public class DeleteOperation : ISqliteOperations
    {
        private readonly string _connectionString;

        public DeleteOperation(string connectionString)
        {
            _connectionString = connectionString;

        }

        public void Execute()
        {
            try
            {
                bool isRecordFound = false;

                while (!isRecordFound)
                {

                    Console.WriteLine("Enter the Id of the record you want to delete: ");
                    int id = int.Parse(Console.ReadLine());

                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();

                        string deleteQuery = @"DELETE FROM CodingTracker WHERE Id = @Id";

                        var parameters = new
                        {
                            Id = id
                        };

                        int rowAffected = connection.Execute(deleteQuery, parameters);

                        if (rowAffected > 0)
                        {
                            ConsoleMessages.ShowSuccessMessage("Record deleted successfully");
                            isRecordFound = true;
                        }
                        else
                        {
                            ConsoleMessages.ShowErrorMessage("Record not found. Please try again or type 'Exit' to cancel");
                            string userInput = Console.ReadLine();

                            if (userInput.ToLower() == "exit")
                            {
                                break;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using SqlOperations;
using Dapper;
using UserInputs;

public class Program
{
    public static void Main(string[] args)
    {

        string connectionString = ConfigurationManager.AppSettings.Get("DefaultConnection");

        DatabaseInitializer.CreateTable(connectionString);

        bool exit = false;

        while (!exit)
        {

            ConsoleMessages.ShowMenuMessage();
            string? choice = Console.ReadLine();

            try
            {
                ISqliteOperations operation = null;

                switch (choice)
                {
                    case "1":
                        IInputHandler<DateTime> dateInputHandler = new DateInputHandler();
                        IInputHandler<TimeSpan> startTimeInputHandler = new StartTimeInputHandler();
                        IInputHandler<TimeSpan> endTimeInputHandler = new EndTimeInputHandler();


                        operation = new AddOperation(connectionString, new UserInputHandler(dateInputHandler, startTimeInputHandler, endTimeInputHandler));
                        operation.Execute();
                        ConsoleMessages.ShowSuccessMessage("Entry added successfully");
                        break;

                    case "2":

                        operation = new ReadOperation(connectionString);
                        operation.Execute();
                        break;

                    case "3":

                        IInputHandler<DateTime> dateInputHandlerForUpdate = new DateInputHandler();
                        IInputHandler<TimeSpan> startTimeInputHandlerForUpdate = new StartTimeInputHandler();
                        IInputHandler<TimeSpan> endTimeInputHandlerForUpdate = new EndTimeInputHandler();

                        operation = new UpdateOperation(connectionString, new UserInputHandler(dateInputHandlerForUpdate, startTimeInputHandlerForUpdate, endTimeInputHandlerForUpdate));
                        operation.Execute();
                        break;

                    case "4":
                        operation = new DeleteOperation(connectionString);
                        operation.Execute();
                        break;

                    case "5":
                        ConsoleMessages.ShowExitMessage("Exiting the application");
                        exit = true;
                        break;

                    default:
                        throw new InvalidOperationException("Invalid choice. Please select a valid option.");
                }
            }
            catch (InvalidOperationException ex)
            {
                ConsoleMessages.ShowErrorMessage(ex.Message);
            }
        }
    }
}
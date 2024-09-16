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
                switch (choice)
                {
                    case "1":
                        IInputHandler<DateTime> dateInputHandler = new DateInputHandler();
                        IInputHandler<TimeSpan> startTimeInputHandler = new StartTimeInputHandler();
                        IInputHandler<TimeSpan> endTimeInputHandler = new EndTimeInputHandler();


                        AddOperation addOperation = new AddOperation(connectionString, new UserInputHandler(dateInputHandler, startTimeInputHandler, endTimeInputHandler));
                        addOperation.Execute();
                        ConsoleMessages.ShowSuccessMessage("Entry added successfully");
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
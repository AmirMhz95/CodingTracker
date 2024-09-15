using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using SqlOperations;
using Dapper;

public class Program
{
    public static void Main(string[] args)
    {

        string connectionString = ConfigurationManager.AppSettings.Get("DefaultConnection");

        DatabaseInitializer.CreateTable(connectionString);
    }
}
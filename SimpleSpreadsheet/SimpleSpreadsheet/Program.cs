using System;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Parser;
using SimpleSpreadsheet.Printer;

namespace SimpleSpreadsheet
{
  class Program
  {
    static void Main(string[] args)
    {
      ICommandLineArgumentsParser parser = new CommandLineArgumentsParser();
      IPrinter printer = new Printer.Printer();
      var spreadSheet = new SpreadSheet();

      while (true)
      {
        Console.Write("enter command: ");
        var input = Console.ReadLine();
        try
        {
          var parseResult = parser.Parse(input);
          var command = parseResult.Command;
          var validator = parseResult.Validator;
          command.ExecuteCommand(spreadSheet, validator);
          printer.Print(spreadSheet);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
}
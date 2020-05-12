using System;
using System.Linq;
using SimpleSpreadsheet.Exceptions;
using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Parser
{
  public class CommandLineArgumentsParser : ICommandLineArgumentsParser
  {
    public Command GetCommand(string args)
    {
      if (string.IsNullOrWhiteSpace(args))
      {
        throw new ArgumentException("Cannot be empty or white space", nameof(args));
      }

      var splitted = args.Split();
      var commandType = splitted[0];
      var commandArgs = splitted.Skip(1).ToArray();
      int argsCount = 0;

      switch (commandType)
      {
        case "C":
          argsCount = 2;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return Command.CreateNewSpreadSheet;
          }
          throw new ArgumentException("Invalid command format, should be: C w h", nameof(args));
        case "N":
          argsCount = 3;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return Command.InsertNumber;
          }
          throw new ArgumentException("Invalid command format, should be: N x1 y1 v1", nameof(args));
        case "S":
          argsCount = 6;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return Command.PerformSum;
          }
          throw new ArgumentException("Invalid command format, should be: S x1 y1 x2 y2 x3 y3", nameof(args));
        case "Q":
          return Command.Quit;
        default:
          throw new ParserException("Unknown command");
      }
    }

    private bool IsValidArgs(string[] commandArgs, int argsCount)
    {
      if (commandArgs.Length == argsCount
        && commandArgs.All(s => IsPositiveNumber(s)))
      {
        return true;
      }
      return false;
    }

    private static bool IsPositiveNumber(string s)
    {
      bool isInt = int.TryParse(s, out int number);

      return (isInt && number >= 0)
        ? true
        : false;
    }
  }
}

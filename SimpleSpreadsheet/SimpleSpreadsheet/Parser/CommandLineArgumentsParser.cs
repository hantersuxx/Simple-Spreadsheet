using System;
using System.Linq;
using SimpleSpreadsheet.Exceptions;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Parser
{
  public class CommandLineArgumentsParser : ICommandLineArgumentsParser
  {
    public ParseResult Parse(string args)
    {
      if (string.IsNullOrWhiteSpace(args))
      {
        throw new ArgumentException("Cannot be empty or white space", nameof(args));
      }

      var splitted = args.Trim().Split();
      var commandType = splitted[0];
      var commandArgs = splitted.Skip(1).ToArray();
      int argsCount;

      switch (commandType)
      {
        case "C":
          argsCount = 2;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return GetCreateNewSpreadSheetParseResult(commandArgs);
          }

          throw new ParserException("Invalid command format, should be: C w h, where w h are positive integer numbers");
        case "N":
          argsCount = 3;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return GetInsertNumberParseResult(commandArgs);
          }

          throw new ParserException("Invalid command format, should be: N x1 y1 v1, where x1 y1 v1 are positive integer numbers");
        case "S":
          argsCount = 6;
          if (IsValidArgs(commandArgs, argsCount))
          {
            return GetPerformSumParseResult(commandArgs);
          }

          throw new ParserException("Invalid command format, should be: S x1 y1 x2 y2 x3 y3, where x1 y1 x2 y2 x3 y3 are positive integer numbers");
        case "Q":
          return GetQuitParseResult();
        default:
          throw new ParserException("Unknown command");
      }
    }

    private static ParseResult GetCreateNewSpreadSheetParseResult(string[] commandArgs)
    {
      int width = int.Parse(commandArgs[0]);
      int height = int.Parse(commandArgs[1]);

      var command = new CreateNewSpreadSheetCommand(width, height);
      var validator = new CreateNewSpreadSheetValidator();

      return new ParseResult
      {
        Command = command,
        Validator = validator,
      };
    }

    private static ParseResult GetInsertNumberParseResult(string[] commandArgs)
    {
      int x1 = int.Parse(commandArgs[0]);
      int y1 = int.Parse(commandArgs[1]);
      int v1 = int.Parse(commandArgs[2]);

      var command = new InsertNumberCommand(x1, y1, v1);
      var validator = new InsertNumberValidator();

      return new ParseResult
      {
        Command = command,
        Validator = validator,
      };
    }

    private static ParseResult GetPerformSumParseResult(string[] commandArgs)
    {
      int x1 = int.Parse(commandArgs[0]);
      int y1 = int.Parse(commandArgs[1]);
      int x2 = int.Parse(commandArgs[2]);
      int y2 = int.Parse(commandArgs[3]);
      int x3 = int.Parse(commandArgs[4]);
      int y3 = int.Parse(commandArgs[5]);

      var command = new PerformSumCommand(x1, y1, x2, y2, x3, y3);
      var validator = new PerformSumValidator();

      return new ParseResult
      {
        Command = command,
        Validator = validator,
      };
    }

    private static ParseResult GetQuitParseResult()
    {
      var command = new QuitCommand();
      var validator = new QuitValidator();

      return new ParseResult
      {
        Command = command,
        Validator = validator,
      };
    }

    private static bool IsValidArgs(string[] commandArgs, int argsCount)
    {
      if (commandArgs.Length == argsCount
        && commandArgs.All(IsPositiveIntegerNumber))
      {
        return true;
      }

      return false;
    }

    private static bool IsPositiveIntegerNumber(string s)
    {
      bool isInt = int.TryParse(s, out int number);

      return isInt && number >= 0;
    }
  }
}
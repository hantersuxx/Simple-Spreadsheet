using System;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Exceptions;

namespace SimpleSpreadsheet.Validations
{
  public class CreateNewSpreadSheetValidator : IValidator
  {
    public void Validate(SpreadSheet spreadSheet, IBaseCommand command)
    {
      var createNewSpreadSheetCommand = command as CreateNewSpreadSheetCommand;
      if (createNewSpreadSheetCommand == null)
      {
        throw new ArgumentException("Invalid command type", nameof(command));
      }

      if (createNewSpreadSheetCommand.Width <= 0)
      {
        throw new ValidationException($"Width should more than 0. Parameter name: {nameof(createNewSpreadSheetCommand.Width)}");
      }

      if (createNewSpreadSheetCommand.Height <= 0)
      {
        throw new ValidationException($"Height should more than 0. Parameter name: {nameof(createNewSpreadSheetCommand.Height)}");
      }

      // Breaks unit test because console window is not opened during tests I suppose
      if ((createNewSpreadSheetCommand.Width * Globals.CellSize) + 1 >= Console.WindowWidth)
      {
        throw new ValidationException($"Width should be less than window width. Parameter name: {createNewSpreadSheetCommand.Width}");
      }

      if (createNewSpreadSheetCommand.Height >= Console.WindowHeight)
      {
        throw new ValidationException($"Height should be less than window height. Parameter name: {nameof(createNewSpreadSheetCommand.Height)}");
      }
    }
  }
}

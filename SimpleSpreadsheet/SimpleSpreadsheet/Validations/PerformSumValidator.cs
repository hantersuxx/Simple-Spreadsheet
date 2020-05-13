using System;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Exceptions;
using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Validations
{
  public class PerformSumValidator : IValidator
  {
    public void Validate(SpreadSheet spreadSheet, IBaseCommand command)
    {
      var performSumCommand = command as PerformSumCommand;
      if (performSumCommand == null)
      {
        throw new ArgumentException("Invalid command type", nameof(command));
      }

      if (performSumCommand.X1 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"X1 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.X1)}");
      }

      if (performSumCommand.Y1 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"Y1 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.Y1)}");
      }

      if (performSumCommand.X2 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"X2 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.X2)}");
      }

      if (performSumCommand.Y2 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"Y2 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.Y2)}");
      }

      if (performSumCommand.X3 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"X3 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.X3)}");
      }

      if (performSumCommand.Y3 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"Y3 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(performSumCommand.Y3)}");
      }

      try
      {
        _ = spreadSheet[performSumCommand.X1, performSumCommand.Y1];
      }
      catch (IndexOutOfRangeException)
      {
        throw new ValidationException(
          $"Index is out of range of spread sheet. Parameter name: {nameof(performSumCommand.X1)} or {nameof(performSumCommand.Y1)}");
      }

      try
      {
        _ = spreadSheet[performSumCommand.X2, performSumCommand.Y2];
      }
      catch (IndexOutOfRangeException)
      {
        throw new ValidationException(
          $"Index is out of range of spread sheet. Parameter name: {nameof(performSumCommand.X2)} or {nameof(performSumCommand.Y2)}");
      }

      try
      {
        _ = spreadSheet[performSumCommand.X3, performSumCommand.Y3];
      }
      catch (IndexOutOfRangeException)
      {
        throw new ValidationException(
          $"Index is out of range of spread sheet. Parameter name: {nameof(performSumCommand.X3)} or {nameof(performSumCommand.Y3)}");
      }
    }
  }
}
using System;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Exceptions;

namespace SimpleSpreadsheet.Validations
{
  public class InsertNumberValidator : IValidator
  {
    public void Validate(SpreadSheet spreadSheet, IBaseCommand command)
    {
      var insertNumberCommand = command as InsertNumberCommand;
      if (insertNumberCommand == null)
      {
        throw new ArgumentException("Invalid command type", nameof(command));
      }

      if (insertNumberCommand.X1 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"X1 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name: {nameof(insertNumberCommand.X1)}");
      }

      if (insertNumberCommand.Y1 < Globals.SpreadSheetStartIndex)
      {
        throw new ValidationException(
          $"Y1 should be greater than or equal to {Globals.SpreadSheetStartIndex}. Parameter name:"
          + $" {nameof(insertNumberCommand.Y1)}");
      }

      if (insertNumberCommand.V1 < 0)
      {
        throw new ValidationException($"V1 should be greater than 0. Parameter name: {nameof(insertNumberCommand.V1)}");
      }

      try
      {
        _ = spreadSheet[insertNumberCommand.X1, insertNumberCommand.Y1];
      }
      catch (IndexOutOfRangeException)
      {
        throw new ValidationException(
          $"Index is out of range of spread sheet. Parameter name: {nameof(insertNumberCommand.X1)} or {nameof(insertNumberCommand.Y1)}");
      }

      if (insertNumberCommand.V1.ToString().Length > Globals.CellSize)
      {
        throw new ValidationException(
          $"Inserted value is more than cell size. Parameter name: {nameof(insertNumberCommand.V1)}");
      }
    }
  }
}
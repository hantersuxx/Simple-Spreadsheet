using System;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Validations
{
  public class QuitValidator : IValidator
  {
    public void Validate(SpreadSheet spreadSheet, IBaseCommand command)
    {
      var quitCommand = command as QuitCommand;
      if (quitCommand == null)
      {
        throw new ArgumentException("Invalid command type", nameof(command));
      }
    }
  }
}
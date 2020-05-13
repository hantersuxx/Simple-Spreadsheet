using System;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  /// <summary>
  /// Should quit the program.
  /// </summary>
  public class QuitCommand : BaseCommand
  {
    public override void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator)
    {
      base.ExecuteCommand(spreadSheet, validator);
      Environment.Exit(0);
    }
  }
}
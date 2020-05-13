using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  /// <summary>
  /// Should insert a number in specified cell (x1, y1)
  /// </summary>
  public class InsertNumberCommand : BaseCommand
  {
    public InsertNumberCommand(int x1, int y1, int v1)
    {
      X1 = x1;
      Y1 = y1;
      V1 = v1;
    }

    public int X1 { get; }

    public int Y1 { get; }

    public int V1 { get; }

    public override void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator)
    {
      base.ExecuteCommand(spreadSheet, validator);
      InsertValueIntoCell(spreadSheet);
    }

    private void InsertValueIntoCell(SpreadSheet spreadSheet)
    {
      var cell = spreadSheet[X1, Y1];
      cell.Value = V1;
    }
  }
}
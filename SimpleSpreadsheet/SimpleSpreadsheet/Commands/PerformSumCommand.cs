using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  /// <summary>
  /// Should perform sum of all cells in rectangle from (x1, y1) to (x2, y2) and store the result in (x3, y3)
  /// </summary>
  public class PerformSumCommand : BaseCommand
  {
    public PerformSumCommand(int x1, int y1, int x2, int y2, int x3, int y3)
    {
      X1 = x1;
      Y1 = y1;
      X2 = x2;
      Y2 = y2;
      X3 = x3;
      Y3 = y3;
    }

    public int X1 { get; }

    public int Y1 { get; }

    public int X2 { get; }

    public int Y2 { get; }

    public int X3 { get; }

    public int Y3 { get; }

    public override void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator)
    {
      base.ExecuteCommand(spreadSheet, validator);
      int sum = GetSum(spreadSheet);
      InsertNumber(spreadSheet, sum);
    }

    private int GetSum(SpreadSheet spreadSheet)
    {
      int startY, endY;
      if (Y1 >= Y2)
      {
        startY = Y2;
        endY = Y1;
      }
      else
      {
        startY = Y1;
        endY = Y2;
      }

      int startX, endX;
      if (X1 >= X2)
      {
        startX = X2;
        endX = X1;
      }
      else
      {
        startX = X1;
        endX = X2;
      }

      int sum = 0;
      for (int y = startY; y <= endY; y++)
      {
        for (int x = startX; x <= endX; x++)
        {
          var cell = spreadSheet[x, y];
          sum += cell.Value ?? 0;
        }
      }

      return sum;
    }

    private void InsertNumber(SpreadSheet spreadSheet, int sum)
    {
      var insertNumberCommand = new InsertNumberCommand(X3, Y3, sum);
      var insertNumberValidator = new InsertNumberValidator();
      insertNumberCommand.ExecuteCommand(spreadSheet, insertNumberValidator);
    }
  }
}
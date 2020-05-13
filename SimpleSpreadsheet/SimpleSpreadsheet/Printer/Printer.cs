using System;
using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Printer
{
  public class Printer : IPrinter
  {
    public void Print(SpreadSheet spreadSheet)
    {
      if (spreadSheet == null)
      {
        throw new ArgumentNullException(nameof(spreadSheet));
      }

      PrintBorder(spreadSheet);
      PrintSpreadSheet(spreadSheet);
      PrintBorder(spreadSheet);
    }

    private void PrintSpreadSheet(SpreadSheet spreadSheet)
    {
      for (int y = Globals.SpreadSheetStartIndex; y <= spreadSheet.Height; y++)
      {
        Console.Write(Globals.SideBorder);
        for (int x = Globals.SpreadSheetStartIndex; x <= spreadSheet.Width; x++)
        {
          PrintCell(spreadSheet[x, y]);
        }
        Console.Write(Globals.SideBorder);
        Console.Write(Environment.NewLine);
      }
    }

    private void PrintCell(Cell cell)
    {
      var str = cell.Value.ToString();
      var diffCount = Math.Abs(str.Length - Globals.CellSize);
      var spaces = new string(Globals.CellSpace, diffCount);
      Console.Write(spaces + str);
    }

    private void PrintBorder(SpreadSheet spreadSheet)
    {
      int count = (spreadSheet.Width * Globals.CellSize) + 1;
      var border = new string(Globals.Border, count);
      Console.WriteLine(border);
    }
  }
}
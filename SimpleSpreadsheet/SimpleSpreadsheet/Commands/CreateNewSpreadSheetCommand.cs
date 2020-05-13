using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  /// <summary>
  /// Should create a new spread sheet of width w and height h (i.e. the spreadsheet can hold w * h cells).
  /// </summary>
  public class CreateNewSpreadSheetCommand : BaseCommand
  {
    public CreateNewSpreadSheetCommand(int width, int height)
    {
      Width = width;
      Height = height;
    }

    public int Width { get; }

    public int Height { get; }

    public override void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator)
    {
      base.ExecuteCommand(spreadSheet, validator);
      PopulateSpreadSheet(spreadSheet);
    }

    private void PopulateSpreadSheet(SpreadSheet spreadSheet)
    {
      spreadSheet.Cells.Clear();
      for (int y = Globals.SpreadSheetStartIndex; y <= Height; y++)
      {
        for (int x = Globals.SpreadSheetStartIndex; x <= Width; x++)
        {
          spreadSheet.Cells.Add(new Cell(x, y));
        }
      }
    }
  }
}
namespace SimpleSpreadsheet.Models
{
  /// <summary>
  /// Basic spreadsheet operations. 
  /// </summary>
  public enum Command
  {
    /// <summary>
    /// Should create a new spread sheet of width w and height h (i.e. the spreadsheet can hold w * h cells).
    /// </summary>
    CreateNewSpreadSheet,

    /// <summary>
    /// Should insert a number in specified cell (x1, y1)
    /// </summary>
    InsertNumber,

    /// <summary>
    /// Should perform sum of all cells in rectangle from (x1, y1) to (x2, y2) and store the result in (x3, y3)
    /// </summary>
    PerformSum,

    /// <summary>
    /// Should quit the program.
    /// </summary>
    Quit,
  }
}

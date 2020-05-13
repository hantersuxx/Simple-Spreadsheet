namespace SimpleSpreadsheet.Models
{
  /// <summary>
  /// Global static properties for the project to prevent "magic" values
  /// </summary>
  public static class Globals
  {
    /// <summary>
    /// One cell size in characters
    /// </summary>
    public static int CellSize => 3;

    /// <summary>
    /// Character which is used for cell's empty space filling
    /// </summary>
    public static char CellSpace => ' ';

    /// <summary>
    /// Top and bottom border character
    /// </summary>
    public static char Border => '-';

    /// <summary>
    /// Left and right side border character
    /// </summary>
    public static char SideBorder => '|';

    /// <summary>
    /// Index from which the countdown begins in spread sheet
    /// </summary>
    public static int SpreadSheetStartIndex => 1;
  }
}

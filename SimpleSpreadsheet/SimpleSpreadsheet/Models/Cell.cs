namespace SimpleSpreadsheet.Models
{
  /// <summary>
  /// Represents cell object
  /// </summary>
  public class Cell
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public Cell(int x, int y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="value">Value of the cell</param>
    public Cell(int x, int y, int value)
      : this(x, y)
    {
      Value = value;
    }

    /// <summary>
    /// Gets X coordinate
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Gets Y coordinate
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Gets or sets the value of the cell
    /// </summary>
    public int? Value { get; set; }
  }
}
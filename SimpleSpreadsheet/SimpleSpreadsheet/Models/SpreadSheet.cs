using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSpreadsheet.Models
{
  /// <summary>
  /// Represents spread sheet object
  /// </summary>
  public class SpreadSheet
  {
    /// <summary>
    /// Gets the list of cells
    /// </summary>
    public List<Cell> Cells { get; } = new List<Cell>();

    /// <summary>
    /// Gets spread sheet width in cells
    /// </summary>
    public int Width
    {
      get
      {
        return Cells.OrderByDescending(cell => cell.X).FirstOrDefault()?.X ?? 0;
      }
    }

    /// <summary>
    /// Gets spread sheet height in cells
    /// </summary>
    public int Height
    {
      get
      {
        return Cells.OrderByDescending(cell => cell.Y).FirstOrDefault()?.Y ?? 0;
      }
    }

    /// <summary>
    /// Gets the cell by x and y coordinates
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns><see cref="Cell"/>/></returns>
    public Cell this[int x, int y]
    {
      get
      {
        var result = Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        if (result == null)
        {
          throw new IndexOutOfRangeException();
        }

        return result;
      }
    }
  }
}

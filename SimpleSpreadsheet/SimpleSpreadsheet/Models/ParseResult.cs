using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Models
{
  public class ParseResult
  {
    public IBaseCommand Command { get; set; }

    public IValidator Validator { get; set; }
  }
}
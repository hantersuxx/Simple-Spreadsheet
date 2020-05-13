using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Validations
{
  public interface IValidator
  {
    void Validate(SpreadSheet spreadSheet, IBaseCommand command);
  }
}
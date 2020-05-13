using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  public interface IBaseCommand
  {
    void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator);
  }
}
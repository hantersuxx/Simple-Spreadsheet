using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Commands
{
  public abstract class BaseCommand : IBaseCommand
  {
    public virtual void ExecuteCommand(SpreadSheet spreadSheet, IValidator validator)
    {
      validator.Validate(spreadSheet, this);
    }
  }
}
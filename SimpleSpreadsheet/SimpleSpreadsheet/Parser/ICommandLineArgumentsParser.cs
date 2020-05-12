using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Parser
{
  public interface ICommandLineArgumentsParser
  {
    Command GetCommand(string args);
  }
}
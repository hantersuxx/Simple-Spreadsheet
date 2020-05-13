using SimpleSpreadsheet.Models;

namespace SimpleSpreadsheet.Parser
{
  public interface ICommandLineArgumentsParser
  {
    ParseResult Parse(string args);
  }
}
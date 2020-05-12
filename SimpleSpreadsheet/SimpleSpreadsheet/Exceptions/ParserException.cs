using System;
using System.Runtime.Serialization;

namespace SimpleSpreadsheet.Exceptions
{
  [Serializable]
  public class ParserException : SimpleSpreadSheetBaseException
  {
    public ParserException()
    {
    }

    public ParserException(string message)
      : base(message)
    {
    }

    public ParserException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected ParserException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
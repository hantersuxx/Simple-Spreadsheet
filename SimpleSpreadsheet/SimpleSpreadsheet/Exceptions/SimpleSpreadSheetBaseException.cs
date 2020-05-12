using System;
using System.Runtime.Serialization;

namespace SimpleSpreadsheet.Exceptions
{
  [Serializable]
  public class SimpleSpreadSheetBaseException : Exception
  {
    public SimpleSpreadSheetBaseException()
    {
    }

    public SimpleSpreadSheetBaseException(string message)
      : base(message)
    {
    }

    public SimpleSpreadSheetBaseException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected SimpleSpreadSheetBaseException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
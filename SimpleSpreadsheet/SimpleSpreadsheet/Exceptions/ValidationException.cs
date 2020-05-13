using System;
using System.Runtime.Serialization;

namespace SimpleSpreadsheet.Exceptions
{
  [Serializable]
  public class ValidationException : SimpleSpreadSheetBaseException
  {
    public ValidationException()
    {
    }

    public ValidationException(string message)
      : base(message)
    {
    }

    public ValidationException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected ValidationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
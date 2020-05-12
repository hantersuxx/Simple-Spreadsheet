using SimpleSpreadsheet.Parser;
using System;

namespace SimpleSpreadsheet
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var a = new A();
      var b = new B();
      A ba = new B();

      Console.WriteLine(a is A);
      Console.WriteLine(a is B);

      Console.WriteLine(b is A);
      Console.WriteLine(b is B);

      Console.WriteLine(ba is A);
      Console.WriteLine(ba is B);
      Console.WriteLine(ba is C);

      ICommandLineArgumentsParser parser = new CommandLineArgumentsParser();

      Console.WriteLine(parser.GetCommand(Console.ReadLine()));
    }
  }

  class A { }

  class B : A { }

  class C : A { }
}

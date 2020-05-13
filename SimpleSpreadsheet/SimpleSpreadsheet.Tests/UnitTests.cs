using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpreadsheet.Commands;
using SimpleSpreadsheet.Exceptions;
using SimpleSpreadsheet.Models;
using SimpleSpreadsheet.Parser;
using SimpleSpreadsheet.Validations;

namespace SimpleSpreadsheet.Tests
{
  [TestClass]
  public class UnitTests
  {
    [TestMethod]
    public void Empty_SpreadSheet_Width_Equals_Zero()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();

      // assert
      Assert.AreEqual(0, spreadSheet.Width);
    }

    [TestMethod]
    public void Empty_SpreadSheet_Height_Equals_Zero()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();

      // assert
      Assert.AreEqual(0, spreadSheet.Height);
    }

    [TestMethod]
    public void Empty_SpreadSheet_Index_Operator_Throws_Exception()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();

      // assert
      Assert.ThrowsException<IndexOutOfRangeException>(() => spreadSheet[1, 1]);
    }

    [TestMethod]
    public void SpreadSheet_Index_Operator()
    {
      // arrange
      var spreadSheet = new SpreadSheet();
      var expectedCell = new Cell(1, 1);
      spreadSheet.Cells.Add(expectedCell);

      // act
      var actualCell = spreadSheet[1, 1];

      // assert
      Assert.AreEqual(expectedCell, actualCell);
      Assert.AreEqual(expectedCell.X, actualCell.X);
      Assert.AreEqual(expectedCell.Y, actualCell.Y);
      Assert.AreEqual(expectedCell.Value, actualCell.Value);
    }

    #region CreateNewSpreadSheet

    [TestMethod]
    public void CreateNewSpreadSheet_With_Negative_Width_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var createNewSpreadSheetCommand = new CreateNewSpreadSheetCommand(-1, 1);
      var createNewSpreadSheetValidator = new CreateNewSpreadSheetValidator();

      // assert
      Assert.ThrowsException<ValidationException>(
        () => createNewSpreadSheetValidator.Validate(spreadSheet, createNewSpreadSheetCommand));
    }

    [TestMethod]
    public void CreateNewSpreadSheet_With_Negative_Height_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var createNewSpreadSheetCommand = new CreateNewSpreadSheetCommand(1, -1);
      var createNewSpreadSheetValidator = new CreateNewSpreadSheetValidator();

      // assert
      Assert.ThrowsException<ValidationException>(
        () => createNewSpreadSheetValidator.Validate(spreadSheet, createNewSpreadSheetCommand));
    }

    [TestMethod]
    public void CreateNewSpreadSheet_With_Zero_Width_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var createNewSpreadSheetCommand = new CreateNewSpreadSheetCommand(0, 1);
      var createNewSpreadSheetValidator = new CreateNewSpreadSheetValidator();

      // assert
      Assert.ThrowsException<ValidationException>(
        () => createNewSpreadSheetValidator.Validate(spreadSheet, createNewSpreadSheetCommand));
    }

    [TestMethod]
    public void CreateNewSpreadSheet_With_Zero_Height_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var createNewSpreadSheetCommand = new CreateNewSpreadSheetCommand(1, 0);
      var createNewSpreadSheetValidator = new CreateNewSpreadSheetValidator();

      // assert
      Assert.ThrowsException<ValidationException>(
        () => createNewSpreadSheetValidator.Validate(spreadSheet, createNewSpreadSheetCommand));
    }

    //[TestMethod]
    //public void CreateNewSpreadSheet_Command()
    //{
    //  // arrange
    //  int width = 20, height = 20;
    //  var spreadSheet = new SpreadSheet();
    //  var createNewSpreadSheetCommand = new CreateNewSpreadSheetCommand(width, height);
    //  var createNewSpreadSheetValidator = new CreateNewSpreadSheetValidator();

    //  // act
    //  createNewSpreadSheetCommand.ExecuteCommand(spreadSheet, createNewSpreadSheetValidator);

    //  // assert
    //  Assert.AreEqual(width, spreadSheet.Width);
    //  Assert.AreEqual(height, spreadSheet.Height);
    //  Assert.AreEqual(width * height, spreadSheet.Cells.Count);
    //}

    #endregion

    #region InsertNumber

    [TestMethod]
    public void InsertNumberValidator_With_Zero_X1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(0, 1, 1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Zero_Y1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(1, 0, 1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Zero_V1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(1, 1, 0);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Negative_X1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(-1, 1, 1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Negative_Y1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(1, -1, 1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Negative_V1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new InsertNumberCommand(1, 1, -1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_With_Big_V1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      var command = new InsertNumberCommand(1, 1, 999999999);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumberValidator_Out_Of_Range_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      var command = new InsertNumberCommand(1, 20, 1);
      var validator = new InsertNumberValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void InsertNumber_Command()
    {
      // arrange
      var spreadSheet = new SpreadSheet();
      int x1 = 1, y1 = 1, v1 = 1;
      spreadSheet.Cells.Add(new Cell(x1, y1));
      var command = new InsertNumberCommand(x1, y1, v1);
      var validator = new InsertNumberValidator();

      // act
      command.ExecuteCommand(spreadSheet, validator);

      // assert
      Assert.AreEqual(v1, spreadSheet[x1, y1].Value);
    }

    #endregion

    #region PerformSum

    [TestMethod]
    public void PerformSumValidator_Out_Of_Range_X1Y1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(4, 1, 2, 1, 3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_Out_Of_Range_X2Y2_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 1, 2, 3, 3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_Out_Of_Range_X3Y3_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 1, 2, 1, 4, 4);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_X1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(-1, 1, 2, 1, 4, 4);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_Y1_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, -1, 2, 1, 3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_X2_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 1, -2, 1, 3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_Y2_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 2, 2, -1, 3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_X3_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 1, 2, 1, -3, 1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSumValidator_With_Negative_Y3_Throws_ValidationException()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      spreadSheet.Cells.Add(new Cell(1, 1));
      spreadSheet.Cells.Add(new Cell(2, 1));
      spreadSheet.Cells.Add(new Cell(3, 1));
      var command = new PerformSumCommand(1, 2, 2, 1, 3, -1);
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ValidationException>(() => validator.Validate(spreadSheet, command));
    }

    [TestMethod]
    public void PerformSum_Command()
    {
      // arrange
      var spreadSheet = new SpreadSheet();
      int x1 = 1, y1 = 1, v1 = 1,
          x2 = 2, y2 = 1, v2 = 2,
          x3 = 3, y3 = 1, v3 = 3;
      spreadSheet.Cells.Add(new Cell(x1, y1, v1));
      spreadSheet.Cells.Add(new Cell(x2, y2, v2));
      spreadSheet.Cells.Add(new Cell(x3, y3, v3));
      var command = new PerformSumCommand(x1, y1, x2, y2, x3, y3);
      var validator = new PerformSumValidator();

      // act
      command.ExecuteCommand(spreadSheet, validator);

      // assert
      Assert.AreEqual(v1 + v2, spreadSheet[x3, y3].Value);
    }

    #endregion

    #region Quit

    [TestMethod]
    public void QuitValidator()
    {
      // arrange
      var spreadSheet = new SpreadSheet();
      var command = new QuitCommand();
      var validator = new QuitValidator();

      // act
      validator.Validate(spreadSheet, command);

      // assert
      Assert.IsTrue(true);
    }

    [TestMethod]
    public void QuitValidator_Invalid_Type()
    {
      // arrange
      // act
      var spreadSheet = new SpreadSheet();
      var command = new QuitCommand();
      var validator = new PerformSumValidator();

      // assert
      Assert.ThrowsException<ArgumentException>(() => validator.Validate(spreadSheet, command));
    }

    #endregion

    #region Parser

    [TestMethod]
    public void Parser_Invalid_Command()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "I";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_CreateNewSpreadSheet_Invalid_Command()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "C w h";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_InsertNumber_Invalid_Command()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "N x1 y1 v1";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_PerformSum_Invalid_Command()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "S x1 y1 x2 y2 x3 y3";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_Invalid_Command_Float()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "C 2.5 4,23";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_Invalid_Command_Negative()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "C -2 -2";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_Invalid_Command_Spaces()
    {
      // arrange
      // act
      var parser = new CommandLineArgumentsParser();
      var args = "   C     -2  -2  ";

      // assert
      Assert.ThrowsException<ParserException>(() => parser.Parse(args));
    }

    [TestMethod]
    public void Parser_CreateNewSpreadSheet_Command()
    {
      // arrange
      var parser = new CommandLineArgumentsParser();
      var args = "C 1 1";

      // act
      var result = parser.Parse(args);

      // assert
      Assert.IsInstanceOfType(result.Command, typeof(CreateNewSpreadSheetCommand));
      Assert.IsInstanceOfType(result.Validator, typeof(CreateNewSpreadSheetValidator));
    }

    [TestMethod]
    public void Parser_InsertNumber_Command()
    {
      // arrange
      var parser = new CommandLineArgumentsParser();
      var args = "N 1 1 1";

      // act
      var result = parser.Parse(args);

      // assert
      Assert.IsInstanceOfType(result.Command, typeof(InsertNumberCommand));
      Assert.IsInstanceOfType(result.Validator, typeof(InsertNumberValidator));
    }

    [TestMethod]
    public void Parser_PerformSum_Command()
    {
      // arrange
      var parser = new CommandLineArgumentsParser();
      var args = "S 1 1 2 1 3 1";

      // act
      var result = parser.Parse(args);

      // assert
      Assert.IsInstanceOfType(result.Command, typeof(PerformSumCommand));
      Assert.IsInstanceOfType(result.Validator, typeof(PerformSumValidator));
    }

    [TestMethod]
    public void Parser_Quit_Command()
    {
      // arrange
      var parser = new CommandLineArgumentsParser();
      var args = "Q";

      // act
      var result = parser.Parse(args);

      // assert
      Assert.IsInstanceOfType(result.Command, typeof(QuitCommand));
      Assert.IsInstanceOfType(result.Validator, typeof(QuitValidator));
    }

    #endregion
  }
}
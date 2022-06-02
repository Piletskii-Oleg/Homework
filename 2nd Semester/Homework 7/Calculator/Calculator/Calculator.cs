﻿namespace Calculator;

using System.Globalization;

/// <summary>
/// Calculator that calculates values immediately.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Gets first operand of the expression.
    /// </summary>
    public string FirstOperand { get; private set; } = string.Empty;

    /// <summary>
    /// Gets second operand of the expression.
    /// </summary>
    public string SecondOperand { get; private set; } = string.Empty;

    /// <summary>
    /// Gets operator of the expression.
    /// </summary>
    public char Operator { get; private set; } = ' ';

    /// <summary>
    /// Action that happens when button corresponding to a digit is pressed.
    /// </summary>
    /// <param name="digit">Digit on the calculator that was pressed.</param>
    /// <exception cref="ArgumentException">Throws if anything other than a digit is passed.</exception>
    public void OperandPress(string digit)
    {
        if (digit.Length > 1 || digit.Any(x => !char.IsDigit(x)))
        {
            throw new ArgumentException("Argument was not a single digit", nameof(digit));
        }
        else if (this.Operator == ' ')
        {
            this.FirstOperand += digit;
        }
        else
        {
            this.SecondOperand += digit;
        }
    }

    /// <summary>
    /// Action that happens when button corresponding to an operator is pressed.
    /// </summary>
    /// <param name="inputOperator">Operator on the calculator that was pressed.</param>
    /// <exception cref="DivideByZeroException">Throws if division by zero happens.</exception>
    /// <exception cref="ArgumentException">Throws if the passed operator was not valid.</exception>
    public void OperatorPress(string inputOperator)
    {
        if (this.FirstOperand == string.Empty)
        {
            return;
        }
        else if (this.SecondOperand == string.Empty)
        {
            if (inputOperator == "Sqrt")
            {
                this.FirstOperand = Math.Sqrt(double.Parse(this.FirstOperand)).ToString("G30", CultureInfo.GetCultureInfo("ru-RU"));
            }
            else
            {
                this.Operator = inputOperator[0];
            }
        }
        else
        {
            this.FirstOperand = this.FirstOperand.Replace(',', '.');
            this.SecondOperand = this.SecondOperand.Replace(',', '.');
            var decimalFirst = decimal.Parse(this.FirstOperand, CultureInfo.GetCultureInfo("en-US"));
            var decimalSecond = decimal.Parse(this.SecondOperand, CultureInfo.GetCultureInfo("en-US"));
            switch (this.Operator)
            {
                case '+':
                    this.FirstOperand = (decimalFirst + decimalSecond).ToString("G30", CultureInfo.GetCultureInfo("ru-RU"));
                    break;
                case '-':
                    this.FirstOperand = (decimalFirst - decimalSecond).ToString("G30", CultureInfo.GetCultureInfo("ru-RU"));
                    break;
                case '*':
                    this.FirstOperand = (decimalFirst * decimalSecond).ToString("G30", CultureInfo.GetCultureInfo("ru-RU"));
                    break;
                case '/':
                    decimal threshold = 10e-15M;
                    if (Math.Abs(decimalSecond) < threshold)
                    {
                        this.Clear();
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        this.FirstOperand = (decimalFirst / decimalSecond).ToString("G30", CultureInfo.GetCultureInfo("ru-RU"));
                    }

                    break;
                default:
                    throw new ArgumentException("Argument was not a correct operation", nameof(inputOperator));
            }

            this.Operator = this.Operator == '=' ? ' ' : inputOperator[0];
            this.SecondOperand = string.Empty;
        }
    }

    /// <summary>
    /// Action that happens when button corresponding to comma is pressed.
    /// </summary>
    public void DecimalPress()
    {
        if (this.SecondOperand != string.Empty)
        {
            this.SecondOperand += this.SecondOperand.Contains(',') ? string.Empty : ",";
        }
        else if (this.FirstOperand != string.Empty)
        {
            this.FirstOperand += this.FirstOperand.Contains(',') ? string.Empty : ",";
        }
        else
        {
            this.FirstOperand = "0,";
        }
    }

    /// <summary>
    /// Action that happens when button corresponding to sign change is pressed.
    /// </summary>
    public void ChangeSignPress()
    {
        if (this.SecondOperand != string.Empty)
        {
            this.SecondOperand = ChangeSign(this.SecondOperand);
        }
        else if (this.FirstOperand != string.Empty)
        {
            this.FirstOperand = ChangeSign(this.FirstOperand);
        }
    }

    /// <summary>
    /// Action that happens when button corresponding to clearing the window is pressed.
    /// </summary>
    public void Clear()
    {
        this.FirstOperand = string.Empty;
        this.SecondOperand = string.Empty;
        this.Operator = ' ';
    }

    /// <summary>
    /// Action that happens when button corresponding to removal of the last character is pressed.
    /// </summary>
    public void BackspacePress()
    {
        if (this.SecondOperand != string.Empty)
        {
            this.SecondOperand = this.SecondOperand.Remove(this.SecondOperand.Length - 1);
        }
        else if (this.Operator != ' ' && this.Operator != '=')
        {
            this.Operator = ' ';
        }
        else if (this.FirstOperand != string.Empty)
        {
            if (this.Operator == '=')
            {
                this.Operator = ' ';
            }

            this.FirstOperand = this.FirstOperand.Remove(this.FirstOperand.Length - 1);
        }
    }

    private static string ChangeSign(string number)
    {
        if (number == "0")
        {
            return number;
        }
        else if (decimal.Parse(number) > 0)
        {
            number = "-" + number;
        }
        else
        {
            number = number.Remove(0, 1);
        }

        return number;
    }
}
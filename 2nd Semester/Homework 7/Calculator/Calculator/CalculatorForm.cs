namespace Calculator;

/// <summary>
/// Calculator based on Windows Forms.
/// </summary>
public partial class CalculatorForm : Form
{
    private string firstOperand = string.Empty;
    private string secondOperand = string.Empty;
    private char currentOperator = ' ';

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
    }

    private static string ChangeSign(string number)
    {
        if (int.TryParse(number, out int _) && int.Parse(number) == double.Parse(number) && int.Parse(number) == 0)
        {
            return number;
        }
        else if (double.Parse(number) > 0)
        {
            number = "-" + number;
        }
        else
        {
            number = number.Remove(0, 1);
        }

        return number;
    }

    private void OnOperandClick(object sender, EventArgs e)
    {
        if (this.currentOperator == ' ')
        {
            this.firstOperand += (sender as Button)!.Text;
        }
        else
        {
            this.secondOperand += (sender as Button)!.Text;
        }

        this.PrintOnTextBox(sender, e);
    }

    private void OnOperatorClick(object sender, EventArgs e)
    {
        if (this.firstOperand == string.Empty)
        {
            return;
        }
        else if (this.secondOperand == string.Empty)
        {
            if ((sender as Button)!.Text == "Sqrt")
            {
                this.firstOperand = Math.Sqrt(double.Parse(this.firstOperand)).ToString();
            }
            else
            {
                this.currentOperator = (sender as Button)!.Text[0];
            }
        }
        else
        {
            var doubleFirst = double.Parse(this.firstOperand);
            var doubleSecond = double.Parse(this.secondOperand);
            switch (this.currentOperator)
            {
                case '+':
                    this.firstOperand = (doubleFirst + doubleSecond).ToString();
                    break;
                case '-':
                    this.firstOperand = (doubleFirst - doubleSecond).ToString();
                    break;
                case '*':
                    this.firstOperand = (doubleFirst * doubleSecond).ToString();
                    break;
                case '/':
                    double threshold = 10e-9;
                    if (doubleSecond < threshold)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        this.firstOperand = (doubleFirst / doubleSecond).ToString();
                    }

                    break;
            }

            this.currentOperator = this.currentOperator == '=' ? ' ' : (sender as Button)!.Text[0];
            this.secondOperand = string.Empty;
        }

        this.PrintOnTextBox(sender, e);
    }

    private void PrintOnTextBox(object sender, EventArgs e)
    {
        this.richTextBox1.Text = this.firstOperand + (this.currentOperator == ' ' || this.currentOperator == '=' ? string.Empty : this.currentOperator) + this.secondOperand;
    }

    private void OnButtonDecimalClick(object sender, EventArgs e)
    {
        if (this.secondOperand != string.Empty)
        {
            this.secondOperand += this.secondOperand.Contains(',') ? string.Empty : ",";
        }
        else if (this.firstOperand != string.Empty)
        {
            this.firstOperand += this.firstOperand.Contains(',') ? string.Empty : ",";
        }

        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonChangeSignClick(object sender, EventArgs e)
    {
        if (this.secondOperand != string.Empty)
        {
            this.secondOperand = ChangeSign(this.secondOperand);
        }
        else if (this.firstOperand != string.Empty)
        {
            this.firstOperand = ChangeSign(this.firstOperand);
        }

        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonClearClick(object sender, EventArgs e)
    {
        this.firstOperand = string.Empty;
        this.secondOperand = string.Empty;
        this.currentOperator = ' ';
        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonBackspaceClick(object sender, EventArgs e)
    {
        if (this.secondOperand != string.Empty)
        {
            this.secondOperand = this.secondOperand.Remove(this.secondOperand.Length - 1);
        }
        else if (this.currentOperator != ' ')
        {
            this.currentOperator = ' ';
            this.firstOperand = this.firstOperand.Remove(this.firstOperand.Length - 1);
        }
        else if (this.firstOperand != string.Empty)
        {
            this.firstOperand = this.firstOperand.Remove(this.firstOperand.Length - 1);
        }

        this.PrintOnTextBox(sender, e);
    }
}
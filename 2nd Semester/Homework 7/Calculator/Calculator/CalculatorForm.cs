namespace Calculator;

/// <summary>
/// Calculator on Windows Forms.
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly Calculator calc = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
    /// </summary>
    public CalculatorForm()
    {
        this.InitializeComponent();
    }

    private void OnOperandClick(object sender, EventArgs e)
    {
        this.calc.OperandPress((sender as Button)!.Text);
        this.PrintOnTextBox(sender, e);
    }

    private void OnOperatorClick(object sender, EventArgs e)
    {
        try
        {
            this.calc.OperatorPress((sender as Button)!.Text);
        }
        catch (DivideByZeroException)
        {
            this.richTextBox.Text = string.Empty;
        }

        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonDecimalClick(object sender, EventArgs e)
    {
        this.calc.DecimalPress();
        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonChangeSignClick(object sender, EventArgs e)
    {
        this.calc.ChangeSignPress();
        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonClearClick(object sender, EventArgs e)
    {
        this.calc.Clear();
        this.PrintOnTextBox(sender, e);
    }

    private void OnButtonBackspaceClick(object sender, EventArgs e)
    {
        this.calc.BackspacePress();
        this.PrintOnTextBox(sender, e);
    }

    private void PrintOnTextBox(object sender, EventArgs e)
    {
        this.richTextBox.Text = this.calc.FirstOperand
            + (this.calc.Operator == ' ' || this.calc.Operator == '=' ? string.Empty : this.calc.Operator)
            + this.calc.SecondOperand;
    }
}
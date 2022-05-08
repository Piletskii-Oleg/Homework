namespace Clock;

/// <summary>
/// An analogue clock built using Windows Forms.
/// </summary>
public partial class Clock : Form
{
    private readonly Point center;

    /// <summary>
    /// Initializes a new instance of the <see cref="Clock"/> class.
    /// </summary>
    public Clock()
    {
        this.InitializeComponent();
        this.pictureBox1.Paint += new PaintEventHandler(this.DrawHands);
        this.Controls.Add(this.pictureBox1);
        this.center = new Point(this.pictureBox1.Width / 2, this.pictureBox1.Height / 2);
    }

    private void DrawHands(object? sender, PaintEventArgs e)
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;
        int seconds = DateTime.Now.Second;

        double hourAngle = ((hours % 12) + ((double)minutes / 60)) * 30 * Math.PI / 180;
        double minuteAngle = (minutes + ((double)seconds / 60)) * 6 * Math.PI / 180;
        double secondAngle = seconds * 6 * Math.PI / 180;

        this.UpdateHand(e, hourAngle, 50, Color.Red);
        this.UpdateHand(e, minuteAngle, 80, Color.Blue);
        this.UpdateHand(e, secondAngle, 90, Color.Orange);
    }

    private void UpdateHand(PaintEventArgs e, double angle, int handLength, Color color)
    {
        var point = new Point(
            (int)((this.pictureBox1.Width / 2) + (handLength * Math.Sin(angle))),
            (int)((this.pictureBox1.Height / 2) - (handLength * Math.Cos(angle))));
        e.Graphics.DrawLine(new Pen(color), this.center, point);
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        this.pictureBox1.Refresh();
    }
}
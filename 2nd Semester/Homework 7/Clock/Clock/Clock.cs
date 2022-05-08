namespace Clock;

public partial class Clock : Form
{
    public Clock()
    {
        InitializeComponent();
        pictureBox1.Paint += new PaintEventHandler(DrawHands);
        Controls.Add(pictureBox1);
        center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
    }

    private Point center;

    private void DrawHands(object? sender, PaintEventArgs e)
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;
        int seconds = DateTime.Now.Second;

        double hourAngle = ((hours % 12) + (double)minutes / 60) * 30 * Math.PI / 180;
        double minuteAngle = (minutes + (double)seconds / 60) * 6 * Math.PI / 180;
        double secondAngle = seconds * 6 * Math.PI / 180;

        UpdateHand(e, hourAngle, 50, Color.Red);
        UpdateHand(e, minuteAngle, 80, Color.Blue);
        UpdateHand(e, secondAngle, 90, Color.Orange);
    }

    private void UpdateHand(PaintEventArgs e, double angle, int handLength, Color color)
    {
        e.Graphics.DrawLine(new Pen(color), center,
            new Point((int)(pictureBox1.Width / 2 + handLength * Math.Sin(angle)), (int)(pictureBox1.Height / 2 - handLength * Math.Cos(angle))));
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        pictureBox1.Refresh();
    }
}
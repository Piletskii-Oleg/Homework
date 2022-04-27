namespace Clock;

public partial class Clock : Form
{
    public Clock()
    {
        InitializeComponent();
    }

    private int hours = DateTime.Now.Hour;
    private int minutes = DateTime.Now.Minute;
    private int seconds = DateTime.Now.Second;

    private void DrawHands(PaintEventArgs e)
    {
        
    }

    private void TimerTick(object sender, EventArgs e)
    {
        
        if (seconds == 59)
        {
            minutes++;
            seconds = 0;
        }
        else
        {
            seconds++;
        }

        if (minutes == 59 && seconds == 59)
        {
            minutes = 0;
            hours++;
        }

        if (hours == 24 && minutes == 59 && seconds == 59)
        {
            hours = 0;
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftProjector.Slides
{
    public class ClockSlide : Slide
    {
        private Timer timer;
        private string currentTime = "";

        public ClockSlide()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
            if (this.Parent != null)
                this.Parent.Invalidate();
        }

        private void UpdateTime()
        {
            currentTime = DateTime.Now.ToString("hh:mm:ss tt");
        }

        public override void Draw(Graphics g, Rectangle bounds)
        {
            g.Clear(Color.Black);
            using (Font font = new Font("Arial", 150, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.White))
            {
                SizeF size = g.MeasureString(currentTime, font);
                g.DrawString(currentTime, font, brush, (bounds.Width - size.Width)/2, (bounds.Height - size.Height)/2);
            }
        }
    }
}

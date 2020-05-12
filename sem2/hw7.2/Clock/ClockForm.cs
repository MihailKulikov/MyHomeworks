using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockForm : Form
    {
        private const float FrameThicknessRelativeToSquareLength = 0.025F;

        private const float SecondHandThicknessRelativeToSquareLength = 0.00625F;
        private const float MinuteHandThicknessRelativeToSquareLength = 0.0125F;
        private const float HourHandThicknessRelativeToSquareLength = 0.025F;

        private const float SecondHandLengthRelativeToSquareLength = 0.4F;
        private const float MinuteHandLengthRelativeToSquareLength = 0.3F;
        private const float HourHandLengthRelativeToSquareLength = 0.2F;

        public ClockForm()
        {
            InitializeComponent();
        }

        private void DrawClock(Graphics graphics)
        {
            DrawFrameForClock(graphics);
            DrawHourHand(graphics);
            DrawMinuteHand(graphics);
            DrawSecondHand(graphics);
        }

        private void DrawSecondHand(Graphics graphics)
        {
            var squareLength = Math.Min(pictureBox.Height, pictureBox.Width);
            var seconds = DateTime.Now.Second;

            var penForNewSecondHand = new Pen(Color.BlueViolet, SecondHandThicknessRelativeToSquareLength * squareLength);

            (float x, float y) origin = (pictureBox.Width / 2F, pictureBox.Height / 2F);
            var secondHandLength = SecondHandLengthRelativeToSquareLength * squareLength;

            var angleForNewSecondHand = Math.PI / 2.0 * (seconds / 15.0 - 1);

            graphics.DrawLine(penForNewSecondHand, origin.x, origin.y,
                origin.x + secondHandLength *
                (float) Math.Cos(angleForNewSecondHand),
                origin.y + secondHandLength *
                (float) Math.Sin(angleForNewSecondHand));
        }

        private void DrawMinuteHand(Graphics graphics)
        {
            var squareLength = Math.Min(pictureBox.Height, pictureBox.Width);
            var minutes = DateTime.Now.Minute;

            var penForNewSecondHand = new Pen(Color.Blue, MinuteHandThicknessRelativeToSquareLength * squareLength);

            (float x, float y) origin = (pictureBox.Width / 2F, pictureBox.Height / 2F);
            var minuteHandLength = MinuteHandLengthRelativeToSquareLength * squareLength;

            var angleForNewMinuteHand = Math.PI / 2.0 * (minutes / 15.0 - 1);

            graphics.DrawLine(penForNewSecondHand, origin.x, origin.y,
                origin.x + minuteHandLength *
                (float)Math.Cos(angleForNewMinuteHand),
                origin.y + minuteHandLength *
                (float)Math.Sin(angleForNewMinuteHand));
        }

        private void DrawHourHand(Graphics graphics)
        {
            var squareLength = Math.Min(pictureBox.Height, pictureBox.Width);
            var hours = DateTime.Now.Hour;

            var penForNewSecondHand = new Pen(Color.Crimson, HourHandThicknessRelativeToSquareLength * squareLength);

            (float x, float y) origin = (pictureBox.Width / 2F, pictureBox.Height / 2F);
            var hourHandLength = HourHandLengthRelativeToSquareLength * squareLength;

            var angleForNewHourHand = Math.PI / 2.0 * (hours / 3.0 - 1);

            graphics.DrawLine(penForNewSecondHand, origin.x, origin.y,
                origin.x + hourHandLength *
                (float)Math.Cos(angleForNewHourHand),
                origin.y + hourHandLength *
                (float)Math.Sin(angleForNewHourHand));
        }

        private void DrawFrameForClock(Graphics graphics)
        {
            var squareLength = Math.Min(pictureBox.Height, pictureBox.Width);
            var widthOfFrame = squareLength * FrameThicknessRelativeToSquareLength;

            var penForOuterFrame = new Pen(Color.HotPink, widthOfFrame);
            var penForInnerFrame = new Pen(Color.Chartreuse, widthOfFrame);

            graphics.DrawEllipse(penForOuterFrame, (pictureBox.Width - squareLength) / 2F + widthOfFrame,
                (pictureBox.Height - squareLength) / 2F + widthOfFrame, squareLength - 2 * widthOfFrame, squareLength - 2 * widthOfFrame);

            graphics.DrawEllipse(penForInnerFrame, (pictureBox.Width - squareLength) / 2F + 2 * widthOfFrame,
                (pictureBox.Height - squareLength) / 2F + 2 * widthOfFrame, squareLength - 4 * widthOfFrame, squareLength - 4 * widthOfFrame);

            penForInnerFrame.Dispose();
            penForOuterFrame.Dispose();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawClock(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}

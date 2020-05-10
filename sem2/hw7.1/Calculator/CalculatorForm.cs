using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        private readonly CalculatorCore core;


        public CalculatorForm()
        {
            InitializeComponent();
            TextBox.GotFocus += TextBox_GotFocus;
            this.LostFocus += CalculatorForm_LostFocus;
            core = new CalculatorCore();
        }

        private void CalculatorForm_LostFocus(object sender, EventArgs e)
        {
            HideCaret(TextBox.Handle);
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            TextBox.SelectionStart = 0;
        }

        private void CalculatorForm_Paint(object sender, PaintEventArgs e)
        {
            HideCaret(TextBox.Handle);
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            HideCaret(TextBox.Handle);
        }

        private void ButtonNum0_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(0);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum1_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(1);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum2_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(2);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum3_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(3);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum4_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(4);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum5_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(5);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum6_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(6);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum7_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(7);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum8_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(8);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNum9_Click(object sender, EventArgs e)
        {
            core.PressButtonDigits(9);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonPoint_Click(object sender, EventArgs e)
        {
            core.PressButtonPoint();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonNegate_Click(object sender, EventArgs e)
        {
            core.PressNegateButton();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            core.PressButtonCE();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            core.PressButtonC();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            core.PressButtonBack();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonDivision_Click(object sender, EventArgs e)
        {
            core.PressBinaryOperationButton(BinaryOperations.Divide);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            core.PressBinaryOperationButton(BinaryOperations.Multiply);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonSubtraction_Click(object sender, EventArgs e)
        {
            core.PressBinaryOperationButton(BinaryOperations.Subtract);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonEquality_Click(object sender, EventArgs e)
        {
            core.PressEqualButton();
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            core.PressBinaryOperationButton(BinaryOperations.Add);
            TextBox.Text = core.TextBoxValue;
            Label.Text = core.LabelValue;
        }
    }
}

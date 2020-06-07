using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Represents calculator desktop application.
    /// </summary>
    public partial class CalculatorForm : Form
    {
        private readonly CalculatorCore core;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            core = new CalculatorCore();
        }

        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            var button = (Button) sender;
            
            core.PressButtonDigits(byte.Parse(button.Text));
            
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

using System.Reflection.PortableExecutable;
using Calculator;
using NUnit.Framework;
using FluentAssertions;

namespace CalculatorTest
{
    public class Tests
    {
        private CalculatorCore core;
        [SetUp]
        public void Setup()
        {
            core = new CalculatorCore();
        }

        private void AssertTextBoxValueAndLabelValue(string textBoxValue, string labelValue)
        {
            core.TextBoxValue.Should().Be(textBoxValue);
            core.LabelValue.Should().Be(labelValue);
        }

        [Test]
        public void Be_In_InitialState_After_Creating()
        {
            AssertTextBoxValueAndLabelValue("0","");
        }

        [Test]
        public void Do_Nothing_After_Press_Num0()
        {
            core.PressButtonWithNum0();

            AssertTextBoxValueAndLabelValue("0", "");
        }
        
        [Test]
        public void Record_Digit_After_Press_Num1_9()
        {
            core.PressButtonWithOtherDigits(5);

            AssertTextBoxValueAndLabelValue("5", "");
        }

        [Test]
        public void Do_Nothing_After_PressButtonCE()
        {
            core.PressButtonCE();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Nothing_After_PressButtonC()
        {
            core.PressButtonC();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Noting_After_PressButtonBack()
        {
            core.PressButtonBack();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void RecordBinaryOperation_After_PressBinaryOperationButton()
        {
            core.PressBinaryOperationButton(BinaryOperations.Add);

            AssertTextBoxValueAndLabelValue("0", "0 +");
        }

        [Test]
        public void RecordPoint_After_PressPointButton()
        {
            core.PressButtonPoint();

            AssertTextBoxValueAndLabelValue("0.","");
        }

        [Test]
        public void Do_Nothing_After_PressEqualButton()
        {
            core.PressEqualButton();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Noting_After_PressNegateButton()
        {
            core.PressNegateButton();

            AssertTextBoxValueAndLabelValue("0", "");
        }
    }
}
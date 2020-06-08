using Calculator;
using NUnit.Framework;
using FluentAssertions;

namespace CalculatorTest
{
    public class Tests
    {
        private CalculatorCore core;
        private const string DivideByZeroExceptionMessage = "Attempted to divide by zero.";
        private const string OverflowExceptionMessage = "Value was either too large or too small for a Decimal.";

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
        public void Do_Nothing_After_Pressing_Num0()
        {
            core.PressButtonDigits(0);

            AssertTextBoxValueAndLabelValue("0", "");
        }
        
        [Test]
        public void Record_Digit_After_Pressing_Num1_9()
        {
            core.PressButtonDigits(5);

            AssertTextBoxValueAndLabelValue("5", "");
        }

        [Test]
        public void Do_Nothing_After_PressingButtonCE()
        {
            core.PressButtonCE();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Nothing_After_PressingButtonC()
        {
            core.PressButtonC();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Noting_After_PressingButtonBack()
        {
            core.PressButtonBack();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void RecordBinaryOperation_After_PressingBinaryOperationButton()
        {
            core.PressBinaryOperationButton(BinaryOperations.Add);

            AssertTextBoxValueAndLabelValue("0", "0 +");
        }

        [Test]
        public void RecordPoint_After_PressingPointButton()
        {
            core.PressButtonPoint();

            AssertTextBoxValueAndLabelValue("0.","");
        }

        [Test]
        public void Do_Nothing_After_PressingEqualButton()
        {
            core.PressEqualButton();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void Do_Noting_After_PressingNegateButton()
        {
            core.PressNegateButton();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void RecordNum0_AfterPressNum1_9_And_PressingButtonNum0()
        {
            core.PressButtonDigits(5);

            core.PressButtonDigits(0);

            AssertTextBoxValueAndLabelValue("50", "");
        }

        [Test]
        public void RecordAllDigits_After_PressingMultipleTimes_ButtonNum1_9()
        {
            for (byte i = 1; i < 10; i++)
            {
                core.PressButtonDigits(i);
            }

            AssertTextBoxValueAndLabelValue("123456789", "");
        }

        [Test]
        public void ClearTextBox_If_TextBox_Is_Not_EqualZero_After_PressingButtonCE()
        {
            core.PressButtonDigits(2);

            core.PressButtonCE();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void ClearTextBox_If_TextBox_Is_Not_Equal_To_Zero_After_PressingButtonC()
        {
            core.PressButtonDigits(2);

            core.PressButtonC();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void RemoveLastSymbol_In_TextBox_If_TextBox_Is_Not_Equal_To_Zero_After_PressingButtonBack()
        {
            core.PressButtonDigits(5);
            core.PressButtonDigits(4);

            core.PressButtonBack();

            AssertTextBoxValueAndLabelValue("5", "");
        }

        [Test]
        public void NotAddPoint_After_Pressing_ButtonPoint_More_Than_Onñe()
        {
            core.PressButtonPoint();
            core.PressButtonDigits(5);

            core.PressButtonPoint();
            core.PressButtonPoint();

            AssertTextBoxValueAndLabelValue("0.5", "");
        }

        [Test]
        public void AddMinus_ToPositiveNumber_InTextBox_After_Pressing_NegateButton_Once()
        {
            core.PressButtonDigits(2);
            
            core.PressNegateButton();

            AssertTextBoxValueAndLabelValue("-2", "");
        }

        [Test]
        public void RemoveMinus_FromNegativeNumber_InTextBox_After_Pressing_NegateButton_Once()
        {
            core.PressButtonDigits(2);
            core.PressNegateButton();

            core.PressNegateButton();

            AssertTextBoxValueAndLabelValue("2", "");
        }

        [Test]
        public void RecordSecondOperand_After_Selecting_BinaryOperation()
        {
            core.PressButtonDigits(5);
            core.PressButtonPoint();
            core.PressButtonDigits(4);
            core.PressBinaryOperationButton(BinaryOperations.Add);

            core.PressButtonDigits(3);
            core.PressButtonPoint();
            core.PressButtonDigits(2);

            AssertTextBoxValueAndLabelValue("3.2","5.4 +");
        }

        [Test]
        public void NotClearLabel_After_Pressing_ButtonCE()
        {
            core.PressButtonDigits(2);
            core.PressButtonPoint();
            core.PressButtonDigits(3);
            core.PressBinaryOperationButton(BinaryOperations.Subtract);

            core.PressButtonDigits(3);
            core.PressButtonCE();

            AssertTextBoxValueAndLabelValue("0", "2.3 -");
        }

        [Test]
        public void ClearLabel_After_Pressing_ButtonC()
        {
            core.PressButtonDigits(5);
            core.PressButtonPoint();
            core.PressButtonDigits(4);
            core.PressBinaryOperationButton(BinaryOperations.Divide);

            core.PressButtonDigits(3);
            core.PressButtonC();

            AssertTextBoxValueAndLabelValue("0", "");
        }

        [Test]
        public void SwitchBinaryOperation_After_Pressing_Two_Different_BinaryOperation()
        {
            core.PressButtonDigits(5);
            core.PressBinaryOperationButton(BinaryOperations.Add);

            core.PressBinaryOperationButton(BinaryOperations.Multiply);

            AssertTextBoxValueAndLabelValue("5", "5 *");
        }

        [Test]
        public void ShowDivideByZeroMessage_After_Dividing_By_Zero()
        {
            core.PressButtonDigits(1);
            core.PressBinaryOperationButton(BinaryOperations.Divide);
            
            core.PressButtonDigits(0);
            core.PressEqualButton();

            AssertTextBoxValueAndLabelValue(DivideByZeroExceptionMessage, "1 /");
        }

        [Test]
        public void ShowOverflowExceptionMessage_AfterOverflow()
        {
            for (var i = 0; i < 16; i++)
            {
                core.PressButtonDigits(9);
            }
            core.PressBinaryOperationButton(BinaryOperations.Multiply);
            for (var i = 0; i < 16; i++)
            {
                core.PressButtonDigits(9);
            }
            
            core.PressEqualButton();

            AssertTextBoxValueAndLabelValue(OverflowExceptionMessage, "9999999999999999 *");
        }

        [Test]
        public void CorrectCalculate_After_Selecting_BinaryOperator_For_TheSecondTime()
        {
            core.PressButtonDigits(5);
            core.PressButtonPoint();
            core.PressButtonDigits(4);
            core.PressBinaryOperationButton(BinaryOperations.Add);
            core.PressButtonDigits(4);
            core.PressButtonPoint();
            core.PressButtonDigits(5);

            core.PressBinaryOperationButton(BinaryOperations.Subtract);

            AssertTextBoxValueAndLabelValue("9.9", "5.4 + 4.5 -");
        }
    }
}
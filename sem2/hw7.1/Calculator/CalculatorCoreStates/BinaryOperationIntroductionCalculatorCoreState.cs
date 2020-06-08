using System;

namespace Calculator.CalculatorCoreStates
{
    /// <summary>
    /// Represents state of binary operation introduction for the <see cref="CalculatorCore"/> class.
    /// </summary>
    public class BinaryOperationIntroductionCalculatorCoreState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        {
            SetState(core, new SecondOperandIntroductionCalculatorCoreState());
            AssignEnteredValueToTextBox(digit.ToString(core.Culture), core);
        }

        public override void PressButtonCE(CalculatorCore core)
        {
            SetState(core, new SecondOperandIntroductionCalculatorCoreState());
            ResetTextBox(core);
        }

        public override void PressButtonC(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetAll(core);
        }

        public override void PressButtonBack(CalculatorCore core)
        { }

        public override void PressBinaryOperationButton(BinaryOperations binaryOperation, CalculatorCore core)
        {
            ChangeBinaryOperation(binaryOperation, core);
        }

        public override void PressButtonPoint(CalculatorCore core)
        {
            SetState(core, new SecondOperandIntroductionCalculatorCoreState());
            AssignEnteredValueToTextBox("0.", core);
        }

        public override void PressEqualButton(CalculatorCore core)
        {
            SetState(core, new ResultCalculatorCoreState());
            try
            {
                Summarize(core);
            }
            catch (DivideByZeroException e)
            {
                SetState(core, new ExceptionCalculatorCoreState());
                AssignEnteredValueToTextBox(e.Message, core);
            }
            catch (OverflowException e)
            {
                SetState(core, new ExceptionCalculatorCoreState());
                AssignEnteredValueToTextBox(e.Message, core);
            }
        }

        public override void PressNegateButton(CalculatorCore core)
        {
            SetState(core, new SecondOperandIntroductionCalculatorCoreState());
            NegateTextBox(core);
        }
    }
}
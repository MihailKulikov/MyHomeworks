using System;

namespace Calculator
{
    public class SecondOperandIntroductionCalculatorCoreState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        {
            AddValueToEndOfTextBox(digit.ToString(core.Culture), core);
        }

        public override void PressButtonCE(CalculatorCore core)
        {
            ResetTextBox(core);
        }

        public override void PressButtonC(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetAll(core);
        }

        public override void PressButtonBack(CalculatorCore core)
        {
            RemoveLastDigit(core);
        }

        public override void PressBinaryOperationButton(BinaryOperations binaryOperation, CalculatorCore core)
        {
            SetState(core, new BinaryOperationIntroductionCalculatorCoreState());
            try
            {
                ApplyOtherBinaryOperations(binaryOperation, core);
            }
            catch (DivideByZeroException e)
            {
                AssignEnteredValueToTextBox(e.Message, core);
                SetState(core, new ExceptionCalculatorCoreState());
            }
            catch (OverflowException e)
            {
                AssignEnteredValueToTextBox(e.Message, core);
                SetState(core, new ExceptionCalculatorCoreState());
            }
        }

        public override void PressButtonPoint(CalculatorCore core)
        {
            TryToAddPoint(core);
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
            NegateTextBox(core);
        }
    }
}
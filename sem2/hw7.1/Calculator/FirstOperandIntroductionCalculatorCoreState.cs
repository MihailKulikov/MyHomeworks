namespace Calculator
{
    public class FirstOperandIntroductionCalculatorCoreState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        {
            AddValueToEndOfTextBox(digit.ToString(core.Culture), core);
        }

        public override void PressButtonCE(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetTextBox(core);
        }

        public override void PressButtonC(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetTextBox(core);
        }

        public override void PressButtonBack(CalculatorCore core)
        {
            RemoveLastDigit(core);
        }

        public override void PressBinaryOperationButton(BinaryOperations binaryOperation, CalculatorCore core)
        {
            SetState(core, new BinaryOperationIntroductionCalculatorCoreState());
            ApplyFirstBinaryOperation(binaryOperation, core);
        }

        public override void PressButtonPoint(CalculatorCore core)
        {
            TryToAddPoint(core);
        }

        public override void PressEqualButton(CalculatorCore core)
        {
            SetState(core, new ResultCalculatorCoreState());
        }

        public override void PressNegateButton(CalculatorCore core)
        {
            NegateTextBox(core);
        }
    }
}
namespace Calculator.CalculatorCoreStates
{
    /// <summary>
    /// Represents state after successful summarizing the expression for the <see cref="CalculatorCore"/> class.
    /// </summary>
    public class ResultCalculatorCoreState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        {
            SetState(core, new FirstOperandIntroductionCalculatorCoreState());
            AssignEnteredValueToTextBox(digit.ToString(core.Culture), core);
        }

        public override void PressButtonCE(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
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
            SetState(core, new BinaryOperationIntroductionCalculatorCoreState());
            ApplyFirstBinaryOperation(binaryOperation, core);
        }

        public override void PressButtonPoint(CalculatorCore core)
        {
            SetState(core, new FirstOperandIntroductionCalculatorCoreState());
            AssignEnteredValueToTextBox("0.", core);
        }

        public override void PressEqualButton(CalculatorCore core)
        { }

        public override void PressNegateButton(CalculatorCore core)
        {
            NegateTextBox(core);
        }
    }
}
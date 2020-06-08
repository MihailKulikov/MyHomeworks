namespace Calculator.CalculatorCoreStates
{
    /// <summary>
    /// Represents initial state for the <see cref="CalculatorCore"/> core.
    /// </summary>
    public class InitialCalculatorState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        {
            SetState(core, new FirstOperandIntroductionCalculatorCoreState());
            AssignEnteredValueToTextBox(digit.ToString(core.Culture), core);
        }

        public override void PressButtonCE(CalculatorCore core)
        { }

        public override void PressButtonC(CalculatorCore core)
        { }

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
            AddValueToEndOfTextBox("0.", core);
        }

        public override void PressEqualButton(CalculatorCore core)
        { }

        public override void PressNegateButton(CalculatorCore core)
        { }
    }
}
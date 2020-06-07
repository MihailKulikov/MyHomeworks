namespace Calculator
{
    public class ExceptionCalculatorCoreState : CalculatorCore.CalculatorCoreState
    {
        public override void PressButtonDigits(byte digit, CalculatorCore core)
        { }

        public override void PressButtonCE(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetAll(core);
        }

        public override void PressButtonC(CalculatorCore core)
        {
            SetState(core, new InitialCalculatorState());
            ResetAll(core);
        }

        public override void PressButtonBack(CalculatorCore core)
        { }

        public override void PressBinaryOperationButton(BinaryOperations operation, CalculatorCore core)
        { }

        public override void PressButtonPoint(CalculatorCore core)
        { }

        public override void PressEqualButton(CalculatorCore core)
        { }

        public override void PressNegateButton(CalculatorCore core)
        { }
    }
}
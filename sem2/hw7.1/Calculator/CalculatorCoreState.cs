namespace Calculator
{
    internal enum CalculatorCoreState
    {
        Initial,
        FirstOperandIntroduction,
        BinaryOperationIntroduction,
        Result,
        SecondOperandIntroduction,
        Exception
    }
}

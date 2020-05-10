namespace Calculator
{
    /// <summary>
    /// Provides states for <see cref="CalculatorCore"/>
    /// </summary>
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

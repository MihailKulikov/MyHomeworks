namespace Calculator
{
    internal enum CalculatorCoreState
    {
        S1, //Initial,
        S2,//FirstOperandIntroduction,
        S3,//BinaryOperationIntroduction,
        S4,//Result,
        S5,//SecondOperandIntroduction,
        S6//Exception
    }
}

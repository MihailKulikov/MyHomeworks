namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents number in expression tree. Provides methods to calculate and print number.
    /// </summary>
    public class NumberNode : INode
    {
        private readonly int _value;

        /// <summary>
        /// Initializes a new instance of the MultiplicationNode with introduced number.
        /// </summary>
        /// <param name="value">Introduced number.</param>
        public NumberNode(int value)
        {
            _value = value;
        }

        public int Calculate()
        {
            return _value;
        }

        public string Print()
        {
            return _value.ToString();
        }
    }
}
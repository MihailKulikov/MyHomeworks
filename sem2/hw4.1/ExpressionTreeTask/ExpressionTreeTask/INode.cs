namespace ExpressionTreeTask
{
    public interface INode
    {
        /// <summary>
        /// Prints expression subtree in prefix notation.
        /// </summary>
        /// <returns>Expression in prefix notation.</returns>
        public int Calculate();
        
        /// <summary>
        /// Calculates value of expression subtree.
        /// </summary>
        /// <returns>Calculated value.</returns>
        public string Print();
    }
}
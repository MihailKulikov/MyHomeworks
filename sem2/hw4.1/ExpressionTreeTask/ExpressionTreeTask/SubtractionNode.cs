namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents subtraction operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class SubtractionNode : OperationNode
    {
        /// <summary>
        /// Initializes a new instance of the SubtractionNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the SubtractionNode</param>
        /// <param name="rightNode">Right child of the SubtractionNode</param>
        public SubtractionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        { }

        protected sealed override char OperationSymbol => '-';

        public sealed override int Calculate() => LeftNode.Calculate() - RightNode.Calculate();
    }
}
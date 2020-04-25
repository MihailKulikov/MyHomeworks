namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents addition operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class AdditionNode : OperationNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the <see cref="AdditionNode"/></param>
        /// <param name="rightNode">Right child of the <see cref="AdditionNode"/></param>
        public AdditionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        { }

        protected sealed override char OperationSymbol => '+';

        public sealed override int Calculate() => LeftNode.Calculate() + RightNode.Calculate();
    }
}
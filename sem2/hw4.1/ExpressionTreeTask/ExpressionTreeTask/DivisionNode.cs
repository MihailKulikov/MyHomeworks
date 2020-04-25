namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents division operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class DivisionNode : OperationNode
    {
        /// <summary>
        /// Initializes a new instance of the DivisionNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the DivisionNode</param>
        /// <param name="rightNode">Right child of the DivisionNode</param>
        public DivisionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        { }

        protected sealed override char OperationSymbol => '/';

        public sealed override int Calculate() => LeftNode.Calculate() / RightNode.Calculate();
    }
}
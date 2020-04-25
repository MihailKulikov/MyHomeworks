namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents multiplication operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class MultiplicationNode : OperationNode
    {
        /// <summary>
        /// Initializes a new instance of the MultiplicationNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the MultiplicationNode</param>
        /// <param name="rightNode">Right child of the MultiplicationNode</param>
        public MultiplicationNode(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        { }

        protected sealed override char OperationSymbol => '*';

        public sealed override int Calculate() => LeftNode.Calculate() * RightNode.Calculate();
    }
}
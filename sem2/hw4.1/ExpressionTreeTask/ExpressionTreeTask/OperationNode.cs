namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents operation node in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public abstract class OperationNode : INode
    {
        protected readonly INode LeftNode;
        protected readonly INode RightNode;
        
        protected abstract char OperationSymbol { get; }
        
        /// <summary>
        /// Initializes a new instance of the OperationNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        protected OperationNode(INode leftNode, INode rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public abstract int Calculate();

        public string Print() => $"({OperationSymbol} {LeftNode.Print()} {RightNode.Print()})";
    }
}
namespace StackCalculator
{
    interface IStack
    {
        double Pop();
        void Push(double value);
        public int Count { get; }
    }
}

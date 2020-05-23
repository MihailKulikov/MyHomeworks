namespace ConsoleGame
{
    internal static class Program
    {
        private static void Main()
        {
            
            var game = GameInitializer.LoadGameWithSpecifiedMapWriterFromFile("ConsoleGame.Maps.GoodMap.txt", new ConsoleMapWriter());
            var eventLoop = new EventLoop();
            eventLoop.DownHandler += game.OnDown;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.LeftHandler += game.OnLeft;
            
            eventLoop.Run();
        }
    }
}
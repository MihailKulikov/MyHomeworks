namespace ConsoleGame
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mapInitializer = new MapInitializer();
            var map = mapInitializer.LoadMapFromFile(@"C:\Users\kulik\Desktop\spbu\sem2\hw6.2\Map.txt");
            var eventLoop = new EventLoop();
            var game = new Game(map);
            var mapWriter = new MapConsoleWriter('#', ' ', '@');
            mapWriter.WriteMap(map);
            game.CharacterMove += mapWriter.MoveCharacter;
            eventLoop.DownHandler += game.OnDown;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.LeftHandler += game.OnLeft;
            
            eventLoop.Run();
        }
    }
}
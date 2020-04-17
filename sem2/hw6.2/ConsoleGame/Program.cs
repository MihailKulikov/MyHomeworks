namespace ConsoleGame
{
    internal static class Program
    {
        private static void Main()
        {
            const char wallSymbol = '#';
            const char freeSpaceSymbol = ' ';
            const char characterSymbol = '@';

            var mapInitializer = new MapInitializer(freeSpaceSymbol, characterSymbol, wallSymbol);
            var map = mapInitializer.LoadMapFromFile("ConsoleGame.Maps.Map.txt");
            
            var mapWriter = new MapConsoleWriter(wallSymbol, freeSpaceSymbol, characterSymbol);
            mapWriter.WriteMap(map);

            var eventLoop = new EventLoop();
            var game = new Game(map);
            game.CharacterMoveHandler += mapWriter.MoveCharacter;
            eventLoop.DownHandler += game.OnDown;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.LeftHandler += game.OnLeft;
            
            eventLoop.Run();
        }
    }
}
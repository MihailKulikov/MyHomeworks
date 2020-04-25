using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Game
    {
        private readonly List<Cell>[] _map;
        private readonly IMapWriter _mapWriter;
        private (int x, int y) _characterPosition;
        
        public Game(List<Cell>[] map, (int x, int y) characterPosition, IMapWriter mapWriter)
        {
            _map = map;
            _mapWriter = mapWriter;
            _characterPosition = characterPosition;
            
            _mapWriter.WriteMap(_map);
            _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character);
        }

        public void OnLeft(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y - 1);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        public void OnRight(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y + 1);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        public void OnUp(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x - 1, _characterPosition.y);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        public void OnDown(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x + 1, _characterPosition.y);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        private void TryChangeCharacterPosition((int x, int y) newCharacterPosition)
        {
            if (!IsTheCellSuitable(newCharacterPosition)) return;
            
            _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace);
            _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character);
            _characterPosition = newCharacterPosition;
        }
        
        private bool IsTheCellSuitable((int x, int y) pos)
        {
            if (pos.x < 0 || pos.x > _map.Length - 1) return false;
            if (pos.y < 0 || pos.y > _map[pos.x].Count - 1) return false;
            return _map[pos.x][pos.y] == Cell.FreeSpace;
        }
    }
}
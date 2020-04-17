using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class Game
    {
        private readonly List<Cell>[] _map;
        public event EventHandler<MoveCharacterEventArgs> CharacterMove;
        private (int x, int y) _characterPosition;
        
        public Game(List<Cell>[] map)
        {
            _map = map;

            _characterPosition = FindCharacterPosition();
        }

        private (int, int) FindCharacterPosition()
        {
            for (var x = 0; x < _map.Length; x++)
            {
                for (var y = 0; y < _map[x].Count; y++)
                {
                    if (_map[x][y] == Cell.Character)
                        return (x, y);
                }
            }
            
            throw new InvalidMapException("There is no character.");
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
            var e = new MoveCharacterEventArgs(_characterPosition, newCharacterPosition);
            OnMoveCharacter(e);
            _map[_characterPosition.x][_characterPosition.y] = Cell.FreeSpace;
            _map[newCharacterPosition.x][newCharacterPosition.y] = Cell.Character;
            _characterPosition = newCharacterPosition;
        }
        
        private bool IsTheCellSuitable((int x, int y) pos)
        {
            if (pos.x < 0 || pos.x > _map.Length) return false;
            if (pos.y < 0 || pos.y > _map[pos.x].Count) return false;
            return _map[pos.x][pos.y] == Cell.FreeSpace;
        }

        protected virtual void OnMoveCharacter(MoveCharacterEventArgs e)
        {
            CharacterMove?.Invoke(this, e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw6Game
{
    /// <summary>
    /// class that handles events
    /// </summary>
    public class Game
    {
        /// <summary>
        /// enums for moves
        /// </summary>
        public enum Moves
        {
            left,
            right,
            up,
            down
        }

        private Map map;

        private (int, int) coordinates;

        public Game(string filePath)
        {
            map = new Map(filePath);
            coordinates = map.GetPlayerCoordinates();
        }

        public void OnLeft(object sender, EventArgs args)
        {
            Move(Moves.left);
        }

        public void OnRight(object sender, EventArgs args)
        {
            Move(Moves.right);
        }

        public void OnDown(object sender, EventArgs args)
        {
            Move(Moves.down);
        }

        public void OnUp(object sender, EventArgs args)
        {
            Move(Moves.up);
        }

        private (int, int) GetNewCoordinates((int, int) coordinates, Moves move) =>
            move switch
            {
                Moves.left => (coordinates.Item1 + 1, coordinates.Item2),
                Moves.right => (coordinates.Item1 - 1, coordinates.Item2),
                Moves.down => (coordinates.Item1, coordinates.Item2 - 1),
                Moves.up => (coordinates.Item1, coordinates.Item2 + 1),
                _ => (coordinates.Item1, coordinates.Item2)
            };

        private void Move(Moves move)
        {
            if (map.Move(move))
            {
                var oldCoordinates = map.GetPlayerCoordinates();
                coordinates = GetNewCoordinates(map.GetPlayerCoordinates(), move);
                Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
                Console.Write(' ');
                Console.SetCursorPosition(oldCoordinates.Item1, oldCoordinates.Item2);
                Console.Write('@');
            }
        }
    }
}
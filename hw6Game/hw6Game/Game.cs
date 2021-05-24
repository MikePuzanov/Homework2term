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
        private Map map;

        private (int, int) coordinates;

        public Game(string filePath)
        {
            map = new Map(filePath);
            coordinates = map.GetPlayerCoordinates();
        }

        public void OnLeft(object sender, EventArgs args)
        {
            Move("left");
        }

        public void OnRight(object sender, EventArgs args)
        {
            Move("right");
        }

        public void OnDown(object sender, EventArgs args)
        {
            Move("down");
        }

        public void OnUp(object sender, EventArgs args)
        {
            Move("up");
        }

        private (int, int) GetNewCoordinates((int, int) coordinates, string step) =>
            step switch
            {
                "left" => (coordinates.Item1 + 1, coordinates.Item2),
                "right" => (coordinates.Item1 - 1, coordinates.Item2),
                "down" => (coordinates.Item1, coordinates.Item2 - 1),
                "up" => (coordinates.Item1, coordinates.Item2 + 1),
                _ => (coordinates.Item1, coordinates.Item2)
            };

        private void Move(string step)
        {
            if (map.Move(step))
            {
                var oldCoordinates = map.GetPlayerCoordinates();
                coordinates = GetNewCoordinates(map.GetPlayerCoordinates(), step);
                Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
                Console.Write(' ');
                Console.SetCursorPosition(oldCoordinates.Item1, oldCoordinates.Item2);
                Console.Write('@');
            }
        }
    }
}
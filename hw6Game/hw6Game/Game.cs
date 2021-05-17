using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw6Game
{
    /// <summary>
    /// 
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

        private void Move(string step)
        {
            if (map.Move(step))
            {
                coordinates = map.GetPlayerCoordinates();
                switch (step)
                {
                    case "left":
                        Console.SetCursorPosition(coordinates.Item1 + 1, coordinates.Item2);
                        break;
                    case "right":
                        Console.SetCursorPosition(coordinates.Item1 - 1, coordinates.Item2);
                        break;
                    case "down":
                        Console.SetCursorPosition(coordinates.Item1, coordinates.Item2 - 1);
                        break;
                    case "up":
                        Console.SetCursorPosition(coordinates.Item1, coordinates.Item2 + 1);
                        break;
                }
                Console.Write(' ');
                Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
                Console.Write('@');
            }
        }
    }
}

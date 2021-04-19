using System;
using System.IO;

namespace hw6Game
{
    public class Map
    {
        private struct PlayerCoordination
        {
            public int x;
            public int y;
        }

        static private string[] mapPic;

        static private PlayerCoordination player = new PlayerCoordination(); 

        /// <summary>
        /// create a map
        /// </summary>
        public Map(string filePath)
        {
            var map = File.ReadAllLines(filePath);
            for (int i = 0; i < map.Length; ++i)
            {
                var index = map[i].IndexOf("@");
                if (index != -1)
                {
                    player.x = index;
                    player.y = i;
                }
                Console.WriteLine(map[i]);
            }
            map[player.y].Replace('@', ' ');
            mapPic = map;
        }

        /// <summary>
        /// Move player
        /// </summary>
        /// <param name="step">step direction</param>
        /// <returns>true if step is complete</returns>
        public bool Move(string step)
        {
            switch (step)
            {
                case "left":
                    if (mapPic[player.y][player.x - 1] != ' ' && mapPic[player.y][player.x - 1] != '@')
                    {
                        return false;
                    }
                    player.x -= 1;
                    return true;
                case "right":
                    if (mapPic[player.y][player.x + 1] != ' ' && mapPic[player.y][player.x + 1] != '@')
                    {
                        return false;
                    }
                    player.x += 1;
                    return true;
                case "down":
                    if (mapPic[player.y + 1][player.x] != ' ' && mapPic[player.y + 1][player.x] != '@')
                    {
                        return false;
                    }
                    player.y += 1;
                    return true;
                case "up":
                    if (mapPic[player.y - 1][player.x] != ' ' && mapPic[player.y - 1][player.x] != '@')
                    {
                        return false;
                    }
                    player.y -= 1;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// return player coordinates
        /// </summary>
        /// <returns>coordinates (x, y)</returns>
        public (int, int) GetPlayerCoordinates()
            => (player.x, player.y);
    }
}
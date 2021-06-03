using System;
using System.IO;

namespace Hw6Game
{
    /// <summary>
    /// class working on building the map
    /// </summary>
    public class Map
    {
        private struct PlayerCoordinates
        {
            public int x;
            public int y;
        }

        private string[] mapPic;

        static private PlayerCoordinates player = new ();

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

        private bool CheckMove((int x, int y) coord)
        {
            if (mapPic[coord.y][coord.x ] != ' ' && mapPic[coord.y][coord.x] != '@')
            {
                return false;
            }
            player.x = coord.x;
            player.y =coord.y;
            return true;
        }

        /// <summary>
        /// Move player
        /// </summary>
        /// <param name="step">step direction</param>
        /// <returns>true if step is complete</returns>
        public bool Move(Game.Moves move)
        {
            switch (move)
            {
                case Game.Moves.left:
                    return CheckMove((player.x - 1, player.y));
                case Game.Moves.right:
                    return CheckMove((player.x + 1, player.y));
                case Game.Moves.down:
                    return CheckMove((player.x, player.y + 1));
                case Game.Moves.up:
                    return CheckMove((player.x, player.y - 1));
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
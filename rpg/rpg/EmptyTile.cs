using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenFox;

namespace rpg
{
    public class EmptyTile: Tile
    {
        static public void DrawTiles(FoxDraw foxDraw, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    foxDraw.AddImage("./assets/floor.gif", i * 50, j * 50);
                }
            }
        }
    }
}

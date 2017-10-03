using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenFox;

namespace rpg
{
    public class NotEmptyTile
    {
        static public void DrawWalls(FoxDraw foxDraw, int x, int y, List<bool> list)
        {
            int k = list.Count;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (list[list.Count - k])
                    {
                        foxDraw.AddImage("./assets/wall.gif", i * 50, j * 50);
                    }
                    k--;
                }
            }
        }
    }
}

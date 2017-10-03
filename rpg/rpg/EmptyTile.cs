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
        static public List<bool> field = new List<bool>();
        static public int count = 40;

        static public void SetField(int xmax, int ymax)
        {
            for (int i = 0; i < xmax * ymax; i++)
                field.Add(false);
        }

        static public List<bool> GenerateRoute(FoxDraw foxDraw, int startx, int starty, int xmax, int ymax)
        {
            field[starty * xmax + startx] = true;
            foxDraw.AddImage("./assets/floor.gif", startx * 50, starty * 50);
            if (count == 0)
            {
                return field;
            }
            else
            {
                Random random = new Random();
                if (startx > 0 && !(field[starty * xmax + startx - 1]))
                {
                    int step = random.Next(0, 2);
                    if (step == 0)
                    {
                        count--;
                        return GenerateRoute(foxDraw, startx - 1, starty, xmax, ymax);
                    }
                }
                if (starty > 0 && !(field[(starty - 1) * xmax + startx]))
                {
                    int step = random.Next(0, 2);
                    if (step == 0)
                    {
                        count--;
                        return GenerateRoute(foxDraw, startx, starty - 1, xmax, ymax);
                    }
                }
                if (startx < xmax - 1 && !(field[starty * xmax + startx + 1]))
                {
                    int step = random.Next(0, 2);
                    if (step == 0)
                    {
                        count--;
                        return GenerateRoute(foxDraw, startx + 1, starty, xmax, ymax);
                    }
                }
                if (starty < ymax - 1 && !(field[(starty + 1) * xmax + startx]))
                {
                    int step = random.Next(0, 2);
                    if (step == 0)
                    {
                        count--;
                        return GenerateRoute(foxDraw, startx, starty + 1, xmax, ymax);
                    }
                }
                int index = random.Next(0, field.Count);
                while (!field[index])
                {
                    index = random.Next(0, field.Count);
                }
                count--;
                return GenerateRoute(foxDraw, index / xmax, index % xmax, xmax, ymax);
            }
        }
    }
}

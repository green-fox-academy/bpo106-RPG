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
        static public int count = 80;

        static public void SetField(int xmax, int ymax)
        {
            for (int i = 0; i < xmax * ymax; i++)
                field.Add(false);
        }

        static public List<bool> GenerateRoute(FoxDraw foxDraw, int xmax)
        {
            for (int i = 0; i < field.Count; i++)
            {
                field[i] = true;
            }

            List<int> list = new List<int>()
            { 3, 5, 13, 15, 17, 18, 21, 22, 23, 25, 27,
                28, 35, 40, 41, 42, 43, 45, 46, 47, 48,
                51, 53, 58, 61, 63, 65, 66, 68, 75, 76,
                78, 81, 82, 83, 88, 93, 95, 96, 98, 101,
                103, 105 };

            for (int i = 0; i < list.Count; i++)
            {
                field[list[i]] = false;
            }

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i])
                {
                    foxDraw.AddImage("./assets/floor.gif", i % xmax * 50, i / xmax * 50);
                }
            }

            return field;
        }

        static public List<bool> GenerateRandomRoute(FoxDraw foxDraw, int start, int xmax)
        {
            int x = start % xmax;
            int y = start / xmax;
            foxDraw.AddImage("./assets/floor.gif", x * 50, y * 50);
            count--;

            if (count == 0)
            {
                field[start] = true;
                return field;
            }
            else
            {
                while(!field[start])
                {
                    Random random = new Random();
                    int index = random.Next(0, 4);
                    if (index == 0)
                    {
                        if (x > 0 && !(field[start - 1]))
                        {
                            field[start] = true;
                            int step = random.Next(0, 2);
                            if (step == 1)
                            {
                                return GenerateRandomRoute(foxDraw, start - 1, xmax);
                            }
                        }
                    }
                    if (index == 1)
                    {
                        if (y > 0 && !(field[start - xmax]))
                        {
                            field[start] = true;
                            int step = random.Next(0, 2);
                            if (step == 1)
                            {
                                return GenerateRandomRoute(foxDraw, start - xmax, xmax);
                            }
                        }
                    }
                    if (index == 2)
                    {
                        if (x < xmax - 1 && !(field[start + 1]))
                        {
                            field[start] = true;
                            int step = random.Next(0, 2);
                            if (step == 1)
                            {
                                return GenerateRandomRoute(foxDraw, start + 1, xmax);
                            }
                        }
                    }
                    if (index == 3)
                    {
                        if (y < (field.Count / xmax) - 1 && !(field[start + xmax]))
                        {
                            field[start] = true;
                            int step = random.Next(0, 2);
                            if (step == 1)
                            {
                                return GenerateRandomRoute(foxDraw, start + xmax, xmax);
                            }
                        }
                    }
                }
                return field;
            }
        }
    }
}

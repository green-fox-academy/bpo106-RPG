using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GreenFox;
using System.Windows.Controls;

namespace rpg
{
    public class Hero : Character
    {
        public Hero()
        {
            d6 = random.Next(1, 7);
            hp = 3 * d6 + 20;
            dp = 2 * d6;
            sp = d6 + 5;
        }

        public static void SetHeroStart(FoxDraw foxDraw, List<bool> list, int xmax)
        {
            isOnRoute = false;
            Hero.foxDraw = foxDraw;
            while (!isOnRoute)
            {
                element = random.Next(0, list.Count);
                isOnRoute = list[element];
                x = element % xmax;
                y = element / xmax;
            }
        }

        public static void DrawHero(string filename)
        {
            foxDraw.AddImage(filename, x * 50, y * 50);
        }

        public static void Move(string filename, int plusx, int plusy)
        {
            foxDraw.AddImage("./assets/floor.gif", x * 50, y * 50);
            x += plusx;
            y += plusy;
            DrawHero(filename);
        }
    }
}

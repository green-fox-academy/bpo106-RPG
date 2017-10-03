using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GreenFox;

namespace rpg
{
    public class Hero : Character
    {
        FoxDraw foxDraw;
        public Hero(List<bool> field, int xmax, FoxDraw foxDraw) : base()
        {
            this.foxDraw = foxDraw;
            start = random.Next(0, field.Count);
            while (!field[start])
            {
                start = random.Next(0, field.Count);
            }
            x = start % xmax;
            y = start / xmax;
            foxDraw.AddImage("./assets/hero-down.gif", x * 50, y * 50);
        }

        public void MoveHeroLeft()
        {
            foxDraw.AddImage("./assets/floor.gif", x * 50, y * 50);
            foxDraw.AddImage("./assets/hero-left.gif", (x - 1) * 50, y * 50);
        }
    }
}

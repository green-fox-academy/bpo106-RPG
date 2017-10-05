using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenFox;

namespace rpg
{
    public class Monster : Character
    {
        public void SetBossPoints()
        {
            d6 = random.Next(1, 7);
            hp = 2 * (lvl + 1) * d6;
            dp = (lvl / 2) * d6 + d6 / 2;
            sp = lvl * (d6 + 1);
        }

        public void SetMonsterPoints()
        {
            d6 = random.Next(1, 7);
            hp = 2 * lvl * d6;
            dp = lvl / 2 * d6;
            sp = lvl * d6;
        }

        public void SetMonsterStart(FoxDraw foxDraw, List<bool> list, int xmax)
        {
            Monster.foxDraw = foxDraw;
            isOnRoute = false;
            while (!isOnRoute)
            {
                element = random.Next(0, list.Count);
                isOnRoute = list[element];
                x = element % xmax;
                y = element / xmax;
            }
        }

        public void DrawMonster(string filename)
        {
            foxDraw.AddImage(filename, x * 50, y * 50);
        }
    }
}

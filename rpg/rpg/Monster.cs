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
        public static void SetMonsterStart(FoxDraw foxDraw, List<bool> list, int xmax)
        {
            Monster.foxDraw = foxDraw;
            while (!isOnRoute)
            {
                int element = random.Next(0, list.Count);
                isOnRoute = list[element];
                x = element % xmax;
                y = element / xmax;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Fight : GameLogic
    {
        static Random random = new Random();

        public static void Strike (Character attacker, Character defenser)

        {
            int d6 = random.Next(1, 7);
            int sv = attacker.sp + 2 * d6;
            if (sv > defenser.dp)
            {
                defenser.hp -= (sv - defenser.dp);
            }
        }
    }
}

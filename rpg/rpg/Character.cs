using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenFox;

namespace rpg
{
    public class Character : GameObject
    {
        protected static Random random = new Random();
        protected static bool isOnRoute = false;
        protected static FoxDraw foxDraw;
        //protected int hp;
        //protected int dp;
        //protected int sp;
        //protected int d6;
        public static int x;
        public static int y;
    }
}

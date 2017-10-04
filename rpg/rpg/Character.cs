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
        protected static bool isOnRoute;
        protected static FoxDraw foxDraw;
        public static int element;
        protected static int hp;
        protected static int dp;
        protected static int sp;
        protected static int d6;
        public static int x;
        public static int y;
    }
}

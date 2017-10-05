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
        public static int lvl;
        public static int hp;
        public static int dp;
        public static int sp;
        protected static int d6;
        public int x;
        public int y;
    }
}

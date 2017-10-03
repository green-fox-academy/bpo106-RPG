using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Character : GameObject
    {
        protected Random random = new Random();
        protected int hp;
        protected int dp;
        protected int sp;
        protected int d6;
        protected int start;
        public int x;
        public int y;
    }
}

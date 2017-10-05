using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace rpg
{
    public class Stats : GameLogic
    {
        static Canvas canvas = new Canvas();

        static int hpc;
        static int hpmax;
        static int lvl;
        static int dp;
        static int sp;

        public void StatText(double x, double y, Color color, Character character)
        {
            hpc = Character.hp;
            hpmax = Character.hp;
            lvl = Character.lvl;
            dp = Character.dp;
            sp = Character.sp;

            string text = "LEVEL: " + lvl.ToString() + "\nHP: " + hpc.ToString() + "MAXIMUM HP: " + hpmax.ToString() + "\nDP: " + dp.ToString() + "\nSP: " + sp.ToString();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }
    }
}

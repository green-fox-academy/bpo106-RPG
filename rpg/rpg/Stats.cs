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
        static int hpc;
        static int hpmax;
        static int lvl;
        static int dp;
        static int sp;

        public void StatText(double x, double y, Color color, Character character, string charName, Canvas canvas)
        {
            hpc = character.hp;
            hpmax = character.hp;
            lvl = character.lvl;
            dp = character.dp;
            sp = character.sp;

            string text = charName + "\nLEVEL: " + lvl.ToString() + "\nHP: " + hpc.ToString() + "\nMAX. HP: " + hpmax.ToString() + "\nDP: " + dp.ToString() + "\nSP: " + sp.ToString();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            textBlock.Background = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }
    }
}

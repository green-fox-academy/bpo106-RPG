using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GreenFox;

namespace rpg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<bool> field;
        List<int> opponentList = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            var foxDraw = new FoxDraw(canvas);

            NotEmptyTile.DrawWalls(foxDraw, 10, 11);
            EmptyTile.SetField(10, 11);
            field = EmptyTile.GenerateRoute(foxDraw, 10);

            Monster.SetPoints();
            Monster.SetMonsterStart(foxDraw, field, 10);
            opponentList.Add(Monster.element);
            Monster.DrawMonster("./assets/boss.gif");

            string infoBoss = Monster.BossDataToString();
            Text(510, 100, infoBoss, Colors.Black);

            for (int i = 0; i < 3; i++)
            {
                Monster.SetPoints();
                Monster.SetMonsterStart(foxDraw, field, 10);
                opponentList.Add(Monster.element);
                Monster.DrawMonster("./assets/skeleton.gif");

                string infoMonster = Monster.DataToString();
                Text(510, (i + 2) * 100, infoMonster, Colors.Black);
            }

            Hero.SetPoints();
            Hero.SetHeroStart(foxDraw, field, 10);
            Hero.DrawHero("./assets/hero-down.gif");

            string infoHero = Hero.DataToString();
            Text(510, 0, infoHero, Colors.Black);
        }

        private void Text(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Console.WriteLine("Enter");
            }
            if (e.Key == Key.Left)
            {
                Hero.DrawHero("./assets/floor.gif");
                Hero.DrawHero("./assets/hero-left.gif");
                if (Hero.x > 0 && field[Hero.y * 10 + Hero.x - 1])
                {
                    Hero.Move("./assets/hero-left.gif", -1, 0);
                }
            }
            if (e.Key == Key.Right)
            {
                Hero.DrawHero("./assets/floor.gif");
                Hero.DrawHero("./assets/hero-right.gif");
                if (Hero.x < 9 && field[Hero.y * 10 + Hero.x + 1])
                {
                    Hero.Move("./assets/hero-right.gif", 1, 0);
                }
            }
            if (e.Key == Key.Up)
            {
                Hero.DrawHero("./assets/floor.gif");
                Hero.DrawHero("./assets/hero-up.gif");
                if (Hero.y > 0 && field[(Hero.y - 1) * 10 + Hero.x])
                {
                    Hero.Move("./assets/hero-up.gif", 0, -1);
                }
            }
            if (e.Key == Key.Down)
            {
                Hero.DrawHero("./assets/floor.gif");
                Hero.DrawHero("./assets/hero-down.gif");
                if (Hero.y < 10 && field[(Hero.y + 1) * 10 + Hero.x])
                {
                    Hero.Move("./assets/hero-down.gif", 0, 1);
                }
            }
        }
    }
}

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
        List<Monster> opponentList = new List<Monster>();
        Hero hero = new Hero();
        Monster boss = new Monster();
        List<Monster> skeletons = new List<Monster>();
        Stats stats = new Stats();

        public MainWindow()
        {
            InitializeComponent();
            var foxDraw = new FoxDraw(canvas);

            NotEmptyTile.DrawWalls(foxDraw, 10, 11);
            EmptyTile.SetField(10, 11);
            field = EmptyTile.GenerateRoute(foxDraw, 10);

            boss.SetBossPoints();
            boss.SetMonsterStart(foxDraw, field, 10);
            opponentList.Add(boss);
            boss.DrawMonster("./assets/boss.gif");
            stats.StatText(510, 100, Colors.Black, boss, "BOSS", canvas);

            for (int i = 0; i < 3; i++)
            {
                skeletons.Add(new Monster());
                skeletons[i].SetMonsterPoints();
                skeletons[i].SetMonsterStart(foxDraw, field, 10);
                opponentList.Add(skeletons[i]);
                skeletons[i].DrawMonster("./assets/skeleton.gif");
                stats.StatText(510, 100 * i + 200, Colors.Black, skeletons[i], "MONSTER " + (i + 1).ToString(), canvas);
            }

            hero.SetPoints();
            hero.SetHeroStart(foxDraw, field, 10);
            hero.DrawHero("./assets/hero-down.gif");
            stats.StatText(510, 0, Colors.Black, hero, "HERO", canvas);
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
            for (int i = 0; i < opponentList.Count; i++)
            {
                if (hero.x == opponentList[i].x && hero.y == opponentList[i].y)
                {
                    while (hero.hp > 0 && opponentList[i].hp > 0)
                    {
                        if (Keyboard.IsKeyDown(Key.Space))
                        {
                            Fight.Strike(hero, opponentList[i]);
                            if (opponentList[i].hp > 0)
                            {
                                Fight.Strike(opponentList[i], hero);
                            }
                        }
                    }
                    opponentList[i].x = -1;
                    opponentList[i].y = -1;
                    if (hero.hp <= 0)
                    {
                        return;
                    }
                    else
                    {
                        hero.lvl++;
                        hero.SetPoints();
                    }
                }
            }

            if (e.Key == Key.Left)
            {
                hero.DrawHero("./assets/floor.gif");
                hero.DrawHero("./assets/hero-left.gif");
                if (hero.x > 0 && field[hero.y * 10 + hero.x - 1])
                {
                    hero.Move("./assets/hero-left.gif", -1, 0);
                }
            }
            if (e.Key == Key.Right)
            {
                hero.DrawHero("./assets/floor.gif");
                hero.DrawHero("./assets/hero-right.gif");
                if (hero.x < 9 && field[hero.y * 10 + hero.x + 1])
                {
                    hero.Move("./assets/hero-right.gif", 1, 0);
                }
            }
            if (e.Key == Key.Up)
            {
                hero.DrawHero("./assets/floor.gif");
                hero.DrawHero("./assets/hero-up.gif");
                if (hero.y > 0 && field[(hero.y - 1) * 10 + hero.x])
                {
                    hero.Move("./assets/hero-up.gif", 0, -1);
                }
            }
            if (e.Key == Key.Down)
            {
                hero.DrawHero("./assets/floor.gif");
                hero.DrawHero("./assets/hero-down.gif");
                if (hero.y < 10 && field[(hero.y + 1) * 10 + hero.x])
                {
                    hero.Move("./assets/hero-down.gif", 0, 1);
                }
            }
        }
    }
}

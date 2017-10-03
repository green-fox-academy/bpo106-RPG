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
        Hero hero;
        public MainWindow()
        {
            InitializeComponent();
            var foxDraw = new FoxDraw(canvas);

            NotEmptyTile.DrawWalls(foxDraw, 10, 11);
            EmptyTile.SetField(10, 11);
            List<bool> field = EmptyTile.GenerateRoute(foxDraw, 0, 0, 10, 11);

            hero = new Hero(field, 10, foxDraw);
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                hero.MoveHeroLeft();
            }

            if (e.Key == Key.Right)
            {
                //Hero.HeroMove(hero.x, hero.y);
            }

            if (e.Key == Key.Up)
            {
                //Hero.HeroMove(hero.x, hero.y);
            }

            if (e.Key == Key.Down)
            {
                //Hero.HeroMove(hero.x, hero.y);
            }
        }
    }
}

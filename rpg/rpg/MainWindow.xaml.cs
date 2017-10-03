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
        public MainWindow()
        {
            InitializeComponent();
            var foxDraw = new FoxDraw(canvas);
            var list = new List<bool>();
            for (int i = 0; i < 25; i++)
            {
                list.Add(false);
            }
            list[1] = true;
            list[6] = true;
            list[8] = true;
            list[9] = true;
            list[15] = true;
            list[16] = true;
            list[18] = true;
            list[23] = true;

            EmptyTile.DrawTiles(foxDraw, 5, 5);
            NotEmptyTile.DrawWalls(foxDraw, 5, 5, list);
        }
    }
}

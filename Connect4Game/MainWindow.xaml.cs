using Connect4Lib;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;

namespace Connect4Game
{
    public partial class MainWindow
    {
        private Ellipse[,] ellipses = new Ellipse[8, 7];
        private Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();

            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 8; column++)
                {
                    var newCircle = new Ellipse
                    {
                        Stroke = Brushes.Black,
                        Width = 40,
                        Height = 40
                    };
                    Grid.SetRow(newCircle, row + 1);
                    Grid.SetColumn(newCircle, column);
                    ellipses[column, row] = newCircle;
                    GameGrid.Children.Add(newCircle);
                }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var b = (Button)sender;
            int i = int.Parse((string)b.Tag);
            if (game.Play(i))
            {
                Redraw();
            }
        }

        private void Redraw()
        {
            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 8; column++)
                {
                    if (game.Red.Pos(column, row))
                    {
                        ellipses[column, row].Fill = Brushes.Red;
                    }
                    else if (game.Green.Pos(column, row))
                    {
                        ellipses[column, row].Fill = Brushes.Green;
                    }
                }
        }
    }
}

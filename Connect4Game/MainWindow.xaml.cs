using Connect4Lib;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;

namespace Connect4Game
{
    public partial class MainWindow
    {
        private Ellipse[,] ellipses = new Ellipse[8, 8];
        private Game game = new Game();

        ulong red;
        ulong green;

        public MainWindow()
        {
            InitializeComponent();

            for (int row = 0; row < 8; row++)
                for (int column = 0; column < 8; column++)
                {
                    var newCircle = new Ellipse
                    {
                        Stroke = Brushes.Black,
                        Fill = Brushes.LightGray,
                        Width = 40,
                        Height = 40
                    };
                    Grid.SetRow(newCircle, row);
                    Grid.SetColumn(newCircle, column);
                    ellipses[column, row] = newCircle;
                    GameGrid.Children.Add(newCircle);
                    newCircle.MouseLeftButtonUp += NewCircle_MouseLeftButtonUp;
                    newCircle.MouseRightButtonUp += NewCircle_MouseRightButtonUp;
                }
        }

        private void NewCircle_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            if (ellipse.Fill == Brushes.Green)
            {
                ellipse.Fill = Brushes.DarkOrange;
            }
            else if (ellipse.Fill == Brushes.Red)
            {
                ellipse.Fill = Brushes.LightGray;
            }
            else
            {
                ellipse.Fill = Brushes.Red;
            }
            RecalcDisplay();
        }

        private void NewCircle_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            if (ellipse.Fill == Brushes.Red)
            {
                ellipse.Fill = Brushes.DarkOrange;
            }
            else if (ellipse.Fill == Brushes.Green)
            {
                ellipse.Fill = Brushes.LightGray;
            }
            else {
                ellipse.Fill = Brushes.Green;
            }
            RecalcDisplay();
        }

        private void RecalcDisplay()
        {
            red = 0;
            green = 0;
            for (int row = 0; row < 8; row++)
                for (int column = 0; column < 8; column++)
                {
                    Brush b = ellipses[column, row].Fill;
                    bool isRed = b == Brushes.Red || b == Brushes.DarkOrange;
                    bool isGreen = b == Brushes.Green || b == Brushes.DarkOrange;
                    int idx = row + column * 8;
                    ulong mask = 1UL << idx;
                    if (isRed)
                        red |= mask;
                    if (isGreen)
                        green |= mask;
                }
            cCode.Text = $"drawFrame({red}LL, {green}LL);";
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
            ScoreBoard scores = new ScoreBoard(game);

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

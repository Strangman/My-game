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

namespace jRPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Privat Members
        private CellInner[] result;
        private bool isStart;
        #endregion

        #region Constractor
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion

        #region NewGame
        public void NewGame()
        {
            result = new CellInner[25];
            isStart = true;
            for(int i = 0; i < result.Length; i++ )
            {
                result[i] = CellInner.None;
            }
            GameTable.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Background = Brushes.Azure;
                button.Content = string.Empty;
            });
        }
        #endregion

        #region Randomize
        private void Randomize()
        {
            Random random = new Random();
            for (int i =0; i<4 ;i++)
            {
                int ran_num = 0;
                do
                {
                    ran_num = random.Next(0, 25);
                }
                while (result[ran_num] == CellInner.Bomb && result[ran_num] != CellInner.Checked);

                result[ran_num] = CellInner.Bomb;
                
            }
        }
        #endregion

        #region button_Click
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 5);

            if(result[index] == CellInner.Bomb && result[index] != CellInner.Checked)
            {
                button.Background = Brushes.Red;
                MessageBox.Show("You die");
                NewGame();
                return;
            }
            else
            {
                button.Background = Brushes.White;
                result[index] = CellInner.Checked;
                if (isStart)
                {
                    Randomize();
                    isStart ^= true;
                }
                CircleCheck(button);
            }
            if(!result.Any(free => free == CellInner.None))
            {
                MessageBox.Show("You win");
                NewGame();
            }
        }
        #endregion

        #region CircleCheck
        public void CircleCheck(Button button)
        {
            int bombs = 0;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            
            int i_max = row == 4 ? 2 : 3;
            for ( int i = row == 0 ? 1 : 0 ; i < i_max; i++)
            {
                int row_check = i + row - 1;
                int a_max = column == 4 ? 2 : 3;
                for (int a = column == 0 ? 1 : 0; a < a_max; a++)
                {
                    int column_check = a + column - 1;
                    var index = column_check + (row_check * 5);
                    if (result[index] == CellInner.Bomb)
                        bombs++;
                }
            }
            button.Content = bombs.ToString();
        }
        #endregion 

        #region button_MouseRightButtonUp
        private void button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 5);

            if (result[index] != CellInner.Checked)
            {
                button.Background = Brushes.Red;
            }
        }
        #endregion
    }

}

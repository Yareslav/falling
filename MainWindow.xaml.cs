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
using System.Timers;
namespace wpf2
{
    public partial class MainWindow : Window
    {
        Timer time = new Timer();
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            time.Interval = 100;
            time.Elapsed += BlockFolling;
            SetElements();
            time.Start();
        }
        private void BlockFolling(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var textBlocks = Falling.Children;
                for (var i = 0; i < textBlocks.Count; i++)
                {
                    var elem = (TextBlock)(textBlocks[i]);
                    elem.Text = (int.Parse(elem.Text) + rand.Next(10, 50))+"";
                    var margins = elem.Margin;
                    if (margins.Top < 600) elem.Margin = new Thickness(0, margins.Top+20, 0, 0);
                    else
                    {
                        SetElements();
                        break;
                    }
                }
            });
        }
        private void SetElements()
        {
            Falling.Children.Clear();
            void Logic(string type)
            {
                var textBlocksNumber = rand.Next(5, 20);
                var elements = new TextBlock[textBlocksNumber];
                for (var i = 0; i < textBlocksNumber; i++)
                {
                    var textBox = new TextBlock();
                    textBox.Text = rand.Next(0, 300) + "";
                    if (i == 0) textBox.Foreground = Brushes.White;
                    else if (i == 1) textBox.Foreground = Brushes.LightGreen;
                    else textBox.Foreground = Brushes.DarkGreen;
                    textBox.Margin = new Thickness(0,10 * i, 200, 0);
                    Falling.Children.Add(textBox);
                }
            }
            Logic("left");
            Logic("right");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Sync
        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            CountOne();
            CountTwo();
            int a = 0;
        }

        private void CountOne()
        {
             int result = 0;
            for (int i = 0; i < 10; i++)
            {
                result += i;
                Thread.Sleep(100);
            }
            One.Text = result.ToString();
        }

        private void CountTwo()
        {
            int result = 0;
            for (int i = 0; i < 100; i++)
            {
                result += i;
                Thread.Sleep(100);
            }
            Two.Text = result.ToString();
        }

        #endregion

        #region Async
        private async Task CountOneAsync()
        {
            One.Text = await Task<string>.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 10; i++)
                {
                    result += i;
                    Thread.Sleep(500);
                }
                return result.ToString();
            });
        }

        private async Task CountTwoAsync()
        {
            Two.Text = await Task<string>.Run(() =>
            {
                int result = 0;
                for (int i = 0; i < 100; i++)
                {
                    result += i;
                    Thread.Sleep(100);
                }
                return result.ToString();
            });
        }

        private void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            CountOneAsync();
            CountTwoAsync();
        }

        #endregion

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            One.Text = string.Empty;
            Two.Text = string.Empty;
        }

    }
}

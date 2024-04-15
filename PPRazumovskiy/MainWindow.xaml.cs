using PPRazumovskiy.Pages;
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

namespace PPRazumovskiy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new StartPage());
            GlobalElement.mainFrame = mainFrame;
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalElement.mainFrame.Navigate(new CalculatePage());
        }

        private void randomBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalElement.mainFrame.Navigate(new MathPage());
        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalElement.mainFrame.Navigate(new BookPage());
        }

        private void jonhsonBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalElement.mainFrame.Navigate(new JonhsonPage());
        }
    }
}

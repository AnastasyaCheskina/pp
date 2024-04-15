using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPRazumovskiy.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculatePage.xaml
    /// </summary>
    public partial class CalculatePage : Page
    {
        public CalculatePage()
        {
            InitializeComponent();
            answerDataGrid.Visibility = Visibility.Hidden;
        }


        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[0];
            exampleTextBox.Focus();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[1];
            exampleTextBox.Focus();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[2];
            exampleTextBox.Focus();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[3];
            exampleTextBox.Focus();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[4];
            exampleTextBox.Focus();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[5];
            exampleTextBox.Focus();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[6];
            exampleTextBox.Focus();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[7];
            exampleTextBox.Focus();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            exampleTextBox.Text += GlobalElement.allSymbols[8];
            exampleTextBox.Focus();
        }

        private void getAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            answerDataGrid.ItemsSource = null;
            string text = exampleTextBox.Text;
            if (text.Length > 0)
            {
                if (text[0].ToString() == GlobalElement.allSymbols[0])
                {
                    if (!GlobalElement.allSymbols.Contains(text[text.Length - 1].ToString()))
                    {
                        answerDataGrid.AutoGenerateColumns = false;
                        //var dataContext = new Calculate(text);
                        //answerDataGrid.ItemsSource = dataContext.CalculateElements;
                        //foreach (var item in dataContext.CalculateElements)
                        //{
                        //    answerDataGrid.Columns.Add(
                        //        new DataGridTextColumn { Header = item.Header }
                        //        );
                        //}
                        var data = new Calculate(text).All;
                        //answerDataGrid.ItemsSource = data.ToDataTable().DefaultView;
                        answerDataGrid.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (!GlobalElement.allSymbols.Contains(text[0].ToString()) && !GlobalElement.allSymbols.Contains(text[text.Length - 1].ToString()))
                    {
                        answerDataGrid.AutoGenerateColumns = false;
                        //var dataContext = new Calculate(text);
                        //answerDataGrid.ItemsSource = dataContext.CalculateElements;
                        //foreach (var item in dataContext.CalculateElements)
                        //{
                        //    answerDataGrid.Columns.Add(
                        //        new DataGridTextColumn { Header = item.Header }
                        //        );
                        //}
                        var data = new Calculate(text).All;
                        //answerDataGrid.ItemsSource = data.ToDataTable().DefaultView;
                        answerDataGrid.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}

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

namespace PPRazumovskiy.Pages
{
    /// <summary>
    /// Логика взаимодействия для MathPage.xaml
    /// </summary>
    public partial class MathPage : Page
    {
        private bool isVisible = false;
        public MathPage()
        {
            InitializeComponent();
        }

        private void getAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int stockValue1 = Convert.ToInt32(stock1.Text.ToString());
                int stockValue2 = Convert.ToInt32(stock2.Text.ToString());
                int stockValue3 = Convert.ToInt32(stock3.Text.ToString());
                int sumStock = stockValue1 + stockValue2 + stockValue3;
                int needsValue1 = Convert.ToInt32(needs1.Text.ToString());
                int needsValue2 = Convert.ToInt32(needs2.Text.ToString());
                int needsValue3 = Convert.ToInt32(needs3.Text.ToString());
                int sumNeeds = needsValue1 + needsValue2 + needsValue3;
                if (sumNeeds == sumStock)
                {
                    int valueArray1 = Convert.ToInt32(value1.Text);
                    int valueArray2 = Convert.ToInt32(value2.Text);
                    int valueArray3 = Convert.ToInt32(value3.Text);
                    int valueArray4 = Convert.ToInt32(value4.Text);
                    int valueArray5 = Convert.ToInt32(value5.Text);
                    int valueArray6 = Convert.ToInt32(value6.Text);
                    int valueArray7 = Convert.ToInt32(value7.Text);
                    int valueArray8 = Convert.ToInt32(value8.Text);
                    int valueArray9 = Convert.ToInt32(value9.Text);

                    int[] needs = new int[3];
                    int[] stock = new int[3];
                    if (stockValue1 >= 0 && stockValue2 >= 0 && stockValue3 >= 0 && needsValue1 >= 0 && needsValue2 >= 0 && needsValue3 >= 0 && 
                        valueArray1 >= 0 && valueArray2 >= 0 && valueArray3 >= 0 && valueArray4 >= 0 && valueArray5 >= 0 && valueArray6 >= 0 && valueArray7 >= 0 && valueArray8 >= 0 && valueArray9 >= 0)
                    {
                        needs[0] = needsValue1;
                        needs[1] = needsValue2;
                        needs[2] = needsValue3;
                        stock[0] = stockValue1;
                        stock[1] = stockValue2;
                        stock[2] = stockValue3;

                        int[,] array = new int[3, 3];
                        array[0, 0] = valueArray1;
                        array[0, 1] = valueArray2;
                        array[0, 2] = valueArray3;
                        array[1, 0] = valueArray4;
                        array[1, 1] = valueArray5;
                        array[1, 2] = valueArray6;
                        array[2, 0] = valueArray7;
                        array[2, 1] = valueArray8;
                        array[2, 2] = valueArray9;

                        int[,] answerArray = GlobalElement.GetAnswerNorthwestCorner(array, stock, needs);
                        int answer = GlobalElement.GetSum(array, answerArray);

                        answerText.Text = answer.ToString();

                        answer1.Text = answerArray[0, 0].ToString();
                        answer2.Text = answerArray[0, 1].ToString();
                        answer3.Text = answerArray[0, 2].ToString();
                        answer4.Text = answerArray[1, 0].ToString();
                        answer5.Text = answerArray[1, 1].ToString();
                        answer6.Text = answerArray[1, 2].ToString();
                        answer7.Text = answerArray[2, 0].ToString();
                        answer8.Text = answerArray[2, 1].ToString();
                        answer9.Text = answerArray[2, 2].ToString();

                        answerPanel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Решение задачи с такими входными данными невозможно");
                        answerPanel.Visibility = Visibility.Hidden;
                    }  
                }
                else
                {
                    MessageBox.Show("Решение задачи с такими входными данными невозможно");
                    answerPanel.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так :(\nСообщение об ошибке: " + ex.Message);
                answerPanel.Visibility = Visibility.Hidden;
            }
        }
    }
}

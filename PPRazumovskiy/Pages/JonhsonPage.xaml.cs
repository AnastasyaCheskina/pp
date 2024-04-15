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
    /// Логика взаимодействия для JonhsonPage.xaml
    /// </summary>
    public partial class JonhsonPage : Page
    {
        public JonhsonPage()
        {
            InitializeComponent();
        }

        private void getAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int value1 = Convert.ToInt32(input1.Text.ToString());
                int value2 = Convert.ToInt32(input2.Text.ToString());
                int value3 = Convert.ToInt32(input3.Text.ToString());
                int value4 = Convert.ToInt32(input4.Text.ToString());
                int value5 = Convert.ToInt32(input5.Text.ToString());
                int value6 = Convert.ToInt32(input6.Text.ToString());
                int value7 = Convert.ToInt32(input7.Text.ToString());
                int value8 = Convert.ToInt32(input8.Text.ToString());
                int value9 = Convert.ToInt32(input9.Text.ToString());
                int value10 = Convert.ToInt32(input10.Text.ToString());
                int value11 = Convert.ToInt32(input11.Text.ToString());
                int value12 = Convert.ToInt32(input12.Text.ToString());

                if (value1 >= 0 && value2 >= 0 && value3 >= 0 && value4 >= 0 && value5 >= 0 &&
                    value6 >= 0 && value7 >= 0 && value8 >= 0 && value9 >= 0 && value10 >= 0 &&
                    value11 >= 0 && value12 >= 0)
                {
                    int[,] array = new int[6, 2];
                    array[0,0] = value1;
                    array[0,1] = value2;
                    array[1, 0] = value3;
                    array[1, 1] = value4;
                    array[2, 0] = value5;
                    array[2, 1] = value6;
                    array[3, 0] = value7;
                    array[3, 1] = value8;
                    array[4, 0] = value9;
                    array[4, 1] = value10;
                    array[5, 0] = value11;
                    array[5, 1] = value12;
                    int[,] answerArray = GlobalElement.Redistribution(array);
                    answerArray = GlobalElement.SortArray(answerArray);
                    int answer = GlobalElement.GetAnswer(answerArray);

                    answerText.Text = answer.ToString();

                    answer1.Text = answerArray[0, 0].ToString();
                    answer2.Text = answerArray[0, 1].ToString();
                    answer3.Text = answerArray[1, 0].ToString();
                    answer4.Text = answerArray[1, 1].ToString();
                    answer5.Text = answerArray[2, 0].ToString();
                    answer6.Text = answerArray[2, 1].ToString();
                    answer7.Text = answerArray[3, 0].ToString();
                    answer8.Text = answerArray[3, 1].ToString();
                    answer9.Text = answerArray[4, 0].ToString();
                    answer10.Text = answerArray[4, 1].ToString();
                    answer11.Text = answerArray[5, 0].ToString();
                    answer12.Text = answerArray[5, 1].ToString();

                    answerPanel.Visibility = Visibility.Visible;
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

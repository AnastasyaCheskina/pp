using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPRazumovskiy
{
    public static class GlobalElement
    {
        public static Frame mainFrame = new Frame();
        public static List<string> allSymbols = new List<string>() { "¬", "∧", "∨", "⊕", "↑", "↓", "⇔", "⊙", "⇒" };
        private static int[,] InitArrayZero(int n) //инициализация нулями (для удобства)
        {
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = 0;
                }
            }
            return array;
        }
        public static int[,] GetAnswerNorthwestCorner(int[,] array, int[] stock, int[] needs) //алгоритм распределения северо-западным углом
        {
            int[,] answerArray = InitArrayZero(array.GetLength(0));
            int min;
            for (int i = 0; i < answerArray.GetLength(0); i++)
            {
                for (int j = 0; j < answerArray.GetLength(0); j++)
                {
                    if (needs[j] == 0) continue;
                    min = Math.Min(stock[i], needs[j]);
                    answerArray[i, j] = min;
                    stock[i] -= min;
                    needs[j] -= min;
                    if (stock[i] == 0) break;
                }
            }
            return answerArray;
        }
        public static int GetSum(int[,] array, int[,] answerArray) //получить ответ
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += answerArray[i, j] * array[i, j];
                }
            }
            return sum;
        }

        public static int GetAnswer(int[,] allSt) //поиск ответа
        {
            int sum = allSt[0, 0];
            List<int> allResults = new List<int>();
            allResults.Add(sum); //первое значение добавляем по-умолчанию
            for (int i = 1; i < allSt.GetLength(0); i++)
            {
                sum = sum + allSt[i, 0] - allSt[i - 1, 1];
                allResults.Add(sum);
            }
            int answer = allResults.Max();
            return answer;
        }
        public static int[,] Redistribution(int[,] allSt) //алгоритм перераспределения
        {
            int[,] newSt = new int[allSt.GetLength(0), allSt.GetLength(1)];
            List<int> infAboutMin = new List<int>();
            List<int> firstColumn = new List<int>();
            List<int> secondColumn = new List<int>();
            int indStr = 0;
            int indSt = 0;
            for (int i = 0; i < allSt.GetLength(0); i++) //само распределение (два листа)
            {
                infAboutMin = FindMinElInArr(allSt); //лист с общей информацией о мин. эл-те
                indStr = infAboutMin[1];
                indSt = infAboutMin[2];
                if (indSt == 0)
                {
                    firstColumn.Add(allSt[indStr, indSt]);
                    firstColumn.Add(allSt[indStr, indSt + 1]);
                    allSt[indStr, indSt] = 0;
                    allSt[indStr, indSt + 1] = 0;
                }
                else if (indSt == 1)
                {
                    secondColumn.Add(allSt[indStr, indSt - 1]);
                    secondColumn.Add(allSt[indStr, indSt]);
                    allSt[indStr, indSt - 1] = 0;
                    allSt[indStr, indSt] = 0;
                }
            }
            //добавление в первый лист элементов из второго (переворачиваем)
            for (int i = secondColumn.Count - 1; i > 0; i -= 2) //цикл идет с конца
            {
                firstColumn.Add(secondColumn[i - 1]);
                firstColumn.Add(secondColumn[i]);
            }
            //в массив двумерный переделываем
            int k = 1;
            for (int i = 0; i < newSt.GetLength(0); i++)
            {
                newSt[i, 0] = firstColumn[k - 1];
                newSt[i, 1] = firstColumn[k];
                k += 2;
            }
            return newSt;
        }
        public static int[,] SortArray(int[,] allSt) //сортируем на случай если минимальные элементы одинаковые
        {
            int temp;
            for (int i = 1; i < allSt.GetLength(0); i++)
            {
                if (allSt[i - 1, 0] == allSt[i, 0])
                {
                    if (allSt[i - 1, 1] < allSt[i, 1])
                    {
                        temp = allSt[i - 1, 1];
                        allSt[i - 1, 1] = allSt[i, 1];
                        allSt[i, 1] = temp;
                    }
                }
                if (allSt[i - 1, 1] == allSt[i, 1])
                {
                    if (allSt[i - 1, 0] > allSt[i, 0])
                    {
                        temp = allSt[i - 1, 0];
                        allSt[i - 1, 0] = allSt[i, 0];
                        allSt[i, 0] = temp;
                    }
                }
            }
            return allSt;
        }
        private static List<int> FindMinElInArr(int[,] arr) //найти минимальный элемент и его индексы
        {
            int min = int.MaxValue;
            int indStr = 0;
            int indSt = 0;
            List<int> infAboutMin = new List<int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0 && min > arr[i, j])
                    {
                        min = arr[i, j];
                        indStr = i;
                        indSt = j;
                    }
                }
            }
            infAboutMin.Add(min);
            infAboutMin.Add(indStr);
            infAboutMin.Add(indSt);
            return infAboutMin;
        }

    }
}

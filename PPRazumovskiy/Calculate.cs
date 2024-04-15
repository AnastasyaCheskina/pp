using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRazumovskiy
{
    public class Calculate
    {
        //int countColumn;
        int countRow;
        string text = string.Empty;
        List<string> allOperation = new List<string>();
        List<string> allVariables = new List<string>();
        List<string> allHeaders = new List<string>();
        List<CalculateElement> calculateElements = new List<CalculateElement>();
        string[,] all = new string[0,0];
        public Calculate(string text)
        {
            this.text = text;
            for (int i = 0; i < text.Length; i++)
            {
                if (GlobalElement.allSymbols.Contains(i.ToString())) allOperation.Add(i.ToString());
                else allVariables.Add(i.ToString());
            }
            //countColumn = allOperation.Count + allVariables.Count;
            countRow = Convert.ToInt32(Math.Pow(2,allVariables.Count));
            getAllHeaders(text);
            foreach (var header in allHeaders)
            {
                calculateElements.Add(new CalculateElement(header));
            }
            all = new string[countRow,calculateElements.Count];
            for (int i = 0; i < all.GetLength(1); i++)
            {
                all[0,i] = calculateElements[i].Header;
            }
        }
        private void getAllHeaders(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!GlobalElement.allSymbols.Contains(text[i].ToString())) allHeaders.Add(text[i].ToString());
            }
            //отрицание
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i].ToString() + text[i+1]);
            }
            //штрих шеффера
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[4])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //стрелка пирса
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[5])
                {
                    if (text[i+1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i-1].ToString() + text[i].ToString() + text[i+1].ToString() + text[i+2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //исключающее не или
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[7])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //конъюнкция
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[1])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //дизъюнкция
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[2])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //сумма по модулю 2
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[3])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //импликация
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[8])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
            //эквиваленция
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == GlobalElement.allSymbols[6])
                {
                    if (text[i + 1].ToString() == GlobalElement.allSymbols[0]) allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString());
                    else allHeaders.Add(text[i - 1].ToString() + text[i].ToString() + text[i + 1].ToString());
                }
            }
        }

        //public int CountColumn { get => countColumn; set => countColumn = value; }
        public int CountRow { get => countRow; set => countRow = value; }
        public List<string> AllOperation { get => allOperation; set => allOperation = value; }
        public List<string> AllVariables { get => allVariables; set => allVariables = value; }
        public List<CalculateElement> CalculateElements { get => calculateElements; set => calculateElements = value; }
        public string[,] All { get => all; set => all = value; }

        public class CalculateElement
        {
            string header;
            List<Values> values = new List<Values>();
            public CalculateElement(string header)
            {
                this.header = header;
            }

            public string Header { get => header; set => header = value; }
            public List<Values> Values1 { get => values; set => values = value; }
            public class Values
            {
                string value;

                public Values(string value)
                {
                    this.value = value;
                }

                public string Value { get => value; set => this.value = value; }
            }
        }
    }
}

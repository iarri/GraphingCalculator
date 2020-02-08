using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace GraphingCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Enter_Key_Click(object sender, EventArgs e)
        {
            //if(e.Key == Enter_Key.Enter)
            //{
            //string[] text = textBox1.Text.Split('+');
            //textBox1.Text = Convert.ToString(Convert.ToDouble(text[0]) + Convert.ToDouble(text[1]));
            //}

            //answer.text = Calcualte(textBox1.Text);
            //answer.Text = RemoveBrackets(textBox1.Text);
            textBox1.Text = RemoveBrackets(textBox1.Text);
        }

        public string RemoveBrackets(string text)
        {
            while (text.Contains('(') && text.Contains(')'))
            {
                int openIndex = 0;
                int closeIndex = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '(')
                    {
                        openIndex = i;
                    }
                    if (text[i] == ')')
                    {
                        closeIndex = i;
                        text = text.Remove(openIndex, closeIndex-openIndex + 1).Insert(openIndex, ResolveBrackets(openIndex, closeIndex, text));

                        break;
                    }
                }

            }


            for(int i = 1; i < text.Length; i++)
            {
                if(text[i] == '-' && (text[i-1] == '*' || text[i - 1] == '/'))
                {
                    for (int j = i-1; j >= 0; j--)
                    {
                        if (text[j] == '+')
                        {
                            StringBuilder text1 = new StringBuilder(text);
                            text1[j] = '-';
                            text = text1.ToString();
                            text = text.Remove(i, 1);
                            break;
                        }
                        else if (text[j] == '-')
                        {
                            StringBuilder text1 = new StringBuilder(text);
                            text1[j] = '+';
                            text = text1.ToString();
                            text = text.Remove(i, 1);
                            break;
                        }
                    }
                }
            }


            for (int i = 1; i < text.Length; i++ )
            {
                if (text[i] == '-' && (text[i - 1] == '-' || text[i - 1] == '*'))
                {
                    if(text[i - 1] == '-')
                    {
                        StringBuilder text1 = new StringBuilder(text);
                        text1[i] = '+';
                        text = text1.ToString();
                        text = text.Remove(i-1, 1);
                    }
                    else
                    {
                        StringBuilder text1 = new StringBuilder(text);
                        text1[i] = '-';
                        text = text1.ToString();
                        text = text.Remove(i - 1, 1);
                    }
                }
                else if (text[i] == '+' && (text[i - 1] == '-' || text[i - 1] == '*'))
                {
                    if (text[i - 1] == '-')
                    {
                        StringBuilder text1 = new StringBuilder(text);
                        text1[i] = '-';
                        text = text1.ToString();
                        text = text.Remove(i - 1, 1);
                    }
                    else 
                    {
                        StringBuilder text1 = new StringBuilder(text);
                        text1[i] = '+';
                        text = text1.ToString();
                        text = text.Remove(i - 1, 1);
                    }
                }
            }


            if (text[0] == '-')
            {
                text = '0' + text;
            }
            return Calculate(text);
        }





        private void Multiply_Key_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }


        private void Divide_Key_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void Add_Key_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }


        private void Subtract_Key_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }


        public string ResolveBrackets(int openIndex, int closeIndex, string text)
        {
            string bracketAnswer = Calculate(text.Substring(openIndex + 1, closeIndex - openIndex - 1));
            return bracketAnswer;
        }

        private string Calculate (string text)
        {
            double FinalAnswer = AddAndSubtract(text);

            return FinalAnswer.ToString();
        }




        private double AddAndSubtract (string text1)
        {
            string[] text = text1.Split('-');
            List<string> textList = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                textList.Add(text[i]);
                if (i != text.Length - 1) 
                { 
                    textList.Add("-");
                }
            }

            for(int i = 0; i < textList.Count; i++)
            {
                if(textList[i].Contains('+') && textList[i].Length > 1)
                {
                    string[] textPart = textList[i].Split('+');

                    textList.RemoveAt(i);

                    for (int j = textPart.Length - 1; j >= 0; j--)
                    {
                        textList.Insert (i, (textList[j]));
                        if (j != 0)
                        {
                            textList.Insert(i, "+");
                        }
                    }
                }
            }


            double total;
            if (textList[0].Contains('*') || textList[0].Contains('/'))
            {
                total = DivideAndMultiply(textList[0]);
            }
            else
            {
                total = Convert.ToDouble(textList[0]);
            }
            
            for (int i = 2; i < textList.Count; i += 2)
            {
                if (textList [i - 1] == "-")
                {
                    total = total - DivideAndMultiply(textList[i]);
                }
                else if (textList [i - 1] == "+")
                {
                    total = total + DivideAndMultiply(textList[i]);
                }

            }

            return total;
        }






        private double DivideAndMultiply(string text1)
        {

            string[] text = text1.Split('*');
            List<string> textList = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                textList.Add(text[i]);
                if (i != text.Length - 1)
                {
                    textList.Add("*");
                }
            }

            for (int i = 0; i < textList.Count; i++)
            {
                if (textList[i].Contains('/') && textList[i].Length > 1)
                {
                    string[] textPart = textList[i].Split('/');

                    textList.RemoveAt(i);

                    for (int j = textPart.Length - 1; j >= 0; j--)
                    {
                        textList.Insert(i, (textList[j]));
                        if (j != 0)
                        {
                            textList.Insert(i, "/");
                        }
                    }




                }
            }


            double total = Convert.ToDouble(textList[0]);
            for (int i = 2; i < textList.Count; i += 2)
            {
                if (textList[i - 1] == "/")
                {
                    total = total / Convert.ToDouble(textList[i]);
                }
                else if (textList[i - 1] == "*")
                {
                    total = total * Convert.ToDouble(textList[i]);
                }

            }

            return total;

           

            //return total;
        }


        private double Divide(string text1)
        {
            string[] text = text1.Split('/');

            double total = Convert.ToDouble(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                total = total / Convert.ToDouble(text[i]);
            }

            return total;

        }


        private void Button_ClickNumber(object sender, EventArgs e)
        {

            if (sender.ToString() == "System.Windows.Forms.Button, Text: 1")
            {
                textBox1.Text += '1';
            }


            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 2")
            {
                textBox1.Text += "2";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 3")
            {
                textBox1.Text += "3";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 4")
            {
                textBox1.Text += "4";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 5")
            {
                textBox1.Text += "5";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 6")
            {
                textBox1.Text += "6";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 7")
            {
                textBox1.Text += "7";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 8")
            {
                textBox1.Text += "8";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 9")
            {
                textBox1.Text += "9";

            }

            else if (sender.ToString() == "System.Windows.Forms.Button, Text: 0")
            {
                textBox1.Text += "0";

            }

        }

        private void Button_ClickLetter(object sender, EventArgs e)
        {
            if (sender.ToString() == "System.Windows.Forms.Button, Text: a")
            {
                textBox1.Text += 'a';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: b")
            {
                textBox1.Text += 'b';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: c")
            {
                textBox1.Text += 'c';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: d")
            {
                textBox1.Text += 'd';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: e")
            {
                textBox1.Text += 'e';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: f")
            {
                textBox1.Text += 'f';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: g")
            {
                textBox1.Text += 'g';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: h")
            {
                textBox1.Text += 'h';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: i")
            {
                textBox1.Text += 'i';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: j")
            {
                textBox1.Text += 'j';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: k")
            {
                textBox1.Text += 'k';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: l")
            {
                textBox1.Text += 'l';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: m")
            {
                textBox1.Text += 'm';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: n")
            {
                textBox1.Text += 'n';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: o")
            {
                textBox1.Text += 'o';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: p")
            {
                textBox1.Text += 'p';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: q")
            {
                textBox1.Text += 'q';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: r")
            {
                textBox1.Text += 'r';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: s")
            {
                textBox1.Text += 's';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: t")
            {
                textBox1.Text += 't';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: u")
            {
                textBox1.Text += 'u';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: v")
            {
                textBox1.Text += 'v';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: w")
            {
                textBox1.Text += 'w';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: x")
            {
                textBox1.Text += 'x';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: y")
            {
                textBox1.Text += 'y';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text: z")
            {
                textBox1.Text += 'z';
            }
            if (sender.ToString() == "System.Windows.Forms.Button, Text:  ")
            {
                textBox1.Text += ' ';
            }

        }







    }
}

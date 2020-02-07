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

            Calcualte(textBox1.Text);
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



        private void Calcualte (string text)
        {
            double FinalAnswer = Subtract(text);

            textBox1.Text = FinalAnswer.ToString();
        }




        private double Subtract (string text1)
        {
            string[] text = text1.Split('-');

            double total = Add(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                total = total - Add(text[i]);
            }

            return total;
        }



        private double Add (string text1)
        {
            string[] text = text1.Split('+');

            double total = Multiply(text[0]);
            for(int i= 1; i < text.Length; i++)
            {
                total = total + Multiply(text[i]);
            }

            return total;

        }


        private double Multiply(string text1)
        {
            string[] text = text1.Split('*');

            double total = Divide(text[0]);
            for(int i = 1;  i < text.Length; i++)
            {
                total = total * Divide(text[i]);
            }

            return total;
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

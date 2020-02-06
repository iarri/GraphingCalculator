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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://stackoverflow.com/questions/19747809/exception-handling-for-non-numeric-textbox-with-windows-form-in-c-sharp
//I looked at this stack overflow page for figuring out try and catch blocks for my exception handling 

namespace Lab3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Kfir Flank - Lab3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty; //clear result textbox when clear is clicked
            textBox2.Text = "0";
        }

        private void Add_Click(object sender, EventArgs e)
        {   
            try
            {
                Double d = Double.Parse(textBox1.Text);
                double a, b, sum;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                sum = a + b;
                textBox2.Text = Convert.ToString(sum);
                textBox1.Text = string.Empty;
            }
            catch (FormatException)
            {
                MessageBox.Show("invalid or missing value!");
            }
      
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            try
            {
                Double d = Double.Parse(textBox1.Text);
                double a, b, sum;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                sum = b - a;
                textBox2.Text = Convert.ToString(sum);
                textBox1.Text = string.Empty;
            }
            catch (FormatException)
            {
                MessageBox.Show("invalid or missing value!");
            }
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            try
            {
                Double d = Double.Parse(textBox1.Text);
                double a, b, sum;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                sum = a * b;
                textBox2.Text = Convert.ToString(sum);
                textBox1.Text = string.Empty;
            }

            catch (FormatException)
            {
                MessageBox.Show("invalid or missing value!");
            }
        }

        private void Div_Click(object sender, EventArgs e)
        {
            try
            {
                Double d = Double.Parse(textBox1.Text);
                double a, b, sum;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                sum = b / a;
                textBox2.Text = Convert.ToString(sum);
                textBox1.Text = string.Empty;
            }
            catch (FormatException)
            {
                MessageBox.Show("invalid or missing value!");
            }

        }
    }
}

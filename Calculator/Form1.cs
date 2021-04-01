using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = String.Empty;
        double result;
        string[] tokens = new string[] { };
        Stack<double> stack = new Stack<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void operand_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input += btn.Text;
            textBox1.Text += input;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input += btn.Text;
            textBox1.Text += input;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input += btn.Text;
            textBox1.Text += input;
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input = input.Remove(input.Length - 1, 1);
            textBox1.Text += input;
        }

        private void leftParenthesis_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input += btn.Text;
            textBox1.Text += input;
        }

        private void rightParenthesis_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = "";
            input += btn.Text;
            textBox1.Text += input;
        }

        private void erase_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            input = string.Empty;
        }

        private void compute_Click(object sender, EventArgs e)
        {

        }

    }
}

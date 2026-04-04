
using Project_Employees_Management_System.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Calculator : Form
    {
        double firstNum = 0;
        double secondNum = 0;
        bool isFirstInput = true;
        string op = "";

        public Calculator()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;

             foreach (Control c in Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor=Color.BurlyWood;
                }
            }
          
            button11.BackColor=Color.Chocolate;
            button12.BackColor=Color.Chocolate;
            button13.BackColor=Color.Chocolate;
            button14.BackColor=Color.Chocolate;
            button15.BackColor=Color.Chocolate;
            buttonEqual.BackColor=Color.Chocolate;

            buttonCls.BackColor=Color.Yellow;
            buttonDEL.BackColor=Color.Yellow;

           btnColor.Image=Resources.BlackRed;

            foreach (Control c in Controls)
            {
                if (c is Button btn)
                {
                    btn.ForeColor = Color.Black;
                }
            }

            richTextBox1.BackColor=Color.Red;
            richTextBox1.ForeColor = Color.AliceBlue;

        }


        void Numbers(string Num)
        {
            if (isFirstInput)
            {
                richTextBox1.Clear();
                richTextBox1.Text+="\n";
                isFirstInput = false;
            }

            richTextBox1.Text += Num;
        }

        void PrintNumbers(Button btn)
        {
            int num = Convert.ToInt32(btn.Tag);
            if (num <= 9)
                Numbers(num.ToString());

            if (num==10)
            {
                if (isFirstInput)
                {
                    richTextBox1.Text="Error";
                    return;
                }

                string text = richTextBox1.Text;

                char[] ops = { '+', '-', '*', '/' };
                string[] parts = text.Split(ops);

                string lastNumber = parts[parts.Length - 1];

                if (!lastNumber.Contains("."))
                {
                    richTextBox1.Text += ".";
                }
            }


        }

        void Operations(string Op)
        {
            if (isFirstInput)
            {
                richTextBox1.Text="Error";
                return;
            }

            if (richTextBox1.Text.Contains("+") ||
       richTextBox1.Text.Contains("-") ||
       richTextBox1.Text.Contains("x") ||
       richTextBox1.Text.Contains("/") ||
       richTextBox1.Text.Contains("%"))
                return;

            op = Op;
            richTextBox1.Text+=op;
        }

        void PrintOperations(Button button)
        {
            string operation = button.Text;
            Operations(operation);

        }

        private void button_Click(object sender, EventArgs e)
        {
            PrintNumbers((Button)sender);
        }


        private void buttonOp_Click(object sender, EventArgs e)
        {
            PrintOperations((Button)sender);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") return;

            string[] Parts;
            double result = 0;
            string text = richTextBox1.Text;

            if (text.Contains("+"))
            {
                Parts = text.Split('+');
                firstNum= Convert.ToDouble(Parts[0]);
                secondNum= Convert.ToDouble(Parts[1]);

                result = firstNum + secondNum;
            }
            else if (text.Contains("-"))
            {
                Parts = text.Split('-');
                firstNum= Convert.ToDouble(Parts[0]);
                secondNum= Convert.ToDouble(Parts[1]);
                result = firstNum - secondNum;
            }
            else if (text.Contains("x"))
            {
                Parts = text.Split('x');
                firstNum= Convert.ToDouble(Parts[0]);
                secondNum= Convert.ToDouble(Parts[1]);
                result = firstNum * secondNum;
            }
            else if (text.Contains("/"))
            {
                Parts = text.Split('/');
                firstNum= Convert.ToDouble(Parts[0]);
                secondNum= Convert.ToDouble(Parts[1]);
                if (secondNum == 0)
                {
                    richTextBox1.Text = "Error";
                    return;
                }
                result = firstNum / secondNum;
            }
            else if (text.Contains("%"))
            {
                Parts = text.Split('%');
                firstNum= Convert.ToDouble(Parts[0]);
                secondNum= Convert.ToDouble(Parts[1]);
                if (secondNum == 0)
                {
                    richTextBox1.Text = "Error";
                    return;
                }
                result = firstNum % secondNum;
            }

            richTextBox1.AppendText("\n\n" + result.ToString());
            isFirstInput= true;
        }

        private void buttonCls_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            firstNum = 0;
            secondNum = 0;
            op = "";
        }

        private void buttonDEl_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text=richTextBox1.Text.Remove(richTextBox1.Text.Length-1);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (this.BackColor==Color.Black)
            {
                btnColor.Text="Red";
                btnColor.Image=Resources.RedBlack;
                this.BackColor = Color.Red;

                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.ForeColor = Color.Red;
                    }
                }

                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.BlueViolet;

            }
            else
            {
                btnColor.Text="Black";
                Form1_Load(sender, e);
            }
        }
    }
}

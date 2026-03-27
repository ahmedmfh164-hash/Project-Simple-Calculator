using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double firstNum = 0;
        double secondNum = 0;
        bool isFirstInput = true;
        string op = "";

        enum enNumbers
        {
            num0, num1,
            num2, num3,
            num4, num5,
            num6, num7,
            num8, num9,
            num10
        }

        enum enOp
        {
            opMul = 11,
            opDiv = 12,
            opAdd = 13,
            opSub = 14,
            opMod = 15
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            button1.BackColor=Color.BurlyWood;
            button2.BackColor=Color.BurlyWood;
            button3.BackColor=Color.BurlyWood;
            button4.BackColor=Color.BurlyWood;
            button5.BackColor=Color.BurlyWood;
            button6.BackColor=Color.BurlyWood;
            button7.BackColor=Color.BurlyWood;
            button8.BackColor=Color.BurlyWood;
            button9.BackColor=Color.BurlyWood;
            button0.BackColor=Color.BurlyWood;
            button10.BackColor=Color.BurlyWood;

            button11.BackColor=Color.Chocolate;
            button12.BackColor=Color.Chocolate;
            button13.BackColor=Color.Chocolate;
            button14.BackColor=Color.Chocolate;
            button15.BackColor=Color.Chocolate;
            buttonEqual.BackColor=Color.Chocolate;

            buttonCls.BackColor=Color.Yellow;
            buttonDEL.BackColor=Color.Yellow;

            button0.Tag=enNumbers.num0;
            button1.Tag=enNumbers.num1;
            button2.Tag=enNumbers.num2;
            button3.Tag=enNumbers.num3;
            button4.Tag=enNumbers.num4;
            button5.Tag=enNumbers.num5;
            button6.Tag=enNumbers.num6;
            button7.Tag=enNumbers.num7;
            button8.Tag=enNumbers.num8;
            button9.Tag=enNumbers.num9;
            button10.Tag=enNumbers.num10;

            button11.Tag=enOp.opMul;
            button12.Tag=enOp.opDiv;
            button13.Tag=enOp.opAdd;
            button14.Tag=enOp.opSub;
            button15.Tag=enOp.opMod;
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
            switch (btn.Tag)
            {
                case enNumbers.num0:
                    Numbers("0");
                    break;

                case enNumbers.num1:
                    Numbers("1");
                    break;

                case enNumbers.num2:
                    Numbers("2");
                    break;

                case enNumbers.num3:
                    Numbers("3");
                    break;

                case enNumbers.num4:
                    Numbers("4");
                    break;

                case enNumbers.num5:
                    Numbers("5");
                    break;

                case enNumbers.num6:
                    Numbers("6");
                    break;

                case enNumbers.num7:
                    Numbers("7");
                    break;

                case enNumbers.num8:
                    Numbers("8");
                    break;

                case enNumbers.num9:
                    Numbers("9");
                    break;

                case enNumbers.num10:
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
                    break;

            }
        }

        void Operations(string Op)
        {
            if (isFirstInput)
            {
                richTextBox1.Text="Error";
                return;
            }

            op = Op;
            richTextBox1.Text+=op;
        }

        void PrintOperations(Button button)
        {
            switch (button.Tag)
            {
                case enOp.opMul:
                    Operations("x");
                    break;

                case enOp.opDiv:
                    Operations("/");
                    break;

                case enOp.opAdd:
                    Operations("+");
                    break;

                case enOp.opSub:
                    Operations("-");
                    break;

                case enOp.opMod:
                    Operations("%");
                    break;
            }

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

            richTextBox1.Text+="\n\n"+Convert.ToString(result);
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
            richTextBox1.Text=richTextBox1.Text.Remove(richTextBox1.Text.Length-1);
        }

    }
}
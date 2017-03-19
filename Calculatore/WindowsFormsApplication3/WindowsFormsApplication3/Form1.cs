﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    { public static bool percpressed = false;
        public static bool numisnum = true;
        public static int memplus = 0;
        public static int memminus = 0;
        public static double percent = 0;
        public static bool equalpressed = false;
        public static double saved = 0;
        public static double saved1 = 0;
        public static int newlinecnt = 0;
        public static int pluscnt = 0;
        public static int sctn = 0; // if there is number saved in memory MR button will show nothing
        public static int ctn; //counter for operations
        public static int cnt=0; // counter created to add/substract/divide/multiplicate second number to the result
        public static int ccnt = 0;//comma counter
        public static Calculator calculator;
        public Form1()
        {
            
            InitializeComponent();
            calculator = new Calculator();
            display.Text = "0";
        }

        public void number_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (calculator.operation == Calculator.Operation.NONE ||
                calculator.operation == Calculator.Operation.NUMBER)
            {
                if (display.Text == "0" && btn.Text == ",")
                    display.Text += btn.Text;
                else if (display.Text != "0" && newlinecnt == 1)
                {
                    newlinecnt = 0;
                    display.Text = btn.Text;
                }
                else if (display.Text != "0" && equalpressed)
                {
                   
                    display.Text = btn.Text;
                    equalpressed = false;
                }
                else if (display.Text != "0")
                    display.Text += btn.Text;
                else if (display.Text == "0")
                    display.Text = btn.Text;
                
            }
            else if (calculator.operation == Calculator.Operation.PLUS )
            {
               calculator.saveFirstNumber(display.Text);
                numisnum = true;
               display.Text = btn.Text;
               ctn = 1;
               ccnt = 0;
                cnt = 0;
            }
          
            else if (calculator.operation == Calculator.Operation.SAVE)
            {
               
                display.Text = btn.Text;
                sctn = 1;
            }
            else if (calculator.operation == Calculator.Operation.MINUS)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 2;
                ccnt = 0;
                cnt = 0;
            }
            else if (calculator.operation == Calculator.Operation.DIVIDED)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 3;
                ccnt = 0;
                cnt = 0;
            }
            else if (calculator.operation == Calculator.Operation.TIMES)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 4;
                ccnt = 0;
                cnt = 0;
            }

            calculator.operation = Calculator.Operation.NUMBER;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (numisnum) { 
                if (cnt == 0)
                    calculator.saveSecondNumber(display.Text);
                else
                    calculator.saveFirstNumber(display.Text);

                newlinecnt = 1;

                switch (ctn)
                {
                    case 1:
                        display.Text = calculator.getResultPlus().ToString();
                        cnt++;
                        equalpressed = true;
                        break;
                    case 2:
                        display.Text = calculator.getResultMinus().ToString();
                        cnt++;
                        equalpressed = true;
                        break;
                    case 3:
                        display.Text = calculator.getResultDivided().ToString();
                        cnt++;
                        equalpressed = true;
                        break;
                    case 4:
                        display.Text = calculator.getResultTimes().ToString();
                        cnt++;
                        equalpressed = true;
                        break;




                }
            }

         
        }
       

        private void button11_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.PLUS;
            pluscnt++;
            if (pluscnt == 2)
            {
              display.Text = (double.Parse(display.Text) + calculator.firstNumber).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.MINUS;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (calculator.firstNumber != 0)
            {
                display.Text = "0";
                calculator.secondNumber = 0;
                ccnt = 0;
            }
            else
            {
                display.Text = "0";
                calculator.firstNumber = 0;
                ccnt = 0;
            }

           
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button30_Click(object sender, EventArgs e)
        {

            /*  if (sctn == 0)
              {

                      }

              else
              {*/
        
              
                display.Text = (saved).ToString();
     
            // }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            display.Text = Math.Sqrt(double.Parse(display.Text)).ToString();
            equalpressed = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.TIMES;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.DIVIDED;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ccnt == 0)
            {
                display.Text += ",";
                ccnt=1;
            }
            else { }
           
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            display.Text = Math.Pow(double.Parse(display.Text),2).ToString();
            equalpressed = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            display.Text = (1 / (Convert.ToDouble(display.Text))).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            ccnt = 0;
            calculator.firstNumber = 0;
            calculator.secondNumber = 0;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (equalpressed!=true)
            {
                percent = double.Parse(display.Text) / 100;
                calculator.saveSecondNumber((double.Parse(display.Text) / 100).ToString());
             
                percpressed = true;
            }
            else
            {
                switch (ctn)
                {
                    case 1:
                        display.Text = (double.Parse(display.Text) * (1 + percent)).ToString();
                        break;
                    case 2:
                        display.Text = (double.Parse(display.Text) * (1 - percent)).ToString();
                        break;
                    case 3:
                        display.Text = (double.Parse(display.Text) * (1 / percent)).ToString();
                        break;
                    case 4:
                        display.Text = (double.Parse(display.Text) * (1 * percent)).ToString();
                        break;
                }
            }
        }







        private void button14_Click(object sender, EventArgs e)
        {
            if (display.Text.Length == 0 ||display.Text=="0") 
            {
                display.Text = "0";
                  ccnt = 0;
                 }
            
            else if (display.Text.Length > 0)
            { 
            display.Text = display.Text.Substring(0, display.Text.Length - 1);
                if (display.Text.Contains(",") != true)
                {
                    ccnt = 0; 
                }
            }
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            saved = 0;
        }

        public void button27_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.SAVE;
            saved = double.Parse(display.Text);
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
        saved -= double.Parse(display.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
         
        saved += double.Parse(display.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            display.Text =( double.Parse(display.Text) *(-1)).ToString();
        }









        /*
        private void button1_Click(object sender, EventArgs e)
        {
            display.Text += "1";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            display.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            display.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            display.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            display.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            display.Text += "9";
        }
         */
    }
}

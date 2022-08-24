using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 9;
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 8;
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 7;
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 6;
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 5;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 4;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 3;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 2;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 1;
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + 0;
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + ".";
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Clear();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + "+";
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + "-";
        }

        private void BtnMulti_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + "*";
        }

        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + "/";
        }

        private async void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(TbCalculation.Text, "");
                TbCalculation.Text = result.ToString();
                Answer answer = await App.Database.GetAnswer();

                Answer newAnswer = new Answer(){Number = result.ToString()};

                if (answer == null)
                {
                    await App.Database.Insert(newAnswer);
                }
                else
                {
                    await App.Database.DeleteAnswer(answer);
                    await App.Database.Insert(newAnswer);
                }
            }
            catch
            {
                TbCalculation.Text = "Syntax Error";
            }
        }

        private void BtnLBracket_OnClick(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + "(";
        }

        private void BtnRBracket_OnClick(object sender, RoutedEventArgs e)
        {
            TbCalculation.Text = TbCalculation.Text + ")";
        }

        private async void BtnAns_OnClick(object sender, RoutedEventArgs e)
        {
            Answer answer = await App.Database.GetAnswer();
            if (answer == null)
            {
                TbCalculation.Text = TbCalculation.Text;
            }
            else
            {
                TbCalculation.Text = TbCalculation.Text + answer.Number;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Multiply) || ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && Keyboard.IsKeyDown(Key.D8)))
            {
                BtnMulti_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Divide) || Keyboard.IsKeyDown(Key.Oem2))
            {
                BtnDiv_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Add) || Keyboard.IsKeyDown(Key.OemPlus))
            {
                BtnAdd_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Subtract) || Keyboard.IsKeyDown(Key.OemMinus))
            {
                BtnSub_Click(sender, e);
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && Keyboard.IsKeyDown(Key.D9))
            {
                BtnLBracket_OnClick(sender, e);
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && Keyboard.IsKeyDown(Key.D0))
            {
                BtnRBracket_OnClick(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.NumPad1))
            {
                Btn1_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.NumPad2))
            {
                Btn2_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.NumPad3))
            {
                Btn3_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.NumPad4))
            {
                Btn4_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.NumPad5))
            {
                Btn5_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.NumPad6))
            {
                Btn6_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.NumPad7))
            {
                Btn7_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.NumPad8))
            {
                Btn8_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.NumPad9))
            {
                Btn9_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.D0) || Keyboard.IsKeyDown(Key.NumPad0))
            {
                Btn0_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Enter))
            {
                BtnEquals_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Decimal) || Keyboard.IsKeyDown(Key.OemPeriod))
            {
                BtnPoint_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.Back))
            {
                BtnAC_Click(sender, e);
            }
            else if (Keyboard.IsKeyDown(Key.LeftAlt))
            {
                BtnAns_OnClick(sender, e);
            }
        }
    }
}

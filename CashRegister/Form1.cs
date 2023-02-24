using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class greyLabel2 : Form
    {
        double mini;
        double big;
        double slurp;
        double chug;
        double miniPrice;
        double bigPrice;
        double slurpPrice;
        double chugPrice;
        double subTotal;
        double tax;
        double total;
        double change;

        public greyLabel2()
        {
            InitializeComponent();
        }

        private void totaltaxLabel_Click(object sender, EventArgs e)
        {

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //makes sure error label isnt visible
                errorLabel.Visible = false;

                //Recording numbers
                mini = Convert.ToDouble(miniInput.Text);
                big = Convert.ToDouble(bigInput.Text);
                slurp = Convert.ToDouble(slurpInput.Text);
                chug = Convert.ToDouble(chugInput.Text);

                // calculations
                miniPrice = mini * 5.25;
                bigPrice = big * 10.5;
                slurpPrice = slurp * 16;
                chugPrice = chug * 20;
                subTotal = miniPrice + bigPrice + slurpPrice + chugPrice;
                tax = subTotal * 0.13;
                total = tax + subTotal;

                //printing on screen 
                subOutput.Text = $"{subTotal.ToString("C")}";
                taxOutput.Text = $"{tax.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";
            }
            catch
            {
                //if input is wrong shows error instead of crashing 
                errorLabel.Visible = true;

            }



        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Visible = false;

                if (Convert.ToDouble(tenderedIntput.Text) > total)
                {
                    change = Convert.ToDouble(tenderedIntput.Text) - total;

                    changeOutput.Text = $"{change.ToString("C")}";

                }

                else
                {
                    changeOutput.Text = "hahaha";
                }
            }
            catch
            {
                errorLabel.Visible = true;
            }
        }

        private void receiptLabel_Click(object sender, EventArgs e)
        {
            greyBox1.Visible = true;
            greyBox2.Visible = true;
            greyBox3.Visible = true;
            greyBox4.Visible = true;
            greyBox5.Visible = true;
            blackBar.Visible = true;
            priceLabel.Visible = true;
            itemLabel.Visible = true;
            receiptOutput.Visible = true;

            //Printing stuff
            receiptOutput.Text = $"\n\nFortnite Shop\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n Thanks for shopping";
            itemLabel.Text = $"{mini} Minis\n\n{big} Big Pots\n\n{slurp} Slurp Juices\n\n{chug} Chug Jugs";
            priceLabel.Text = $"@     $5.25\n\n@     $10.50\n\n@     $16.00\n\n@     $20.00";
            itemLabel.Text += $"\n\n\n\nSub Total:\n\nTotal Tax:\n\nTotal:\n\nTendered:\n\nChange;";
            priceLabel.Text += $"\n\n\n\n{subTotal}\n\n{tax}\n\n{total}\n\n{tenderedIntput.Text}\n\n{change}";

            
            Thread.Sleep(1500);
            Refresh();

            greyBox1.Visible = false;

            Thread.Sleep(1000);
            Refresh();

            greyBox2.Visible = false;

            Thread.Sleep(990);
            Refresh();

            greyBox3.Visible = false;

            Thread.Sleep(1000);
            Refresh();

            greyBox4.Visible = false;

            Thread.Sleep(800);
            Refresh();

            greyBox5.Visible = false;

            Thread.Sleep(1300);
            Refresh();

        }
    }
}

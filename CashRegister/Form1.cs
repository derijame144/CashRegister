using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class page : Form
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
        double tendered;
        bool receipt = false;
        bool calculate = false;

         

        public page()
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

                if (miniInput.Text == "")
                {
                    miniInput.Text = "0";
                }

                if (bigInput.Text == "")
                {
                    bigInput.Text = "0";
                }

                if (slurpInput.Text == "")
                {
                    slurpInput.Text = "0";
                }

                if (chugInput.Text == "")
                {
                    chugInput.Text = "0";
                }

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

                changeButton.BackColor = Color.Turquoise;
                calculate = true; 
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
                SoundPlayer laughSound = new SoundPlayer(Properties.Resources.HAHAHAHAHA);
                errorLabel.Visible = false;

                if (calculate == true)
                {
                    if (tenderedIntput.Text == "")
                    {
                        tenderedIntput.Text = "0";
                    }

                    if (Convert.ToDouble(tenderedIntput.Text) >= total)
                    {
                        tendered = Convert.ToDouble(tenderedIntput.Text);
                        change = tendered - total;

                        changeOutput.Text = $"{change.ToString("C")}";
                        receipt = true;
                        receiptButton.BackColor = Color.Turquoise;
                       
                    }


                    else
                    {
                        laughSound.Play();
                        changeOutput.Text = "hahaha";
                    }
                }
            }
            catch
            {
                errorLabel.Visible = true;
            }
        }

        private void receiptLabel_Click(object sender, EventArgs e)
        {
            if (receipt == true)
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
                receiptOutput.Text = $"\nFortnite Shop\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n Thanks for shopping";
                itemLabel.Text = $"{mini} Minis\n\n{big} Big Pots\n\n{slurp} Slurp Juices\n\n{chug} Chug Jugs";
                priceLabel.Text = $"@     $5.25\n\n@     $10.50\n\n@     $16.00\n\n@     $20.00";
                itemLabel.Text += $"\n\n\n\nSub Total:\n\nTotal Tax:\n\nTotal:\n\nTendered:\n\nChange;";
                priceLabel.Text += $"\n\n\n\n        {subTotal.ToString("C")}\n\n        {tax.ToString("C")}\n\n        {total.ToString("C")}\n\n        {tendered.ToString("C")}\n\n        {change.ToString("C")}";

                SoundPlayer printSound = new SoundPlayer(Properties.Resources.Printersound);
                printSound.Play();

                Refresh();
                Thread.Sleep(1300);


                greyBox1.Visible = false;

                Refresh();
                Thread.Sleep(1300);

                greyBox2.Visible = false;

                Refresh();
                Thread.Sleep(1300);

                greyBox3.Visible = false;

                Refresh();
                Thread.Sleep(1300);

                greyBox4.Visible = false;

                Refresh();
                Thread.Sleep(1300);

                greyBox5.Visible = false;

                Refresh();
                Thread.Sleep(1300);

                resetButton.Visible = true;
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //makes receipt 
            greyBox1.Visible = false;
            greyBox2.Visible = false;
            greyBox3.Visible = false;
            greyBox4.Visible =  false;
            greyBox5.Visible = false;
            blackBar.Visible = false;
            priceLabel.Visible = false;
            itemLabel.Visible = false;
            receiptOutput.Visible = false;
            resetButton.Visible = false;

            // reset texts
            miniInput.Text = "";
            bigInput.Text = "";
            slurpInput.Text = "";
            chugInput.Text = "";
            subOutput.Text = "";
            taxOutput.Text = "";
            totalOutput.Text = "";
            tenderedIntput.Text = "";
            changeOutput.Text = "";

            receipt = false;
            calculate = false;

            receiptButton.BackColor = Color.LightBlue;
            changeButton.BackColor = Color.LightBlue;
        }
    }
}

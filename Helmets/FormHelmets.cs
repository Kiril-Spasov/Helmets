using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helmets
{
    public partial class FormHelmets : Form
    {
        public FormHelmets()
        {
            InitializeComponent();
        }

        /*
         NFL HELMETS PROBLEM
        There are 28 football teams in the NFL. Many supermarkets and discount stores have vending machines 
        that dispense miniature team helmets for one quarter (25 cents) each. Assume that all helmets are equally likely 
        to be dispensed by the machines. You are to write a program to simulate putting quarters in vending machines 
        until all 28 helmets have been obtained. Your output should have the form : TOTAL SPENT TO GET ALL 28 
        HELMETS =
        Run your simulation 10 times and also determine the average total spent.
         */

        private void BtnStart_Click(object sender, EventArgs e)
        {
            LstResult.Items.Clear();
            Random r = new Random();
            int hPicked = 0;
            double costsPerSimulation = 0;
            double totalCosts = 0;
            int[] helmetFlag = new int[29];

            for (int simulation = 1; simulation <= 10; simulation++)
            {
                ClearArray(helmetFlag);

                for (int i = 1; i <= 28; i++)
                {
                    do
                    {
                        costsPerSimulation += 0.25;
                        hPicked = r.Next(1, 29);
                    }
                    while (helmetFlag[hPicked] == 1);

                    helmetFlag[hPicked] += 1;
                }
                LstResult.Items.Add("Simulation " + simulation);
                LstResult.Items.Add("Total spent to get all 28 helmets: " + costsPerSimulation);
                totalCosts += costsPerSimulation;
            }
            LstResult.Items.Add(Environment.NewLine);
            LstResult.Items.Add("Average costs for 10 simulations is: " + (totalCosts / 10)).ToString("n2");
        }

        private void ClearArray(int[] ar)
        {
            for (int i = 1; i <= ar.Length - 1; i++)
            {
                ar[i] = 0;
            }
        }
    }
}

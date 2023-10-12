using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_Calculators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMortgage_Click(object sender, EventArgs e)
        {
            //create some local variabels
            double loanAmount = 0.0;
            double downPayment = 0.0;
            double interestRate = 0.0;
            double monthlyPayment=0.0;
            int terms = 0;

            // do some validation
            if (!string.IsNullOrEmpty(txtLoanAmount.Text))
            loanAmount=Convert.ToDouble(txtLoanAmount.Text);
            
            if (!string.IsNullOrEmpty(txtDownPayment.Text))
                downPayment=Convert.ToDouble(txtDownPayment.Text);

            if (!string.IsNullOrEmpty (txtInterestRate.Text))
                interestRate=Convert.ToDouble(txtInterestRate.Text);

            if(!string.IsNullOrEmpty(txtTerms.Text))
                terms= Convert.ToInt32(txtTerms.Text);

            //mortgage payment calculation logic
            //Formula : payment =(loan amount - down payment) *(1+interest rate/12)^terms*12

            int termsinMonths = terms * 12;
              monthlyPayment = (loanAmount - downPayment)*(Math.Pow((1 +interestRate/12),termsinMonths)* interestRate)/(12*(Math.Pow((1 +interestRate/12),termsinMonths)-1));
            monthlyPayment = Math.Round(monthlyPayment, 2);
            //display the results
            lblMonthlyPayment.Text = string.Format("Monthly Payment: R {0}", monthlyPayment.ToString());

          


        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            //create some local variabels
            double loanAmount = 0.0;
            double downPayment = 0.0;
            double interestRate = 0.0;
            double monthlyPayment = 0.0;
            int terms = 0;

            // do some validation
            if (!string.IsNullOrEmpty(txtLoanAmount.Text))
                loanAmount = Convert.ToDouble(txtLoanAmount.Text);

            if (!string.IsNullOrEmpty(txtDownPayment.Text))
                downPayment = Convert.ToDouble(txtDownPayment.Text);

            if (!string.IsNullOrEmpty(txtInterestRate.Text))
                interestRate = Convert.ToDouble(txtInterestRate.Text);

            if (!string.IsNullOrEmpty(txtTerms.Text))
                terms = Convert.ToInt32(txtTerms.Text);

            //mortgage payment logic
            //formula : payment = (loan amount * interest rate) / (1-(1+interest rate)^ terms
            int termsinMonths = terms * 12;         interestRate /= 12;
            monthlyPayment = (interestRate * loanAmount) / (1 -Math.Pow(1+interestRate, termsinMonths* -1));
            monthlyPayment = Math.Round(monthlyPayment, 2);
            
            //display the result
            lblMonthlyPayment.Text = string.Format("Monthly Payment R {0}", monthlyPayment.ToString());
           label5.Text = loanAmount.ToString();
            label6.Text = interestRate.ToString();
            label7.Text = terms.ToString();

        }
    }
}

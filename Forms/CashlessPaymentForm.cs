using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public partial class CashlessPaymentForm : Form
    {
        public CashlessPaymentForm()
        {
            InitializeComponent();
        }

        private void CashlessPaymentForm_Load(object sender, EventArgs e)
        {
            ButtonDesigner.SecondaryButtons(btnQR);
            ButtonDesigner.SecondaryButtons(btnCard);
            ShowPayment(new QRPaymentControl());

        }

        private void ShowPayment(UserControl control)
        {
            panelPaymentArea.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelPaymentArea.Controls.Add(control);
        }
      

        //Example Rani HAHHA
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            DialogResult result = MessageBox.Show(
                "Print receipt?",
                "Print Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                MessageBox.Show(
                    "Receipt printed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            ShowPayment(new CardPaymentControl());
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            ShowPayment(new QRPaymentControl());
            timer1.Start();
        }
    }
}

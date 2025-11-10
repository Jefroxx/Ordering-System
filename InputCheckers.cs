using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    internal class InputCheckers
    {
        public static bool NullChecker(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"{fieldName} cannot be empty.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static void TextOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        public static void NumbersOnly(KeyPressEventArgs e, bool allowDecimal = false)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (!(allowDecimal && e.KeyChar == '.'))
                {
                    e.Handled = true;
                }
            }
        }

        public static void DecimalOnly(KeyPressEventArgs e, TextBox textBox)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        public static bool ValidatePastOrToday(DateTimePicker datePicker, string fieldName)
        {
            if (datePicker.Value.Date > DateTime.Today)
            {
                MessageBox.Show($"{fieldName} cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datePicker.Value = DateTime.Today;
                return false;
            }
            return true;
        }

        public static bool ValidateDateNotPast(DateTimePicker datePicker, string fieldName)
        {
            if (datePicker.Value.Date < DateTime.Today)
            {
                MessageBox.Show($"{fieldName} cannot be in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datePicker.Value = DateTime.Today;
                return false;
            }
            return true;
        }

    }
}


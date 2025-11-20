using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    internal class QRListener
    {
        private TextBox inputBox;
        private Action<string> onScanComplete;

        public QRListener(TextBox textBox, Action<string> callback)
        {
            inputBox = textBox;
            onScanComplete = callback;

            inputBox.KeyDown += InputBox_KeyDown;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            // DEBUG: Shows if a key is detected at all
            MessageBox.Show("KeyDown: " + e.KeyCode);

            // QR scanners usually send Enter after the data
            if (e.KeyCode == Keys.Enter)
            {
                string scannedText = inputBox.Text.Trim();
                inputBox.Clear();

                if (!string.IsNullOrEmpty(scannedText))
                    onScanComplete(scannedText);
            }
        }
    }
}

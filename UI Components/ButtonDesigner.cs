using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public class ButtonDesigner
    {
        private static readonly Color newBlue= Color.FromArgb(40, 97, 172);
        private static readonly Color White = Color.FromArgb(255, 255, 255);
        private static readonly Color blue = Color.FromArgb(20, 174, 220);
        private static readonly Color dark = Color.FromArgb(49, 65, 88);

        
        public static void MainButtons(Button btn)
        {
            
            btn.BackColor = newBlue;
            btn.ForeColor = White;

            AddClickHighlight(btn);
        }

        public static void SecondaryButtons(Button btn)
        {
            btn.FlatAppearance.BorderSize = 2;
            btn.Font = new Font("Roboto", 14, FontStyle.Regular);
            btn.BackColor = White;
            btn.ForeColor = newBlue;

            AddClickHighlight(btn);
        }

        private static void AddClickHighlight(Button btn)
        {
            btn.Click -= Button_Click; 
            btn.Click += Button_Click;
        }

        private static void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == null || btn.Parent == null) return;


                foreach (Control sibling in btn.Parent.Controls)
                {
                    if (sibling is Button b)
                    {
                       
                        if (b.FlatAppearance.BorderSize == 0)
                            b.BackColor = White;
                        else
                            b.BackColor = newBlue;
                    }
                }

               
                btn.BackColor = newBlue;
            }
        }
    }
}

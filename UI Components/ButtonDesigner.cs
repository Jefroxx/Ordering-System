using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public class ButtonDesigner
    {
        private static readonly Color Purple= Color.FromArgb(152, 16, 250);
        private static readonly Color White = Color.FromArgb(228, 245, 237);
        private static readonly Color blue = Color.FromArgb(20, 174, 220);
        private static readonly Color dark = Color.FromArgb(49, 65, 88);

        
        public static void MainButtons(Button btn)
        {
            
            btn.BackColor = Purple;
            btn.ForeColor = White;

            AddClickHighlight(btn);
        }

        public static void SecondaryButtons(Button btn)
        {
            btn.FlatAppearance.BorderSize = 2;
            btn.Font = new Font("Roboto", 14, FontStyle.Regular);
            btn.BackColor = dark;
            btn.ForeColor = White;

            AddClickHighlight(btn);
        }

        private static void AddClickHighlight(Button btn)
        {
            btn.MouseDown += Button_Click;
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
                            b.BackColor = dark;
                    }
                }

               
                btn.BackColor = Purple;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public class ButtonDesigner
    {
        private static readonly Color MainColor= Color.FromArgb(40, 97, 172);
        private static readonly Color White = Color.FromArgb(255, 255, 240);
        private static readonly Color blue = Color.FromArgb(204, 223, 238);
        private static readonly Color bg = Color.FromArgb(247, 252, 254);

        
        public static void MainButtons(Button btn)
        {
            
            btn.BackColor = MainColor;
            btn.ForeColor = White;

            AddClickHighlight(btn);
        }

        public static void SecondaryButtons(Button btn)
        {
            btn.FlatAppearance.BorderSize = 2;
            btn.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            btn.BackColor = bg;
            btn.ForeColor = MainColor;

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
                            b.BackColor = bg;
                    }
                }

               
                btn.BackColor = MainColor;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minivilles
{
    public class CardBox : PictureBox
    {
        public int amount = 1;
        public Label cardAmount;
        public CardBox() : base()
        {

            cardAmount = new Label();
            cardAmount.Size = new Size(140, 20);

            cardAmount.Text = "x " + amount.ToString();
            Controls.Add(cardAmount);
            Paint += new PaintEventHandler((Object sender, PaintEventArgs args) => {
                cardAmount.Location = new Point(0, Height - 26);
                Height = Parent.Height - 3;
                Anchor = AnchorStyles.Top;

                cardAmount.Text = "x " + amount.ToString();
                cardAmount.TextAlign = ContentAlignment.TopRight;
                cardAmount.BackColor = Color.Transparent;
                cardAmount.ForeColor = Color.White;
            });
        }
    }
}

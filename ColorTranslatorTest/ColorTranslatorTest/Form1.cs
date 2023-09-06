using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTranslatorTest
{
    public partial class Form1 : Form
    {
        Color textColor = Color.Black;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color c;
            try
            {
                c = ColorTranslator.FromHtml(textBox1.Text);
            }
            catch (Exception)
            {
                c = Color.Empty;
            }
            textColor = c;
            textBox2.Text = c.ToString();
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font font2 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Rectangle rect2 = new Rectangle(10, 10, 200, 40);
                Rectangle rect3 = new Rectangle(210, 10, 410, 40);

                // Create a TextFormatFlags with word wrapping, horizontal center and
                // vertical center specified.
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                // Draw the text and the surrounding rectangle.
                TextRenderer.DrawText(e.Graphics, "RED", font2, rect2, Color.Red, flags);
                TextRenderer.DrawText(e.Graphics, "Hello, world!", font2, rect3, textColor, flags);
                e.Graphics.DrawRectangle(Pens.Black, rect2);
                e.Graphics.DrawRectangle(Pens.Black, rect3);
            }
        }
    }
}

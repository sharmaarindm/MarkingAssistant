using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asharma_MarkingAssistant
{
    public partial class thisForm : Form
    {
        bool loads = false;
        bool compiles = false;
        bool runs = false;


        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));


        public thisForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //Icon thisIcon = new Icon("C:\\Users\\Arigold\\Desktop\\UI Design\\asharma_MarkingAssistant\\asharma_MarkingAssistant\\titleICON.ico");
            //this.Icon = thisIcon;
            this.Invalidate();
        }



        private void mytabControler_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = mytabControler.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = mytabControler.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Tahoma", (float)16.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(loads)
            {
                button1.BackgroundImage = Properties.Resources._unchecked;
                loads = false;
            }
            else
            {
                loads = true;
                button1.BackgroundImage = Properties.Resources._checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (compiles)
            {
                button2.BackgroundImage = Properties.Resources._unchecked;
                compiles = false;
            }
            else
            {
                compiles = true;
                button2.BackgroundImage = Properties.Resources._checked;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (runs)
            {
                button3.BackgroundImage = Properties.Resources._unchecked;
                runs = false;
            }
            else
            {
                runs = true;
                button3.BackgroundImage = Properties.Resources._checked;
            }
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, 120, 400, 500, 400);
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            button13.BackgroundImage = Properties.Resources._checked;
            e.Graphics.DrawLine(pen, 120, 400, 500, 400);
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            button18.BackgroundImage = Properties.Resources._checked;
            button17.BackgroundImage = Properties.Resources._checked;
            e.Graphics.DrawLine(pen, 120, 400, 500, 400);
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            button22.BackgroundImage = Properties.Resources._checked;
            button23.BackgroundImage = Properties.Resources._checked;
            button21.BackgroundImage = Properties.Resources._checked;

            e.Graphics.DrawLine(pen, 120, 400, 500, 400);
        }

        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources._checked;
            button27.BackgroundImage = Properties.Resources._checked;
            button26.BackgroundImage = Properties.Resources._checked;
            button25.BackgroundImage = Properties.Resources._checked;
            e.Graphics.DrawLine(pen, 120, 400, 500, 400);
        }
    }
}

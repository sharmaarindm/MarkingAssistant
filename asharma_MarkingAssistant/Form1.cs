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

        int markingProgress;

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
            progressbarcontrol();
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
                _textBrush = new SolidBrush(Color.LightGreen);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Tahoma", (float)18.0, FontStyle.Bold, GraphicsUnit.Pixel);

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
          
        }

    

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage3;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage2;
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage4;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage5;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage2;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage3;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage4;
        }
        void progressbarcontrol()
        {
            if (mytabControler.SelectedTab == tabPage1)
            {
                progressBar1.Value = 20;
            }
            else if (mytabControler.SelectedTab == tabPage2)
            {
                progressBar2.Value = 40;
            }
            else if (mytabControler.SelectedTab == tabPage3)
            {
                progressBar3.Value = 60;
            }
            else if (mytabControler.SelectedTab == tabPage4)
            {
                progressBar4.Value = 80;
            }
            else if (mytabControler.SelectedTab == tabPage5)
            {
                progressBar5.Value = 100;
            }
        }

        private void mytabControler_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressbarcontrol();
        }
    }
}

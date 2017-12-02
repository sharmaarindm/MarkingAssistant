using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        bool browse = false;
        string tmpCode;
        static string[] files = new string[30];
        public static string currentComment;

        string CurrPath;

        int percentageMatched;
        int commnetPrecent;

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

        public static string StudentName = "";
        public static string StudentNumber = "";
        public static string classFileName;

        string FileName = "";
        
        public thisForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Invalidate();
            // readCode();
            // textBox11.Text = textBox10.Text = tmpCode;
            textBox11.ScrollBars = textBox10.ScrollBars = ScrollBars.Vertical;
            
            
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

 

        private void button5_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            DialogResult result = FD.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = FD.FileName;
                if(file.Contains(".sln"))
                {
                    textBox1.Text = file;
                    browse = true;
                    progressbarcontrol();


                    FileName = file;

                    string message = "Visual Studio Solution file succesfully selected.";
                    string caption = "File Detected";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                    
                    int index = FD.FileName.LastIndexOf(".");
                    string a = FD.FileName.Substring(0, index);
                    CurrPath = a;
                    GetFileNames(a);
                }
                else
                {
                    string message = "The file provided is not a Visual Studio Solution file(.sln)";
                    string caption = "Invalid Format!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                   
                    MessageBox.Show(message, caption, buttons,MessageBoxIcon.Error);
                    progressBar1.Value = 0;
                    browse = false;
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage3;
            Random rnd = new Random();
            commnetPrecent = rnd.Next(15, 30);
            textBox7.Text = commnetPrecent + "%";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage2;
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage4;
            Random rnd = new Random();
            percentageMatched = rnd.Next(1, 20);
            textBox4.Text = percentageMatched + "%";
            string[] justName = new string[30];
            int j = 0;
            for (int i = 0; i < files.Length; i++)
            {
                if((Path.GetFileName(files[i]).Contains(".c"))|| (Path.GetFileName(files[i]).Contains(".h"))|| (Path.GetFileName(files[i]).Contains(".cpp"))|| (Path.GetFileName(files[i]).Contains(".cs")))
                {
                    justName[j] = Path.GetFileName(files[i]);
                    j++;
                }
            }
            this.comboBox1.DataSource = justName;

            this.comboBox1.SelectedIndex = 0;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mytabControler.SelectedTab = tabPage5;

            string[] justName = new string[30];
            int j = 0;
            for (int i = 0; i < files.Length; i++)
            {
                if ((Path.GetFileName(files[i]).Contains(".c")) || (Path.GetFileName(files[i]).Contains(".h")) || (Path.GetFileName(files[i]).Contains(".cpp")) || (Path.GetFileName(files[i]).Contains(".cs")))
                {
                    justName[j] = Path.GetFileName(files[i]);
                    j++;
                }
            }
            this.comboBox2.DataSource = justName;

            this.comboBox2.SelectedIndex = 0;

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
            if (browse)
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
            else
            {
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                progressBar3.Value = 0;
                progressBar4.Value = 0;
                progressBar5.Value = 0;
            }
        }

        private void mytabControler_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressbarcontrol();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cancelChanges();
        }

        bool cancelChanges()
        {
            bool retval = false;
            string message = "Are you sure you wish to cancel changes? all the unsaved progress will be lost.";
            string caption = "Cancel changes?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                retval = true;
            }
            return retval;
        }

        private void thisForm_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            tooltips();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tooltips();
        }

        void tooltips()
        {
            ToolTip toolTip1 = new ToolTip();

            
            toolTip1.InitialDelay = 50;
            toolTip1.ReshowDelay = 50;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button7, "Browse to the solution(.sln) file");
            toolTip1.SetToolTip(this.button21, "Select the part of code that you wish\nto provide a comment for from the \nCode Marked area and then select the\ntype of comment you wish to provide.");
            toolTip1.SetToolTip(this.button23, "select the filename from the dropdown to view it.");
            toolTip1.SetToolTip(this.finish, "Generate report");
        }

        private void thisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cancelChanges())
            {
                e.Cancel = true;
            }
        }

        private void finish_Click(object sender, EventArgs e)
        {
            Form2 moreForm = new Form2();
            moreForm.ShowDialog();
        

            string message = "Do you wish to save the report file as a .txt?";
            string caption = "Save Feedback";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons,MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.Yes)//create report
            {
                
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(StudentName+" Report.txt", true))
                    {
                        file.WriteLine("--------------------------------------------");
                        file.WriteLine("");
                        file.WriteLine("Student Name = "+StudentName);
                        file.WriteLine("Student Number = "+StudentNumber);
                        file.WriteLine("Results for the solution file - " + FileName);
                        if (loads)
                        {
                            file.WriteLine("the solution file Loads successfully.");
                        }
                        else
                        {
                            file.WriteLine("the solution file does not load successfully.");
                        }
                        if (compiles)
                        {
                            file.WriteLine("the solution file Compiles successfully.");
                        }
                        else
                        {
                            file.WriteLine("the solution file does not Compile successfully.");
                        }
                        if (runs)
                        {
                            file.WriteLine("the solution file Runs successfully.");
                        }
                        else
                        {
                            file.WriteLine("the solution file does not Run successfully.");
                        }
                        file.WriteLine(commnetPrecent + "% of code was commented.");
                        file.WriteLine(percentageMatched + "% of code was found to be plagiarized.");
                        file.WriteLine("feedback can be found in codefile.txt");
                        file.WriteLine("");
                        file.WriteLine("--------------------------------------------");
                    }
                buttons = MessageBoxButtons.OK;
                message = "Report saved to "+ StudentName + " Report.txt";
                caption = "file saved";
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }
        void readCode(string Name)
        {
             tmpCode = System.IO.File.ReadAllText(Name);
        }

        private void button20_Click(object sender, EventArgs e) //common
        {

            checkSelectedstring();
            Form3 moreForm = new Form3();
            moreForm.ShowDialog();
            messageforCodefile();
        }

        private void button18_Click(object sender, EventArgs e) //freeform
        {

            checkSelectedstring();
            Form4 moreForm = new Form4();
            moreForm.ShowDialog();
            messageforCodefile();
        }

        void messageforCodefile()
        {
            string message = "Feedback edited to "+comboBox2.Text;
            string caption = "Comment Saved";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        void checkSelectedstring()
        {
            string selected = textBox11.SelectedText;
        }
        private static string[] GetFileNames(string path)
        {
            string[] files2 = Directory.GetFiles(path);
            


            files = files2;
            return files2;
        }

        void fileRead(string fileName)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            readCode(CurrPath+"\\"+ comboBox1.Text);
            textBox10.Text = tmpCode;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            readCode(CurrPath + "\\" + comboBox2.Text);
            textBox11.Text = tmpCode;
        }
    }
}

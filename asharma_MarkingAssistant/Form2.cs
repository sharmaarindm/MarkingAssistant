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
    public partial class Form2 : Form
    {
        string[] stuName = new string[10];
        string[] stuNum = new string[10];

        public Form2()
        {
            InitializeComponent();
            readfromFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thisForm.StudentName = this.comboBox1.Text;
            thisForm.StudentNumber = stuNum[this.comboBox1.SelectedIndex];
            this.Close();
        }

        void readfromFile()
        {
            //System.IO.StreamReader file = new System.IO.StreamReader(thisForm.classFileName);

            System.IO.StreamReader file = new System.IO.StreamReader(@"SETYear3.txt");
            string line;
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] arrstr = line.Split(',');

                stuName[i] = arrstr[0];
                stuNum[i] = arrstr[1];
                i++;
            }

            file.Close();

            this.comboBox1.DataSource = stuName;
        }
    }
}

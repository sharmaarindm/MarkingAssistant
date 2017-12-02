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
    public partial class Form3 : Form
    {
        string[] CommonCommnets = { "improper variable declaration" ,"unused variable found","invalid function call","use of global variables","camelcasing not found"};
        string selectedcomm;
        public Form3()
        {
            InitializeComponent();
            this.comboBox1.DataSource = CommonCommnets;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                selectedcomm = comboBox1.Text;
            }

            thisForm.currentComment = selectedcomm;
            this.Close();
        }
    }
}

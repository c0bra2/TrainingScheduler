using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrainingScheduler
{
    public partial class send : Form
    {
        public send()
        {
            InitializeComponent();
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                //send auto info only
                subjectTextBox.Text = "Auto Fee Policy, Skills Test Study Guide";
                messageTextBox.Text = File.ReadAllText("autoinfo.txt");
            }
        }

        private void send_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            radioButton1.Checked = true;
            subjectTextBox.Text = "CDL Fee Policy, Memory Aid, Directions to Lot";
            messageTextBox.Text = File.ReadAllText("cdlinfo.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                //send auto info only
                subjectTextBox.Text = "Auto Fee Policy, Skills Test Study Guide";
                messageTextBox.Text = File.ReadAllText("autoinfo.txt");
            }
            else
            {
                //send confirmation and info
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingScheduler
{
    public partial class Form1 : Form
    {
        private List<Schedule> customerSchedule = new List<Schedule>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            /*// make it readonly
            //trainerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            testerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vehicalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            timeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;*/

            // trainercombo options
            trainerComboBox.Items.Add("Chris Humphrey");
            trainerComboBox.Items.Add("Patrick Humphrey");
            trainerComboBox.Items.Add("Ed Humphrey");
            trainerComboBox.Text = "Chris Humphrey";

            // testercombo options
            testerComboBox.Items.Add("Chris Humphrey");
            testerComboBox.Items.Add("Patrick Humphrey");
            testerComboBox.Items.Add("Ed Humphrey");
            testerComboBox.Text = "Patrick Humphrey";

            // vehicalcombo options
            vehicalComboBox.Items.Add("Semi Rental");
            vehicalComboBox.Items.Add("Truck Rental");
            vehicalComboBox.Items.Add("Customer Truck");
            vehicalComboBox.Text = "Semi Rental";

            // cdlcombo options
            cdlComboBox.Items.Add("A");
            cdlComboBox.Items.Add("B");
            cdlComboBox.Items.Add("BP");
            cdlComboBox.Items.Add("BPS");
            cdlComboBox.Items.Add("C");
            cdlComboBox.Text = "A";

            // brakecombo options
            brakeComboBox.Items.Add("Full Hydrolic");
            brakeComboBox.Items.Add("Partial Air");
            brakeComboBox.Items.Add("Full Air");
            brakeComboBox.Text = "Full Air";

            // transcombo options
            transComboBox.Items.Add("Manual");
            transComboBox.Items.Add("Automatic");
            transComboBox.Text = "Manual";

            // timescombo options
            timeComboBox.Items.Add("8:00AM");
            timeComboBox.Items.Add("9:00AM");
            timeComboBox.Items.Add("10:00AM");
            timeComboBox.Items.Add("11:00AM");
            timeComboBox.Items.Add("12:00PM");
            timeComboBox.Items.Add("1:00PM");
            timeComboBox.Items.Add("12:00PM");
            timeComboBox.Items.Add("2:00PM");
            timeComboBox.Items.Add("3:00PM");
            timeComboBox.Items.Add("4:00PM");
            timeComboBox.Items.Add("5:00PM");
            timeComboBox.Items.Add("6:00PM");
            timeComboBox.Items.Add("7:00PM");
            timeComboBox.Text = "9:00AM";

            // tenativecombo options
            tenativeComboBox.Items.Add("Yes");
            tenativeComboBox.Items.Add("No");
            tenativeComboBox.Text = "No";

            // lengthcombo options
            lengthComboBox.Items.Add("1hr");
            lengthComboBox.Items.Add("2hr");
            lengthComboBox.Items.Add("3hr");
            lengthComboBox.Items.Add("4hr");
            lengthComboBox.Items.Add("5hr");
            lengthComboBox.Items.Add("6hr");
            lengthComboBox.Items.Add("7hr");
            lengthComboBox.Items.Add("8hr");
            lengthComboBox.Text = "4hr";

            // lengthcombo options
            idComboBox.Items.Add("1");
            idComboBox.Text = "1";
        }


        /*ADD Training TO SCHEDULE BUTTON*/
        private void button2_Click(object sender, EventArgs e)
        {
            //firstTextBox.Text = dateTimePicker1.Value.ToShortDateString();

            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.setRate(dObj.vehical);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            sObj.tentative = tenativeComboBox.Text;
            sObj.setHours(lengthComboBox.Text);
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }
            //print training in box
            printTrainingToBox(customerSchedule);
        }

        private void printTrainingToBox(List<Schedule> s)
        {
            int total = 0;
            richTextBox1.Clear();
            //print training header
            richTextBox1.AppendText("Training\nID\tDate\tTime\n");
            //print data for each training session
            for (int i = 0; i < customerSchedule.Count; i++)
            {
                richTextBox1.AppendText(s[i].id + "\t" + s[i].date + "\t" + s[i].time + "\t");
                if (s[i].tentative == "Yes")
                {
                    richTextBox1.AppendText("(Tenative)\n");
                }
                else
                {
                    richTextBox1.AppendText("\n");
                }
                total += s[i].hoursTrained * s[i].customer.trainingRate;
            }
            richTextBox1.AppendText("Total: $" + total);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.Select();
            SendKeys.Send("%{DOWN}");
        }
    }
}

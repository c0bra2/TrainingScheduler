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
            lengthComboBox.Items.Add("1hrs");
            lengthComboBox.Items.Add("2hrs");
            lengthComboBox.Items.Add("3hrs");
            lengthComboBox.Items.Add("4hrs");
            lengthComboBox.Items.Add("5hrs");
            lengthComboBox.Items.Add("6hrs");
            lengthComboBox.Items.Add("7hrs");
            lengthComboBox.Items.Add("8hrs");
            lengthComboBox.Text = "4hrs";

            // lengthcombo options
            idComboBox.Items.Add("1");
            idComboBox.Text = "1";
        }


        /*ADD Training TO SCHEDULE BUTTON*/
        private void button2_Click(object sender, EventArgs e)
        {
            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.cdl = cdlComboBox.Text;
            dObj.setRate(dObj.vehical);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            sObj.tentative = tenativeComboBox.Text;
            sObj.setHours(lengthComboBox.Text);
            sObj.type = "train";
            idComboBox.Items.Add((Int32.Parse(idComboBox.Text) + 1).ToString());
            idComboBox.Text = (Int32.Parse(idComboBox.Text) + 1).ToString();
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }
            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        //test button clicked
        private void button5_Click(object sender, EventArgs e)
        {
            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.cdl = cdlComboBox.Text;
            dObj.setRate(dObj.vehical);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            sObj.tentative = tenativeComboBox.Text;
            sObj.setHours("3hrs");
            sObj.type = "test";
            idComboBox.Items.Add((Int32.Parse(idComboBox.Text) + 1).ToString());
            idComboBox.Text = (Int32.Parse(idComboBox.Text) + 1).ToString();
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }
            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        //RUNS WHEN REMOVE ID BUTTON CLICKED
        private void button1_Click(object sender, EventArgs e)
        {
            //remove the item of specified ID
            int removeIndex = 0;
            int largest = 0;
            for (int i = 0; i < customerSchedule.Count; i++){
                if (customerSchedule[i].id == idComboBox.Text){
                    removeIndex = i;
                }
            }
            customerSchedule.RemoveAt(removeIndex);

            //remove id number from combobox
            for (int i = 0; i < idComboBox.Items.Count; i++)
            {
                if (idComboBox.GetItemText(idComboBox.Items[i]) == idComboBox.Text)
                {
                    removeIndex = i;
                }
            }
            idComboBox.Items.RemoveAt(removeIndex);

            for (int i = 0; i < idComboBox.Items.Count; i++)
            {
                if (Int32.Parse(idComboBox.GetItemText(idComboBox.Items[i])) > largest)
                {
                    largest = Int32.Parse(idComboBox.GetItemText(idComboBox.Items[i]));
                }
            }

            //new ID to set in idcombobox
            idComboBox.Items.Add(largest.ToString());
            idComboBox.Text = largest.ToString();

            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        private void printTestingToBox(List<Schedule> s){
            bool testDate = false;
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].type == "test")
                {
                    testDate = true;
                }
            }
            if (!testDate)
            {
                return;
            }
            else{
            int total = 0;
            //print testing header
            richTextBox1.AppendText("\n\n\nTesting\n" + padString("ID", 5)  + padString("Date",20) + padString("Time",15) + "\n");
            //print data for each testing session
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].type == "test")
                {
                    richTextBox1.AppendText(padString(s[i].id, 6) +
                        padString(s[i].date, 15) + padString(s[i].time, 12));
                    if (s[i].customer.tester == "Chris Humphrey")
                    {
                        richTextBox1.AppendText("w/Chris ");
                    }
                    else if (s[i].customer.tester == "Patrick Humphrey")
                    {
                        richTextBox1.AppendText("w/Pat ");
                    }
                    else if (s[i].customer.tester == "Ed Humphrey")
                    {
                        richTextBox1.AppendText("w/Ed ");
                    }
                    if (s[i].tentative == "Yes")
                    {
                        richTextBox1.AppendText(padString("(T)\n", 0));
                    }
                    else
                    {
                        richTextBox1.AppendText("\n");
                    }
                    total += s[i].hoursTrained * s[i].customer.trainingRate;
                }
            }
            richTextBox1.AppendText("Testing Cost: $" + total);
            }
        }

        private void printTrainingToBox(List<Schedule> s)
        {
            int total = 0;
            richTextBox1.Clear();
            //print training header
            richTextBox1.AppendText("Training\n" + padString("ID", 5) + 
                padString("Length", 11) + padString("Date",20) + padString("Time",15) + "\n");
            //print data for each training session
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].type == "train")
                {
                    richTextBox1.AppendText(padString(s[i].id, 6) + padString(s[i].hours, 14) +
                        padString(s[i].date, 15) + padString(s[i].time, 12));
                    if (s[i].customer.trainer == "Chris Humphrey")
                    {
                        richTextBox1.AppendText("w/Chris ");
                    }
                    else if (s[i].customer.trainer == "Patrick Humphrey")
                    {
                        richTextBox1.AppendText("w/Pat ");
                    }
                    else if (s[i].customer.trainer == "Ed Humphrey")
                    {
                        richTextBox1.AppendText("w/Ed ");
                    }
                    if (s[i].tentative == "Yes")
                    {
                        richTextBox1.AppendText(padString("(T)\n", 0));
                    }
                    else
                    {
                        richTextBox1.AppendText("\n");
                    }
                    total += s[i].hoursTrained * s[i].customer.trainingRate;
                }
            }
            richTextBox1.AppendText("Training Cost: $" + total);
        }

        public string padString(string s, int p){
            int count = 0;
            for (int i = 0; i < s.Length; i++){
                count++;
            }
            p -= count;
            for (;p > 0; p--){
                s += " ";
            }
            return s;
        }

        /// <summary>
        /// Print Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int totalHours = 0;
            string filename;
            string output = "";
            Driver customer = customerSchedule[0].customer;
            filename = "Humphrey's" + ".txt";

            //define output string
            output += "\r\n\r\n";
            output += "Customer: " + customer.first_name + " " + customer.last_name + "\r\n";
            output += "CDL Lot: 110 S. Delaney Rd. Owosso MI, 48867\r\n";
            output += "Vehical: " + customer.vehical + ", w/" + customer.trans + " " + customer.brakes + "\r\n";
            output += "Class: " + "CDL-" + customer.cdl + "\r\n";
            output += "Training Rate $" + customer.trainingRate + "/hr\r\n";
            output += "Testing Rate $" + customer.testingRate + "\r\n";
            output += "\r\n\r\n";
            output += "Training Schedule\r\n" + padString("Date", 19) + padString("Time", 14) + padString("Length", 17) + padString("Trainer",10) + "\r\n";
            for (int i = 0; i < 65; i++)
            {
                output += "-";
            }
            output += "\r\n";
            for (int i = 0; i < customerSchedule.Count; i++)
            {
                if (customerSchedule[i].type == "train")
                {
                    output += padString(customerSchedule[i].date, 19) + padString(customerSchedule[i].time, 14) + padString(customerSchedule[i].hours, 17) + padString(customerSchedule[i].customer.trainer, 20);
                    if (customerSchedule[i].tentative == "Yes")
                    {
                        output += "(Tenative)\r\n";
                    }
                    output += "\r\n";
                    totalHours += customerSchedule[i].hoursTrained;
                }
            }

            output += "\r\n\r\n\r\n\r\n\r\n";
            output += "Testing Schedule\r\n" + padString("Date", 19) + padString("Time", 14) + padString("Length", 17) + padString("Trainer", 10) + "\r\n";
            for (int i = 0; i < 65; i++)
            {
                output += "-";
            }
            output += "\r\n";
            for (int i = 0; i < customerSchedule.Count; i++)
            {
                if (customerSchedule[i].type == "test")
                {
                    output += padString(customerSchedule[i].date, 19) + padString(customerSchedule[i].time, 14) + padString(customerSchedule[i].hours, 17) + padString(customerSchedule[i].customer.tester, 20);
                    if (customerSchedule[i].tentative == "Yes")
                    {
                        output += "(Tenative)\r\n";
                    }
                    output += "\r\n";
                }
            }

            output += "\r\n\r\n\r\n\r\n\r\n\r\n";
            output += "Summary (Totals subject to change if deviating from this outline)\r\n";
            for (int i = 0; i < 65; i++)
            {
                output += "-";
            }
            output += "\r\n";
            output += "Training (" + totalHours + "hrs * $" + customer.trainingRate + "/hr) = $" + totalHours * customer.trainingRate + "\r\n";
            output += "Test = $" + customer.testingRate + "\r\n\r\n";
            output += "Grand Total = $" + ((totalHours * customer.trainingRate) + customer.testingRate);

            System.IO.File.WriteAllText(filename, output);
            System.Diagnostics.Process.Start(filename);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear customerSchedule
            customerSchedule = new List<Schedule>();



            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }
    }
}

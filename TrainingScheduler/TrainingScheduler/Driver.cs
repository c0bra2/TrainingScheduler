using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScheduler
{
    class Driver
    {
        public string first_name;
        public string last_name;
        public string trainer;
        public string tester;
        public string cdl;
        public string vehical;
        public string trans;
        public string brakes;
        public int trainingRate;
        public int testingRate;

        public string restrictions(bool html)
        {
            List<string> res = new List<string>();
            string outstring = "";
            if (trans == "Automatic")
            {
                res.Add("No Manual");
            }
            if (brakes == "Hydraulic" || brakes == "Partial Air")
            {
                res.Add("No Full Air Brakes");
            }
            if (vehical == "Customer Truck: Pintle Hitch")
            {
                res.Add("No Fifth Wheel");
            }
            if (vehical == "Truck Rental")
            {
                res.Add("No Fifth Wheel");
            }
            if (res.Count == 0)
            {
                return "";
            }
            outstring += "Restrictions: ";
            for (int i = 0; i < res.Count; i++)
            {
                if (i + 1 != res.Count)
                {
                    //not last value in list
                    outstring += res[i] + ", ";
                }
                else
                {
                    outstring += res[i];
                }
            }
            if (html)
            {
                return outstring + "<br/>";
            }
            else
            {
                return outstring + "\r\n";
            }
        }

        public void setRate(string v)
        {
            if (v == "Semi Rental")
            {
                trainingRate = 150;
                testingRate = 450;
            }
            else if (v == "Truck Rental")
            {
                trainingRate = 150;
                testingRate = 400;
            }
            else 
            {
                trainingRate = 75;
                testingRate = 200;
            }
        }
    }
}

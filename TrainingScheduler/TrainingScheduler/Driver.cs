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

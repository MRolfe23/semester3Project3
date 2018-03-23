using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project3
{
    public abstract class residenceClass : Dunwoody
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int dorm { get; set; }
        public int floor { get; set; }
        public string residentType { get; set; }
        public double hoursWorked { get; set; }
        public double rent { get; set; }


        public residenceClass()
        {

        }
        public residenceClass(string id, string fname, string lname, int dorm, int floor, string residentType, double hoursWorked, double rent)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.dorm = dorm;
            this.floor = floor;
            this.residentType = residentType;
            this.hoursWorked = hoursWorked;
            this.rent = rent;
        }

        public abstract void scholarship(string residentType, double hoursWorked, double rent);
        public abstract void athlete(string residentType, double hoursWorked, double rent);
        public abstract void worker(string residentType, double hoursWorked, double rent);
    }
}
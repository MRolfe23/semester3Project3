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
    class workerTypeClass : residenceClass
    {
        public workerTypeClass(string residentType, double hoursWorked, double rent)
        {
            this.residentType = residentType;
            this.hoursWorked = hoursWorked;
            this.rent = rent;
        }

        public override void athlete(string residentType, double hoursWorked, double rent)
        {
            throw new NotImplementedException();
        }

        public override void scholarship(string residentType, double hoursWorked, double rent)
        {
            throw new NotImplementedException();
        }

        public override void worker(string residentType, double hoursWorked, double rent)
        {
            double WORKER = 1245.00;

            this.residentType = residentType;
            this.hoursWorked = hoursWorked;
            this.rent = rent;
            
            rent = WORKER - (hoursWorked * 14);
        }
    }
}

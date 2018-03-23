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
    class scholarshipTypeClass : residenceClass
    {
        public scholarshipTypeClass(string residentType, double hoursWorked, double rent)
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
            double SCHOLARSHIP = 100.00;;

            this.residentType = residentType;
            this.hoursWorked = hoursWorked;
            this.rent = rent;

            rent = SCHOLARSHIP;
        }

        public override void worker(string residentType, double hoursWorked, double rent)
        {
            throw new NotImplementedException();
        }
    }
}

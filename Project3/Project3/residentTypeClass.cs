using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class residentTypeClass : residenceClass
    {
        public string type { get; set; }

        public selectType(string type)
        {
            this.type = type;
        }

        public static pickWhichType()
        {
            if (workerSelection.Checked)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentType", "Worker");
                cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                cmd.Parameters.AddWithValue("@MonthlyRent", WORKER - (Convert.ToInt32(newHoursWorkInput.Text) * 14));
            }
            else if (athleteSelection.Checked)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentType", "Athlete");
                cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                cmd.Parameters.AddWithValue("@MonthlyRent", ATHELETE);
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResidentType", "Scholorship");
                cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                cmd.Parameters.AddWithValue("@MonthlyRent", SCHOLARSHIP);
            }
        }
    }
}

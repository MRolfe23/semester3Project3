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
    public partial class Dunwoody : Form
    {
        // class variables

        string id;
        string fname;
        string lname;
        int dorm;
        int floor;
        string residentType;
        double hoursWorked;
        double rent;

        //global variables

        private const double SCHOLARSHIP = 100.00;
        private const double ATHELETE = 1200.00;
        private const double WORKER = 1245.00;
        private const string RD_USERNAME = "home";
        private const string RD_PASSWORD = "1234";
        string user = "";
        string pass = "";

        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dunwoodyResidenceHall;Integrated Security=True;Connect Timeout=30";
        string Query;
        DataTable datatable;
        SqlDataAdapter sqladapter;

        public Dunwoody()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dunwoodyResidenceHallDataSet1.dunwoodyResidence' table. You can move, or remove it, as needed.
            if (user != RD_USERNAME && pass != RD_PASSWORD )
            {
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 1], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 2], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 3], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 4], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 0], true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 2], true);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }

        private void RDSignInbutton_Click(object sender, EventArgs e)
        {

            user = userName.Text;
            pass = passWord.Text;

            if (user == RD_USERNAME && pass == RD_PASSWORD)
            {
                signInStatus.Text = "Successful login";
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 1], true);
                userName.Text = "";
                passWord.Text = "";
                // TODO: This line of code loads data into the 'dunwoodyResidenceHallDataSet.dunwoodyResidence' table. You can move, or remove it, as needed.
                this.dunwoodyResidenceTableAdapter.Fill(this.dunwoodyResidenceHallDataSet.dunwoodyResidence);
                //form load event here data will show in the data gridview

                sqlconnection = new SqlConnection(ConnectionString);
                Query = "select * from dunwoodyResidence";
                sqlcommand = new SqlCommand(Query, sqlconnection);
                sqladapter = new SqlDataAdapter();
                datatable = new DataTable();
                sqladapter.SelectCommand = sqlcommand;
                sqladapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else
            {
                signInStatus.Text = "Username or password is incorrect";
            }
        }

        private void submitNewResidentButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dunwoodyResidenceHall;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("sp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", newFirstNameInput.Text);
                cmd.Parameters.AddWithValue("@LastName", newLastNameInput.Text);
                cmd.Parameters.AddWithValue("@DormNumber", Convert.ToInt32(newDormInput.Text));
                cmd.Parameters.AddWithValue("@FloorNumber", Convert.ToInt32(newFloorInput.Text));
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(newIDInput.Text));
                if (workerSelection.Checked)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentType", "Worker");
                    cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                    cmd.Parameters.AddWithValue("@MonthlyRent", WORKER - (Convert.ToInt32(newHoursWorkInput.Text) * 14));
                    residentType = "Worker";
                    hoursWorked = Convert.ToInt32(newHoursWorkInput.Text);
                    residenceClass worker = new workerTypeClass(residentType, hoursWorked, rent);
                    label9.Text = "child class info: " + worker;
                }
                else if (athleteSelection.Checked)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentType", "Athlete");
                    cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                    cmd.Parameters.AddWithValue("@MonthlyRent", ATHELETE);
                    residentType = "Athlete";
                    hoursWorked = Convert.ToInt32(newHoursWorkInput.Text);
                    residenceClass sports = new AthleteTypeClass(residentType, hoursWorked, rent);
                    label9.Text = "child class info: " + sports;
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentType", "Scholorship");
                    cmd.Parameters.AddWithValue("@HoursWorked", Convert.ToInt32(newHoursWorkInput.Text));
                    cmd.Parameters.AddWithValue("@MonthlyRent", SCHOLARSHIP);
                    residentType = "Scholorship";
                    hoursWorked = Convert.ToInt32(newHoursWorkInput.Text);
                    residenceClass smart = new scholarshipTypeClass(residentType, hoursWorked, rent);
                    label9.Text = "child class info: " + smart;
                }



                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("Data Saved");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid data entry");
            }
        }

        private void residenceIDSearch_TextChanged(object sender, EventArgs e)
        {
            //textchanged event of texbox when user enter a word in the textbox then through this dataview object string format it will filter and attached the filter result in to the datagridview

            DataView DV = new DataView(datatable);
            DV.RowFilter = string.Format("Id LIKE '%{0}%'", residenceIDSearch.Text);
            dataGridView1.DataSource = DV;
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }
        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        private void searchSelection_Click(object sender, EventArgs e)
        {
            EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 3], true);
        }

        private void back2Selection_Click(object sender, EventArgs e)
        {
            EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 1], true);
        }

        private void passWord_TextChanged(object sender, EventArgs e)
        {
            passWord.PasswordChar = '*';
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            if (user == RD_USERNAME && pass == RD_PASSWORD)
            {
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 1], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 2], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 3], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 4], false);
                EnableTab(tabControler1.TabPages[tabControler1.SelectedIndex = 0], true);

                signInStatus.Text = "Successfully logged out";
            }
        }
    }
}

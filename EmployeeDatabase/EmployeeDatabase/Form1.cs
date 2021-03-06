using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        DatabaseConnection objConnect;
        string conString;
        
        DataSet ds;
        DataRow dRow;

        int MaxRows;
        int inc = 0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DatabaseConnection();
                conString = Properties.Settings.Default.EmployeesConnectionString;
                
                objConnect.connection_string = conString;

                objConnect.Sql = Properties.Settings.Default.SQL;

                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;
                
                NavigateRecords();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc];
            txtFirstName.Text = dRow.ItemArray.GetValue(1).ToString();
            txtLastName.Text = dRow.ItemArray.GetValue(2).ToString();
            txtJobTitle.Text = dRow.ItemArray.GetValue(3).ToString();
            txtDepartment.Text = dRow.ItemArray.GetValue(4).ToString();
        }
    }
}

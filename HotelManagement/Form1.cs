using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            query = "select username, pass from employee where username = '" + txtUsername.Text +"' and pass = '" + txtPassword.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                textError.Visible = false;
                DashBoard db = new DashBoard();
                this.Hide();
                db.Show();
            } else
            {
                textError.Visible=true;
                txtPassword.Clear();
            }
        }
    }
}

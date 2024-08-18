using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.AllUserControl
{
    public partial class UC_Staff : UserControl
    {
        function fn = new function();
        String query;
        public UC_Staff()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {
            getMaxID();
        }
        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows [0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPhoneNumber.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 num = Int64.Parse(txtPhoneNumber.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String userName = txtUserName.Text;
                String password = txtPassword.Text;

                query = "insert into employee(ename, mobile, gender, emailid, username, pass) values ('"+ name +"', '"+ num +"', '"+ gender +"', '"+ email +"', '" + userName + "', '" + password + "')";
                fn.setData(query, "Register successfully!");

                clearAll();
                getMaxID();
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void tabStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabStaff.SelectedIndex == 1)
            {
                setStaff(guna2DataGridView1);
            }
            else if (tabStaff.SelectedIndex == 2)
            {
                setStaff(guna2DataGridView2);
            }
        }
        public void setStaff(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtID.Text + "";
                    fn.setData(query, "Staff Information is deleted");
                    tabStaff_SelectedIndexChanged(this, null);   
                }
            }
        }

        private void UC_Staff_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}

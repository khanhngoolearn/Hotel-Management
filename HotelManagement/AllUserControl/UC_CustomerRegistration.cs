using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.AllUserControl
{
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }
        public void setComboBox(String query, ComboBox com)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    com.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNumber.Items.Clear();
            txtPrice.Clear();
            UpdateRoomNumberAndPrice();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNumber.Items.Clear();
            query = "select roomNo from rooms where bed = '" + txtBed.Text + "' and roomType = '" + txtRoomType + "' and booked = 'NO'";
            setComboBox(query, txtRoomNumber);
            UpdateRoomNumberAndPrice();
        }
        int rid;
        private void txtRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select roomid, price from rooms where roomNo = '" + txtRoomNumber.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rid = int.Parse(ds.Tables[0].Rows[0]["roomid"].ToString());
                txtPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            }
            else
            {
                MessageBox.Show("Room not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAllot_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhoneNumber.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDoB.Text != "" && txtIDProof.Text != "" && txtAddress.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                string name = txtName.Text;
                Int64 phoneN = int.Parse(txtPhoneNumber.Text);
                string nationality = txtNationality.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string checkIn = txtCheckIn.Text;
                string idProof = txtIDProof.Text;
                string dob = txtDoB.Text;

                query = "insert into customer (cname, mobile, nationality, gender,dob, idproof,address, checkin, roomid) values ('" + name +"','" + phoneN + "', '" + nationality + "', '" + gender +"', '" + dob + "', '" + idProof +"', '" + address + "', '" + checkIn + "', '" + rid + "'); update rooms set booked = 'YES' where roomNo = '" + txtRoomNumber + "'";
                fn.setData(query, "Room " + txtRoomNumber + " signs up successfully!!");
                clearAll();
            } else
            {
                MessageBox.Show("Please enter information completely!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateRoomNumberAndPrice()
        {
            if (txtBed.SelectedIndex != -1 && txtRoomType.SelectedIndex != -1)
            {
                query = "SELECT roomNo, price FROM rooms WHERE bed = '" + txtBed.Text + "' AND roomType = '" + txtRoomType.Text + "' AND booked = 'NO'";
                DataSet ds = fn.getData(query);

                txtRoomNumber.Items.Clear();
                txtPrice.Clear();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        txtRoomNumber.Items.Add(row["roomNo"].ToString());
                        txtPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No available rooms for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                txtRoomNumber.Items.Clear();
                txtPrice.Clear();
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDoB.ResetText();
            txtIDProof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoomType.SelectedIndex = -1;
            txtRoomNumber.Items.Clear();
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}

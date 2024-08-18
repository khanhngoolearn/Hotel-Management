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
    public partial class UC_NewRoom : UserControl
    {
        public UC_NewRoom()
        {
            InitializeComponent();
        }
        function fn = new function();
        String query;

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNumber.Text;
                String type = txtRoomType.Text;
                String bed = txtBed.Text;
                String price = txtPrice.Text;
                query = "insert into rooms(roomNo, roomType, bed, price) values ('" + roomno + "', '" + type + "', '" + bed + "', '" + price + "')";
                fn.setData(query, "Room Added");

                UC_NewRoom_Load(this, null);
                clearAll();
            } else
            {
                MessageBox.Show("Please complete information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtRoomNumber.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_NewRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_NewRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_NewRoom_Enter(object sender, EventArgs e)
        {
            UC_NewRoom_Load(this, null );
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

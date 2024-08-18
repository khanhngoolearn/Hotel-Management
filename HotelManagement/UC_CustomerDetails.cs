using System;
using System.Collections;
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
    public partial class UC_CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchCus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchCus.SelectedIndex == 0)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price " +
                "FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid";
                getRecord(query);
            } else if (txtSearchCus.SelectedIndex == 1)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price " +
                    "FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE customer.checkout is null";
                getRecord(query);
            } else if (txtSearchCus.SelectedIndex == 2)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price " +
                    "FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE customer.checkout is not null";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_CustomerDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

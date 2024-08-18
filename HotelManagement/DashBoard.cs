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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            uC_NewRoom1.Visible=false;
            btnNewRoom.PerformClick();
            uC_CustomerRegistration1.Visible=false;
            uC_CheckOut1.Visible=false;
            uC_CustomerDetails1.Visible=false;
            uC_Staff1.Visible=false;
        }

        private void btnExitDashBoard_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horizontalScorll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            horizontalScorll.Left = btnNewRoom.Left + 40;
            uC_NewRoom1.Visible = true;
            uC_NewRoom1.BringToFront();
        }

        private void uC_NewRoom1_Load(object sender, EventArgs e)
        {

        }

        private void uC_CustomerRegistration1_Load(object sender, EventArgs e)
        {

        }

        private void btnCusRegist_Click(object sender, EventArgs e)
        {
            horizontalScorll.Left = btnCusRegist.Left + 40;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void uC_CustomerRegistration1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            horizontalScorll.Left = btnCheckOut.Left + 40;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();

        }

        private void btnCustDetails_Click(object sender, EventArgs e)
        {
            horizontalScorll.Left = btnCustDetails.Left + 40;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            horizontalScorll.Left = btnStaff.Left + 40;
            uC_Staff1.Visible = true;
            uC_Staff1.BringToFront();
        }
    }
}

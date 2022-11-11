using System;
using System.Windows.Forms;

namespace Smartphone_Management.GUI.KhachHang
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            txtMKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        private void bThem_Click(object sender, EventArgs e)
        {
            bSua.Enabled = false;
            bXoa.Enabled = false;
            bThem.Enabled = false;
            ResetValues();
            txtMKH.Enabled = true;
            txtMKH.Focus();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

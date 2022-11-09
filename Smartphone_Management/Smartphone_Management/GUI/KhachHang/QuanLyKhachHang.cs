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
            bBoQua.Enabled = true;
            bLuu.Enabled = true;
            bThem.Enabled = false;
            ResetValues();
            txtMKH.Enabled = true;
            txtMKH.Focus();
        }

    }
}

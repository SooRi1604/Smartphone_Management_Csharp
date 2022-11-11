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

        private void DSKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String makh = (String)DSKhachHang.CurrentRow.Cells[4].Value;
            String tenkh = (String)DSKhachHang.CurrentRow.Cells[5].Value;
            String cmnd = (String)DSKhachHang.CurrentRow.Cells[5].Value;
            DateTime ngaydat = (DateTime)DSKhachHang.CurrentRow.Cells[3].Value;
            String trangthai = cbbTrangThai.SelectedItem.ToString();
            //DateTime date = (DateTime)value;
            int madh = int.Parse(value);
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                openDetailForm(makh, tenkh, cmnd, trangthai);

            }
        }
    }
}

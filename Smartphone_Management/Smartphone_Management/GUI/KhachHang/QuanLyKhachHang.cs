using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using Smartphone_Management.BUS;
using Smartphone_Management.DAO;

namespace Smartphone_Management.GUI.KhachHang
{
    public partial class QuanLyKhachHang : Form
    {
        DataTable data = new DataTable();
        QuanLyKhachHang_BUS qlkh_bus = new QuanLyKhachHang_BUS();
        public QuanLyKhachHang()
        {
            InitializeComponent();
            

        }
      
        private void bThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }

        private void QuanLyDonHang_Load(object sender, EventArgs e)
        {
            //data = new DataTable();
            init();

            DSKhachHang.DataSource = data;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DSKhachHang.Rows[i].Cells[2].Value = i + 1;
            }
        }
        private void DSKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            

        }
        public void init()
        {
            ConnectToMySQL conn = new ConnectToMySQL();
            data = qlkh_bus.getThongTinKhachHang(txtMaKH);
            DSKhachHang.DataSource = data;

        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smartphone_Management.DAO
{
    internal class QuanLyKhachHang_DAO
    {
        ConnectToMySQL sqla = new ConnectToMySQL();
        internal DataTable getThongTinKhachHang_DAO(int makh)
        {
            DataTable data = new DataTable();

            string query = "select khachhang.Makh,khachhang.Tenkh, khachhang.Cmnd,khachhang.SDT,khachhang.Diachi,khachhang.Emai,khachhang.Ngaytao,khachhang.Diemso, khachhang.Trangthai";

            MySqlCommand MyCommand2 = new MySqlCommand(query, sqla.getConnection());
            MyCommand2.Parameters.AddWithValue("@Makh",makh);
            //  MyConn2.Open();
            //For offline connection we weill use  MySqlDataAdapter class.
            if (MyCommand2 == null)
            {
                return null;
            }
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            MyAdapter.Fill(data);
            //MessageBox.Show("Completed");
            sqla.getConnection().Close();

            return data;

        }

        
        internal void updateTrangThaiKhachHang(int makh)
        {

            try
            {
                sqla.getConnection().Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE khachhang SET Trangthai = \"Hoàn Thành\"\r WHERE khachhang.Makh=@Makh", sqla.getConnection());
                cmd.Parameters.AddWithValue("@Makh", makh);
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Successfully Updated", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            sqla.getConnection().Close();

        }

        internal void updateTrangThaiKhachHangHuy(int makh)
        {

            try
            {
                sqla.getConnection().Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE khachhang SET Trangthai = \"Đã Hủy\"\r WHERE khachhang.Makh=@Makh", sqla.getConnection());
                cmd.Parameters.AddWithValue("@Madh", makh);
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Successfully deleted", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            sqla.getConnection().Close();
        }
    }
}

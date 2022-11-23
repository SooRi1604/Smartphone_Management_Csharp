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
using DocumentFormat.OpenXml.Office.Word;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smartphone_Management.DAO
{
    internal class QuanLyKhachHang_DAO
    {
        ConnectToMySQL sqla = new ConnectToMySQL();
        internal void addKhachHang(int Makh, string Tenkh, String Cmnd, String SDT, String Diachi, String Email, DateTime Ngaytao, int Diemso)
        {
            ConnectToMySQL conn = new ConnectToMySQL();
            try
            {
                conn.getConnection().Open();
                String query = "insert into khachhang(Makh,Tenkh,Cmnd,SDT,Diachi,Email,Ngaytao,Diemso ) values(@makh,@tenkh,@cmnd,@sdt,@diachi,@email,@ngaytao,@diemso)";

                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                cmd.Parameters.AddWithValue("@makh", Makh);
                cmd.Parameters.AddWithValue("@ten", Tenkh);
                cmd.Parameters.AddWithValue("@cmnd", Cmnd);
                cmd.Parameters.AddWithValue("@sdt", SDT);
                cmd.Parameters.AddWithValue("@diachi", Diachi);
                cmd.Parameters.AddWithValue("@ngaytao", Ngaytao);
                cmd.Parameters.AddWithValue("@diemso", Diemso);


                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Successfully added", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.getConnection().Close();
        }


        public void deletekh(int Makh)
        {
            try
            {

                ConnectToMySQL conn = new ConnectToMySQL();
                conn.getConnection().Open();

                String Query = "delete from smartphonemanagement.khachhang where khachhang.Makh=@makh";
                MySqlCommand cmd = new MySqlCommand(Query, conn.getConnection());
                cmd.Parameters.AddWithValue("@manv", Makh);

                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                conn.getConnection().Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void updateKH(int Makh, string Tenkh, String Cmnd, String SDT, String Diachi, String Email, DateTime Ngaytao, int Diemso)
        {
            ConnectToMySQL conn = new ConnectToMySQL();
            try
            {
                conn.getConnection().Open();
                String query = "update khachhang set Makh=@makh, Tenkh=@ten, Cmnd=@cmnd, SDT=@sdt, Diachi=@diachi, Ngaytao=@ngaytao, Diemso=@diemso ";

                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                cmd.Parameters.AddWithValue("@makh", Makh);
                cmd.Parameters.AddWithValue("@ten", Tenkh);
                cmd.Parameters.AddWithValue("@cmnd", Cmnd);
                cmd.Parameters.AddWithValue("@sdt", SDT);
                cmd.Parameters.AddWithValue("@diachi", Diachi);
                cmd.Parameters.AddWithValue("@ngaytao", Ngaytao);
                cmd.Parameters.AddWithValue("@diemso", Diemso);

                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Successfully Updated", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.getConnection().Close();

        }


        internal DataTable getThongKhachHang(int Makh)
        {
            DataTable data = new DataTable();

            string query = "select MaKh.khachhang, Tenkh.khachhang, Cmnd.khachhang, SDT.khachhang,Diachi.khachhang, Email.khachhang, Ngaytao.khachhang, Diemso.khachhang ";

            MySqlCommand cmd = new MySqlCommand(query, sqla.getConnection());
            cmd.Parameters.AddWithValue("@makh", Makh);
            //  MyConn2.Open();
            //For offline connection we weill use  MySqlDataAdapter class.
            if (cmd == null)
            {
                return null;
            }
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd;
            MyAdapter.Fill(data);
            //MessageBox.Show("Completed");
            sqla.getConnection().Close();

            return data;
        }
    }
}

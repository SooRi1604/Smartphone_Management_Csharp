using Smartphone_Management.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smartphone_Management.BUS
{
    internal class QuanLyKhachHang_BUS
    {
        QuanLyKhachHang_DAO qlkh_dao = new QuanLyKhachHang_DAO();
        internal void AddKhachHang(int text1, string text2, String text3, String text4, String text5, String text6, int text7)
        {
        }

        internal void AddKhachHang(int text1, string text2, String text3, String text4, String text5, String text6, DateTime value, int text7)
        {
            qlkh_dao.addKhachHang(text1,text2,text3,text4,text5,text6, value,text7);
        }

        internal void Delete(int makh)
        {
            qlkh_dao.deletekh(makh);
        }
        internal void updateKH(int text1, string text2, String text3, String text4, String text5, String text6, DateTime value, int text7)
        {
            qlkh_dao.updateKH(text1, text2, text3, text4, text5, text6, value, text7);
        }

        public DataTable getThongTinKhachHang(int Makh, String Tenkh, String Cmnd, String SDT, String Email, DateTime Ngaytao, int Diemso)
        {
            DataTable data = new DataTable();
            DataTable data2 = qlkh_dao.getThongKhachHang(Makh);
            
            data.Columns.Add("Makh");
            data.Columns.Add("Tenkh");
            data.Columns.Add("Cmnd");
            data.Columns.Add("SDT");
            data.Columns.Add("Diachi");
            data.Columns.Add("Email");
            data.Columns.Add("NgayTao", Type.GetType("System.DateTime"));
            data.Columns.Add("DiemSo");
            for (int i = 0; i < data2.Rows.Count; i++)
            {
                //dataGridView1.Rows.Add(1) ;
                DataRow row = data.NewRow();
                foreach (DataColumn col in data2.Columns)
                {
                    row[col.ColumnName] = data2.Rows[i][col.ColumnName];

                }
                
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i][0] = i + 1;
            }

            DataRow row4 = data.NewRow();
            data.Rows.Add(row4);
            DataRow row2 = data.NewRow();

            return data;
        }

      
    }
}

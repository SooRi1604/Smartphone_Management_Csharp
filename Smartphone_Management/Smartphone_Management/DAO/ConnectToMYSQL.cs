﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_7
{
    internal class ConnectToMYSQL
    {
        public string server = "localhost";
        public string database = "studentdb";
        public string username = "root";
        public string password = "123456789lop11b2";
        public string constring;
        private MySqlConnection conn;

        public ConnectToMYSQL()
        {
            this.constring = "SERVER=" + this.server + ";" + "DATABASE=" + this.database + ";" + "UID=" + this.username + ";" + "PASSWORD=" + this.password + ";";
            this.conn = new MySqlConnection(constring);
        }
        public void DataEditFromDatabase(String query2)
        {


            string query = "select * from sanpham";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine(reader["masp"]);
                Console.WriteLine(reader.GetString(1));
            }

        }

        public void DataProperty(String query, String property, ComboBox cb)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, this.conn);

                //this.conn.Open();
                MySqlDataReader mydr;

                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string ppty = mydr.GetString(property);
                    cb.Items.Add(ppty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.conn.Close();

        }

        public void UpdateTableKetQua(String updateQuery)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(updateQuery, this.conn);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Điểm đã được thêm vào database");
                }
                else
                {
                    MessageBox.Show("Điểm chưa được thêm vào database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        public void InsertTableKetQua(String insertQuery)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                MySqlDataReader mydr;
                mydr = cmd.ExecuteReader();
                MessageBox.Show("Save Data");
                while (mydr.Read())
                {
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
            conn.Close();

        }

        public DataTable DisplayData(String Query)
        {
            //conn.Open();

            DataTable dTable = new DataTable();

            try
            {
                MySqlCommand MyCommand2 = new MySqlCommand(Query, this.conn);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                if (MyCommand2 == null)
                {
                    return null;
                }
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                MyAdapter.Fill(dTable);
                return dTable;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.Close();
            return dTable;
        }
    }
}
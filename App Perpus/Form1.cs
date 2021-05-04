using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace App_Perpus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            load();
        }

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=dbperpus");
        MySqlCommand cmd;

        MySqlDataReader dr;
        String sql;
        bool Mode = true;
        string id;

        public void getid(string id)
        {
            sql = "select * from kategori where id_kategori= '" + id + "'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtnama.Text = dr[1].ToString();
                txtstatus.Text = dr[2].ToString();
            }
            conn.Close();
        }


        public void load()
        {
            sql = "SELECT * FROM kategori";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while(dr.Read())
            {
                dataGridView1.Rows.Add(dr[0],dr[1],dr[2]);
            }
            conn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama_kategori = txtnama.Text;
            string status = txtstatus.SelectedItem.ToString();

            if (Mode==true)
            {
                    sql = "INSERT INTO kategori(nama_kategori,status)values(@nama_kategori,@status)";
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nama_kategori", nama_kategori);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Berhasil Dibuat");
                    txtnama.Clear();
                    txtstatus.SelectedIndex = -1;
                    txtnama.Focus();
       
            }
            else
            {
                sql = "UPDATE kategori SET nama_kategori= @nama_kategori, status=@status WHERE id_kategori = @id_kategori";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_kategori", nama_kategori);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id_kategori", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategori Berhasil Diupdate");
                txtnama.Clear();
                txtstatus.SelectedIndex = -1;
                txtnama.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >=0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "DELETE FROM kategori WHERE id_kategori = @id_kategori";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_kategori", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategori Berhasil Dihapus");
                txtnama.Clear();
                txtstatus.SelectedIndex = -1;
                txtnama.Focus();
                conn.Close();
            }
        }
    }
}

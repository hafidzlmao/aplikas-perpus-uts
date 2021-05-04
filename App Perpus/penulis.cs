using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace App_Perpus
{
    public partial class penulis : Form
    {
        public penulis()
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
            sql = "select * from penulis where id_penulis= '" + id + "'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtnama.Text = dr[1].ToString();
                txtalamat.Text = dr[2].ToString();
                txttelp.Text = dr[3].ToString();
            }
            conn.Close();
        }

        public void load()
        {
            sql = "SELECT * FROM penulis";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            conn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void penulis_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nama_penulis = txtnama.Text;
            string alamat_penulis = txtalamat.Text;
            string telp_penulis = txttelp.Text;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "INSERT INTO penulis(nama_penulis,alamat_penulis,telp_penulis)values(@nama_penulis,@alamat_penulis,@telp_penulis)";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_penulis", nama_penulis);
                cmd.Parameters.AddWithValue("@alamat_penulis", alamat_penulis);
                cmd.Parameters.AddWithValue("@telp_penulis", telp_penulis);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penulis Berhasil Dibuat");
                txtnama.Clear();
                txtalamat.Clear();
                txttelp.Clear();
                txtnama.Focus();

            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "UPDATE penulis SET nama_penulis= @nama_penulis, alamat_penulis= @alamat_penulis, telp_penulis= @telp_penulis WHERE id_penulis= @id_penulis";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_penulis", nama_penulis);
                cmd.Parameters.AddWithValue("@alamat_penulis", alamat_penulis);
                cmd.Parameters.AddWithValue("@telp_penulis", telp_penulis);
                cmd.Parameters.AddWithValue("@id_penulis", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penulis Berhasil Diupdate");
                txtnama.Clear();
                //txtstatus.SelectedIndex = -1;
                txtnama.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "DELETE FROM penulis WHERE id_penulis = @id_penulis";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_penulis", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penulis Berhasil Dihapus");
                txtnama.Clear();
                txtnama.Focus();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


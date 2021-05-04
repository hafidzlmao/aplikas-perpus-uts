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
    public partial class buku : Form
    {
        public buku()
        {
            InitializeComponent();
            kategori_buku();
            penulis_buku();
            penerbit_buku();
            load();
        }

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=dbperpus");
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        String sql;
        bool Mode = true;
        string id;

        public void getid(string id)
        {
            sql = "SELECT * FROM buku WHERE id_buku= '" + id + "'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtnama.Text = dr[1].ToString();
                txtkategori.Text = dr[2].ToString();
                txtpenulis.Text = dr[3].ToString();
                txtpenerbit.Text = dr[4].ToString();
                txthalaman.Text = dr[5].ToString();
            }
            conn.Close();
        }

        public void load()
        {
            sql = "SELECT b.id_buku, b.nama_buku, c.nama_kategori, a.nama_penulis, p.nama_penerbit, b.halaman FROM buku b JOIN kategori c ON b.id_kategori = c.id_kategori JOIN penulis a ON b.id_penulis = a.id_penulis JOIN penerbit p ON b.id_penerbit = p.id_penerbit";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }
            conn.Close();

        }

        public void kategori_buku()
        {
            string query = "SELECT * FROM kategori";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            txtkategori.DataSource = ds.Tables[0];
            txtkategori.DisplayMember = "nama_kategori";
            txtkategori.ValueMember = "id_kategori";
            conn.Close();
        }

        public void penulis_buku()
        {
            string query = "SELECT * FROM penulis";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            txtpenulis.DataSource = ds.Tables[0];
            txtpenulis.DisplayMember = "nama_penulis";
            txtpenulis.ValueMember = "id_penulis";
            conn.Close();
        }

        public void penerbit_buku()
        {
            string query = "SELECT * FROM penerbit";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            txtpenerbit.DataSource = ds.Tables[0];
            txtpenerbit.DisplayMember = "nama_penerbit";
            txtpenerbit.ValueMember = "id_penerbit";
            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string nama_buku = txtnama.Text;
            string kategori_buku = txtkategori.SelectedValue.ToString();
            string penulis_buku = txtpenulis.SelectedValue.ToString();
            string penerbit_buku = txtpenerbit.SelectedValue.ToString();
            string halaman = txthalaman.Text;

            if (Mode == true)
            {
                sql = "INSERT INTO buku(nama_buku,id_kategori,id_penulis,id_penerbit,halaman)values(@nama_buku,@id_kategori,@id_penulis,@id_penerbit,@halaman)";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_buku", nama_buku);
                cmd.Parameters.AddWithValue("@id_kategori", kategori_buku);
                cmd.Parameters.AddWithValue("@id_penulis", penulis_buku);
                cmd.Parameters.AddWithValue("@id_penerbit", penerbit_buku);
                cmd.Parameters.AddWithValue("@halaman", halaman);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Buku Berhasil Dibuat");

            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "UPDATE buku SET nama_buku= @nama_buku, id_kategori= @id_kategori, id_penulis= @id_penulis, id_penerbit = @id_penerbit, halaman= @halaman WHERE id_buku = @id_buku";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_buku", nama_buku);
                cmd.Parameters.AddWithValue("@id_kategori", kategori_buku);
                cmd.Parameters.AddWithValue("@id_penulis", penulis_buku);
                cmd.Parameters.AddWithValue("@id_penerbit", penerbit_buku);
                cmd.Parameters.AddWithValue("@halaman", halaman);
                cmd.Parameters.AddWithValue("@id_buku", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Buku Berhasil Diupdate");
                txtnama.Clear();
                //txtstatus.SelectedIndex = -1;
                txtnama.Focus();
            }
         }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                sql = "DELETE FROM buku WHERE id_buku = @id_buku";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_buku", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("buku Berhasil Dihapus");
                txtnama.Clear();
                txtnama.Focus();
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
                sql = "DELETE FROM buku WHERE id_buku = @id_buku";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_buku", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Buku Berhasil Dihapus");
                txtnama.Clear();
                txtkategori.SelectedIndex = -1;
                txtpenulis.SelectedIndex = -1;
                txtpenerbit.SelectedIndex = -1;
                txthalaman.Clear();
                txtnama.Focus();
                conn.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



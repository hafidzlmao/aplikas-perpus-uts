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
    public partial class penerbit : Form
    {

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=dbperpus");
        MySqlCommand cmd;
        MySqlDataReader dr;
        String sql;
        bool Mode = true;
        string id;

        public void getid(string id)
        {
            sql = "select * from penerbit where id_penerbit= '" + id + "'";
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
            sql = "SELECT * FROM penerbit";
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

        public penerbit()
        {
            InitializeComponent();
            load();
        }

        private void penerbit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nama_penerbit = txtnama.Text;
            string alamat_penerbit = txtalamat.Text;
            string telp_penerbit = txttelp.Text;
       

            if (Mode == true)
            {
                sql = "INSERT INTO penerbit(nama_penerbit,alamat_penerbit,telp_penerbit)values(@nama_penerbit,@alamat_penerbit,@telp_penerbit)";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_penerbit", nama_penerbit);
                cmd.Parameters.AddWithValue("@alamat_penerbit", alamat_penerbit);
                cmd.Parameters.AddWithValue("@telp_penerbit", telp_penerbit);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penerbit Berhasil Dibuat");
                txtnama.Clear();
                txtalamat.Clear();
                txttelp.Clear();
                txtnama.Focus();

            }
            else
            {
                sql = "UPDATE penerbit SET nama_penerbit= @nama_penerbit, alamat_penerbit= @alamat_penerbit, telp_penerbit= @telp_penerbit WHERE id_penerbit= @id_penerbit";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_penerbit", nama_penerbit);
                cmd.Parameters.AddWithValue("@alamat_penerbit", alamat_penerbit);
                cmd.Parameters.AddWithValue("@telp_penerbit", telp_penerbit);
                cmd.Parameters.AddWithValue("@id_penerbit", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penerbit Berhasil Diupdate");
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
                sql = "DELETE FROM penerbit WHERE id_penerbit = @id_penerbit";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_penerbit", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Penerbit Berhasil Dihapus");
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
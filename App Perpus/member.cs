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
    public partial class member : Form
    {
        public member()
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
            sql = "select * from member where id_member= '" + id + "'";
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
            sql = "SELECT * FROM member";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string nama_member = txtnama.Text;
            string alamat_member = txtalamat.Text;
            string telp_member = txttelp.Text;


            if (Mode == true)
            {
                sql = "INSERT INTO member(nama_member,alamat_member,telp_member)values(@nama_member,@alamat_member,@telp_member)";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_member", nama_member);
                cmd.Parameters.AddWithValue("@alamat_member", alamat_member);
                cmd.Parameters.AddWithValue("@telp_member", telp_member);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Berhasil Dibuat");
                txtnama.Clear();
                txtalamat.Clear();
                txttelp.Clear();
                txtnama.Focus();

            }
            else
            {
                sql = "UPDATE member SET nama_member= @nama_member, alamat_member= @alamat_member, telp_member= @telp_member WHERE id_member= @id_member";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama_member", nama_member);
                cmd.Parameters.AddWithValue("@alamat_member", alamat_member);
                cmd.Parameters.AddWithValue("@telp_member", telp_member);
                cmd.Parameters.AddWithValue("@id_member", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Berhasil Diupdate");
                txtnama.Clear();             
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
                sql = "DELETE FROM member WHERE id_member = @id_member";
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_member", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Berhasil Dihapus");
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

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
    public partial class pinjambuku : Form
    {
        public pinjambuku()
        {
            InitializeComponent();
            buku();
        }

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=dbperpus");
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        String sql;
        bool Mode = true;
        string id;

        public void buku()
        {
            string query = "SELECT * FROM buku";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            txtbuku.DataSource = ds.Tables[0];
            txtbuku.DisplayMember = "nama_buku";
            txtbuku.ValueMember = "id_buku";
            conn.Close();
        }

        private void txtmemberid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new MySqlCommand("SELECT * FROM member WHERE id_member = '"+txtmemberid.Text+"' ",conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtnamamember.Text = dr["nama_member"].ToString();
                } else
                {
                    MessageBox.Show("Member Tidak Ditemukan");
                }
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_member = txtmemberid.Text;
            string nama_member = txtnamamember.Text;
            string buku = txtbuku.Text;
            string tgl_pinjam = txtpinjambuku.Value.ToString("yyyy-MM-dd");
            string tgl_kembali = txtkembalibuku.Value.ToString("yyyy-MM-dd");

            sql = "INSERT INTO pinjambuku(id_member,buku,tgl_pinjam,tgl_kembali) values (@id_member,@buku,@tgl_pinjam,@tgl_kembali)";
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_member", id_member);
            cmd.Parameters.AddWithValue("@buku", buku);
            cmd.Parameters.AddWithValue("@tgl_pinjam", tgl_pinjam);
            cmd.Parameters.AddWithValue("@tgl_kembali", tgl_kembali);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Buku Berhasil Dipinjam");
            conn.Close();

        }
    }
}

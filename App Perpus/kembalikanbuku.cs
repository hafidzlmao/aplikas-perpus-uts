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
    public partial class kembalikanbuku : Form
    {
        public kembalikanbuku()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=dbperpus");
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        String sql;
        bool Mode = true;
        string id;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new MySqlCommand("SELECT buku,tgl_pinjam,tgl_kembali,DATEDIFF(tgl_pinjam,tgl_kembali)AS waktu_berlalu FROM pinjambuku WHERE id_member = '" + txtidmember.Text + "'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtnamabuku.Text = dr["buku"].ToString();
                    txttglkembali.Text = dr["tgl_kembali"].ToString();
                    string waktu_berlalu = dr["waktu_berlalu"].ToString();

                    int elapsed_time = int.Parse(waktu_berlalu);
                    txtwaktuberlalu.Text = waktu_berlalu;
                    if (elapsed_time > 0)
                    {
                        int denda = elapsed_time * 5000;
                        txtdenda.Text = denda.ToString();
                    } else
                    {
                        txtdenda.Text = "0";
                    }
                }
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_member = txtidmember.Text;
            string buku = txtnamabuku.Text;
            string tgl_kembali = txttglkembali.Text;
            string waktu_berlalu = txtwaktuberlalu.Text;
            string denda = txtdenda.Text;
            

            sql = "INSERT INTO kembalikanbuku(id_member,buku,tgl_kembali,waktu_berlalu,denda) values (@id_member,@buku,@tgl_kembali,@waktu_berlalu,@denda)";
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_member", id_member);
            cmd.Parameters.AddWithValue("@buku", buku);
            cmd.Parameters.AddWithValue("@tgl_kembali", tgl_kembali);
            cmd.Parameters.AddWithValue("@waktu_berlalu", waktu_berlalu);
            cmd.Parameters.AddWithValue("@denda", denda);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Buku Berhasil Dikembalikan");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

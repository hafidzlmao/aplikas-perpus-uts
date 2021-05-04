using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Perpus
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 kategori = new Form1();
            kategori.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            penulis penulis = new penulis();
            penulis.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            penerbit penerbit = new penerbit();
            penerbit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buku buku = new buku();
            buku.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            member member = new member();
            member.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pinjambuku pbuku = new pinjambuku();
            pbuku.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kembalikanbuku bukukembali = new kembalikanbuku();
            bukukembali.Show();

        }
    }
}

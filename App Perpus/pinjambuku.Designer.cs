
namespace App_Perpus
{
    partial class pinjambuku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtkembalibuku = new System.Windows.Forms.DateTimePicker();
            this.txtpinjambuku = new System.Windows.Forms.DateTimePicker();
            this.txtbuku = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnamamember = new System.Windows.Forms.TextBox();
            this.txtmemberid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtkembalibuku);
            this.groupBox1.Controls.Add(this.txtpinjambuku);
            this.groupBox1.Controls.Add(this.txtbuku);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtnamamember);
            this.groupBox1.Controls.Add(this.txtmemberid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(34, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 426);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tanggal Pinjam";
            // 
            // txtkembalibuku
            // 
            this.txtkembalibuku.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtkembalibuku.Location = new System.Drawing.Point(8, 379);
            this.txtkembalibuku.Name = "txtkembalibuku";
            this.txtkembalibuku.Size = new System.Drawing.Size(233, 25);
            this.txtkembalibuku.TabIndex = 10;
            // 
            // txtpinjambuku
            // 
            this.txtpinjambuku.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtpinjambuku.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtpinjambuku.Location = new System.Drawing.Point(8, 300);
            this.txtpinjambuku.Name = "txtpinjambuku";
            this.txtpinjambuku.Size = new System.Drawing.Size(233, 25);
            this.txtpinjambuku.TabIndex = 9;
            // 
            // txtbuku
            // 
            this.txtbuku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtbuku.FormattingEnabled = true;
            this.txtbuku.Location = new System.Drawing.Point(7, 214);
            this.txtbuku.Name = "txtbuku";
            this.txtbuku.Size = new System.Drawing.Size(234, 29);
            this.txtbuku.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tanggal Kembali";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tanggal Pinjam";
            // 
            // txtnamamember
            // 
            this.txtnamamember.Location = new System.Drawing.Point(6, 149);
            this.txtnamamember.Name = "txtnamamember";
            this.txtnamamember.Size = new System.Drawing.Size(234, 29);
            this.txtnamamember.TabIndex = 4;
            // 
            // txtmemberid
            // 
            this.txtmemberid.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtmemberid.Location = new System.Drawing.Point(6, 74);
            this.txtmemberid.Name = "txtmemberid";
            this.txtmemberid.Size = new System.Drawing.Size(234, 29);
            this.txtmemberid.TabIndex = 3;
            this.txtmemberid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmemberid_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Anggota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Anggota";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Simpan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 466);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 27);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pinjambuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "pinjambuku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pinjambuku";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtkembalibuku;
        private System.Windows.Forms.DateTimePicker txtpinjambuku;
        private System.Windows.Forms.ComboBox txtbuku;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnamamember;
        private System.Windows.Forms.TextBox txtmemberid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
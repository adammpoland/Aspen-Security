namespace Aspen_Security
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AesDecrypt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lvDirs = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.output = new System.Windows.Forms.Label();
            this.nothing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Encrypt
            // 
            this.Encrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(1)))));
            this.Encrypt.Location = new System.Drawing.Point(9, 10);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(144, 55);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.Text = "OTP Encrypt";
            this.Encrypt.UseVisualStyleBackColor = false;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(1)))));
            this.Decrypt.Location = new System.Drawing.Point(153, 10);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(144, 55);
            this.Decrypt.TabIndex = 1;
            this.Decrypt.Text = "OTP Decrypt";
            this.Decrypt.UseVisualStyleBackColor = false;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(135)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "LIST OF LOCKED FILE LOCATIONS";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // AesDecrypt
            // 
            this.AesDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(1)))));
            this.AesDecrypt.Location = new System.Drawing.Point(441, 10);
            this.AesDecrypt.Name = "AesDecrypt";
            this.AesDecrypt.Size = new System.Drawing.Size(144, 55);
            this.AesDecrypt.TabIndex = 5;
            this.AesDecrypt.Text = "AES DECRYPT";
            this.AesDecrypt.UseVisualStyleBackColor = false;
            this.AesDecrypt.Click += new System.EventHandler(this.AesDecrypt_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(1)))));
            this.button2.Location = new System.Drawing.Point(297, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 55);
            this.button2.TabIndex = 4;
            this.button2.Text = "AES ENCRYPT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(508, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 254);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lvDirs
            // 
            this.lvDirs.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvDirs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.size});
            this.lvDirs.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lvDirs.Location = new System.Drawing.Point(10, 137);
            this.lvDirs.Name = "lvDirs";
            this.lvDirs.Size = new System.Drawing.Size(485, 224);
            this.lvDirs.TabIndex = 8;
            this.lvDirs.UseCompatibleStateImageBehavior = false;
            this.lvDirs.View = System.Windows.Forms.View.Details;
            this.lvDirs.Click += new System.EventHandler(this.LvDirs_Click);
            this.lvDirs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvDirs_MouseClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 150;
            // 
            // size
            // 
            this.size.Text = "File Location";
            this.size.Width = 300;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 372);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(485, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.Teal;
            this.output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(104)))), ((int)(((byte)(37)))));
            this.output.Location = new System.Drawing.Point(12, 408);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(759, 34);
            this.output.TabIndex = 10;
            // 
            // nothing
            // 
            this.nothing.AutoSize = true;
            this.nothing.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nothing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(135)))), ((int)(((byte)(32)))));
            this.nothing.Location = new System.Drawing.Point(525, 98);
            this.nothing.Name = "nothing";
            this.nothing.Size = new System.Drawing.Size(260, 18);
            this.nothing.TabIndex = 11;
            this.nothing.Text = "Drop Files on the lock to encrypt them";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(135)))), ((int)(((byte)(32)))));
            this.label2.Location = new System.Drawing.Point(608, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "⇓⇓⇓⇓⇓";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(135)))), ((int)(((byte)(32)))));
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Click on the name to Decrypt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(89)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nothing);
            this.Controls.Add(this.output);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lvDirs);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AesDecrypt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Aspen Security";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AesDecrypt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lvDirs;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Label nothing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


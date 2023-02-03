using System.ComponentModel;

namespace Exercise1
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.EncryptButton = new System.Windows.Forms.Button();
            this.EncryptLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DecryptLabel = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // EncryptButton
            // 
            this.EncryptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EncryptButton.Location = new System.Drawing.Point(342, 75);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(110, 48);
            this.EncryptButton.TabIndex = 0;
            this.EncryptButton.Text = "ENCRYPT";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // EncryptLabel
            // 
            this.EncryptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptLabel.Location = new System.Drawing.Point(324, 30);
            this.EncryptLabel.Name = "EncryptLabel";
            this.EncryptLabel.Size = new System.Drawing.Size(146, 23);
            this.EncryptLabel.TabIndex = 1;
            this.EncryptLabel.Text = "Encrypter";
            this.EncryptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(33, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(280, 48);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(488, 75);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(280, 48);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(319, 192);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(163, 40);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(332, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "KEY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DecryptLabel
            // 
            this.DecryptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DecryptLabel.Location = new System.Drawing.Point(324, 295);
            this.DecryptLabel.Name = "DecryptLabel";
            this.DecryptLabel.Size = new System.Drawing.Size(146, 23);
            this.DecryptLabel.TabIndex = 9;
            this.DecryptLabel.Text = "Decrypter";
            this.DecryptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(33, 354);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(280, 48);
            this.richTextBox4.TabIndex = 10;
            this.richTextBox4.Text = "";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DecryptButton.Location = new System.Drawing.Point(342, 354);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(110, 48);
            this.DecryptButton.TabIndex = 11;
            this.DecryptButton.Text = "DECRYPT";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(488, 354);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.Size = new System.Drawing.Size(280, 48);
            this.richTextBox5.TabIndex = 12;
            this.richTextBox5.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.DecryptLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.EncryptLabel);
            this.Controls.Add(this.EncryptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.RichTextBox richTextBox5;

        private System.Windows.Forms.RichTextBox richTextBox4;

        private System.Windows.Forms.Label DecryptLabel;

        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.RichTextBox richTextBox2;

        private System.Windows.Forms.RichTextBox richTextBox1;

        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Label EncryptLabel;

        #endregion
    }
}
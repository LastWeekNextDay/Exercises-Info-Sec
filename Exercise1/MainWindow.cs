using System;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get text from richTextBox1, encrypt it, and put it in richTextBox2
                richTextBox2.Text = VigenereCypher.Encrypt(richTextBox1.Text, richTextBox3.Text);
            }
            catch (Exception exception)
            {
                throw new SystemException("Error: " + exception);
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get text from richTextBox4, decrypt it, and put it in richTextBox5
                richTextBox5.Text = VigenereCypher.Decrypt(richTextBox4.Text, richTextBox3.Text);
            }
            catch (Exception exception)
            {
                throw new SystemException("Error: " + exception);
            }
        }
    }
}
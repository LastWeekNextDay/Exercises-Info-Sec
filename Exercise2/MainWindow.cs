using System;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Exercise2
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            label1.Text = "";
            label2.Text = "";
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            // Check if checkbox1 is checked, if not, check if richTextBox1 is empty, if it is, show error message
            if (!checkBox1.Checked && richTextBox1.Text == "")
            {
                MessageBox.Show(@"Please enter a string or select a file to take the string from.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if key is empty, if it is, show error message
            if (richTextBox3.Text == "")
            {
                MessageBox.Show(@"Please enter a key.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create AES object
            var aes = Aes.Create();

            // If key is less than 16 bytes, make it 16 bytes
            if (richTextBox3.Text.Length < 16)
            {
                richTextBox3.Text = richTextBox3.Text.PadRight(16, ' ');
            }
            // if key is between 16 and 32 bytes, make it 32 bytes
            else if (richTextBox3.Text.Length > 16 && richTextBox3.Text.Length < 32)
            {
                richTextBox3.Text = richTextBox3.Text.PadRight(32, ' ');
            }
            // if key is more than 32 bytes, make it 32 bytes
            else if (richTextBox3.Text.Length > 32)
            {
                richTextBox3.Text = richTextBox3.Text.Substring(0, 32);
            }

            // Convert key to byte array
            var key = System.Text.Encoding.UTF8.GetBytes(richTextBox3.Text);

            // Set key
            aes.Key = key;
            
            // Set padding
            aes.Padding = PaddingMode.PKCS7;

            // if richtextbox4 is empty, generate IV and assign it to richTextBox4, else take IV from richtextbox4
            if (richTextBox4.Text == "" || richTextBox4.Text.Length == 0)
            {
                // Generate IV
                aes.GenerateIV();
                // Convert IV to string
                var iv = System.Text.Encoding.UTF8.GetString(aes.IV);
                // Assign IV to richtextbox4
                richTextBox4.Text = iv;
            }
            else
            {
                // If richtextbox4 is less than BlockSize divided by 8, make it BlockSize divided by 8
                if (richTextBox4.Text.Length < aes.BlockSize / 8)
                {
                    richTextBox4.Text = richTextBox4.Text.PadRight(aes.BlockSize / 8, ' ');
                }
                // If richtextbox4 is more than BlockSize divided by 8, make it BlockSize divided by 8
                else if (richTextBox4.Text.Length > aes.BlockSize / 8)
                {
                    richTextBox4.Text = richTextBox4.Text.Substring(0, aes.BlockSize / 8);
                }

                // Convert IV to byte array
                var iv = System.Text.Encoding.UTF8.GetBytes(richTextBox4.Text);
                // Set IV
                aes.IV = iv;
            }

            if (radioButton3.Checked)
            {
                // Set cipher mode of operation to ECB
                aes.Mode = CipherMode.ECB;
            }

            if (radioButton4.Checked)
            {
                // Set cipher mode of operation to CBC
                aes.Mode = CipherMode.CBC;
            }

            if (radioButton5.Checked)
            {
                // Set cipher mode of operation to CFB
                aes.Mode = CipherMode.CFB;
            }

            // First, check which action is selected
            if (radioButton1.Checked)
            {
                // Check if checkbox1 is checked, if it is, read the string from the file
                if (checkBox1.Checked)
                {
                    // Read string from file
                    richTextBox1.Text = System.IO.File.ReadAllText(GlobalVar.TakeFromPath);
                }

                // Convert string to bytes
                var input = System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text);

                // Create encryptor
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                
                // TODO: Encrypt the input
            }
            else if (radioButton2.Checked)
            {
                // Check if checkbox1 is checked, if it is, read the string from the file
                if (checkBox1.Checked)
                {
                    // Read string from file
                    richTextBox1.Text = System.IO.File.ReadAllText(GlobalVar.TakeFromPath);
                }

                // Convert richtextbox1 to byte array
                var input = System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text);
                // Create decryptor
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                
                // TODO: Decrypt the input
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Open file dialog looking for .txt files
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = @"Text files (*.txt)|*.txt";

                // If user selects a file, set file path to take string from to the selected file and assign the path to label1
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalVar.TakeFromPath = openFileDialog.FileName;
                    label1.Text = GlobalVar.TakeFromPath;
                }
                // If user cancels, set file path to take string from to empty. uncheck the checkbox, and assign an empty string to label1
                else
                {
                    GlobalVar.TakeFromPath = "";
                    checkBox1.Checked = false;
                    label1.Text = "";
                }
            }
            else
            {
                // Set file path to take string from to empty
                GlobalVar.TakeFromPath = "";
                // Assign an empty string to label1
                label1.Text = "";
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // Open file dialog looking for .txt files
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = @"Text files (*.txt)|*.txt";

                // If user selects a file, set file path to save string to to the selected file and assign the path to label2
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalVar.SaveToPath = openFileDialog.FileName;
                    label2.Text = GlobalVar.SaveToPath;
                }
                // If user cancels, set file path to save string to to empty. uncheck the checkbox, and assign an empty string to label2
                else
                {
                    GlobalVar.SaveToPath = "";
                    checkBox2.Checked = false;
                    label2.Text = "";
                }
            }
            else
            {
                // Set file path to save string to to empty
                GlobalVar.SaveToPath = "";
                // Assign an empty string to label2
                label2.Text = "";
            }
        }
    }
}
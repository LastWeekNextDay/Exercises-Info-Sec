using System;
using System.Drawing;
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
            // Set default values
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

            // *** IV ***

            // if richtextbox4 is empty, generate IV and assign it to richTextBox4, else take IV from richtextbox4
            if (richTextBox4.Text == "" || richTextBox4.Text.Length == 0)
            {
                // Generate IV
                aes.GenerateIV();

                // Assign IV to richtextbox4
                richTextBox4.Text = System.Text.Encoding.UTF8.GetString(aes.IV);
            }
            else
            {
                // Check if richtextbox4 text length is divisible by BlockSize / 8
                if (richTextBox4.Text.Length % (aes.BlockSize / 8) != 0)
                {
                    // Get value to add to richtextbox4 text length to make it divisible by BlockSize / 8
                    var add = (aes.BlockSize / 8) - (richTextBox4.Text.Length % (aes.BlockSize / 8));

                    // Make string the correct size
                    richTextBox4.Text = AesUtil.StringToSize(richTextBox4.Text, richTextBox4.Text.Length + add);
                }

                // Set IV
                aes.IV = System.Text.Encoding.UTF8.GetBytes(richTextBox4.Text);
            }

            // *** Key ***

            // Make key the correct size
            richTextBox3.Text = AesUtil.StringToSize(richTextBox3.Text, 32);

            // Convert key to byte array
            var keyBytes = AesUtil.StringToAesKey(richTextBox3.Text);

            // Set key size
            aes.KeySize = 256;

            // *** Mode ***

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
            if (radioButton1.Checked) // Encrypt
            {
                // Encrypt the string
                var outputString = AesUtil.EncryptString(richTextBox1.Text, keyBytes, aes.IV, aes.Mode);

                // Check if checkbox2 is checked, if it is, save the string to the file
                if (checkBox2.Checked)
                {
                    // Save string to file
                    System.IO.File.WriteAllText(GlobalVar.SaveToPath, outputString);
                }

                // Show string in richtextbox2
                richTextBox2.Text = outputString;
            }
            else if (radioButton2.Checked) // Decrypt
            {
                // Decrypt the string
                var outputString = AesUtil.DecryptString(richTextBox1.Text, keyBytes, aes.IV, aes.Mode);

                // Check if checkbox2 is checked, if it is, save the string to the file
                if (checkBox2.Checked)
                {
                    // Save string to file
                    System.IO.File.WriteAllText(GlobalVar.SaveToPath, outputString);
                }

                // Show string in richtextbox2
                richTextBox2.Text = outputString;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Open file dialog looking for .txt files
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = @"Text files (*.txt)|*.txt";

                // If user selects a file, set file path to take string from to the selected file,
                // assign the path to label1, disable richTextBox1 from being edited and assign text inside file to
                // richTextBox1
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalVar.TakeFromPath = openFileDialog.FileName;
                    label1.Text = GlobalVar.TakeFromPath;
                    richTextBox1.ReadOnly = true;
                    richTextBox1.BackColor = SystemColors.Control;
                    richTextBox1.Text = System.IO.File.ReadAllText(GlobalVar.TakeFromPath);
                }
                // If user cancels, set file path to take string from to empty. uncheck the checkbox,
                // assign an empty string to label1 and enable richTextBox1 to be edited
                else
                {
                    GlobalVar.TakeFromPath = "";
                    checkBox1.Checked = false;
                    label1.Text = "";
                    richTextBox1.ReadOnly = false;
                    richTextBox1.BackColor = SystemColors.Window;
                }
            }
            else
            {
                // Set file path to take string from to empty
                GlobalVar.TakeFromPath = "";
                // Assign an empty string to label1
                label1.Text = "";
                // Enable richTextBox1 to be edited
                richTextBox1.ReadOnly = false;
                // Set richtextbox1 background color to white
                richTextBox1.BackColor = SystemColors.Window;
                // Clear richtextbox1
                richTextBox1.Text = "";
            }

            // Update render of richtextbox1
            richTextBox1.Refresh();
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // Open file dialog looking for .txt files
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = @"Text files (*.txt)|*.txt";

                // If user selects a file, set file path to save string to to the selected file,
                // assign the path to label2
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalVar.SaveToPath = openFileDialog.FileName;
                    label2.Text = GlobalVar.SaveToPath;
                }
                // If user cancels, set file path to save string to to empty. uncheck the checkbox,
                // assign an empty string to label2
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
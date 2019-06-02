using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aspen_Security
{
    public partial class Form1 : Form
    {
        /*TODO 
         
        ------> Select a directory to save and load the keys
        ------> Find a listview box to store |File Name|LAST KNOWN File LOCATION|LAST KNOWN KEY LOCATION|DATE|
        ------> Clicking on a List View Item Will decrypt the file

        Make a new project
        ------> This project will automatically decypt when a user logs on
        ------> This will automatically encrypt when user logs off
        ------> maybe by using a password

        Make Another project
        ------> USB KEY RING
        ------> USB HAS AES KEYS OR KEYFILES STORED INSTEAD OF LOCALLY
        ------> MAY ALSO HAVE OPTION FOR STORING COPY OF THE KEY ONLINE 
        ------> Remember to explain why storing the key in a different location is more safe.

        MAKE THE ANDROID APP
        ------> LEAVES ENCRYPTED DATA ON PHONE
        ------> SENDS KEY TO SERVER
        ------> APP SELECTS KNOWN ENCRYPTED FILES AND DECRYPTS

    */
        private byte[] byteKey;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
            pictureBox1.DragEnter += new DragEventHandler(Form1_DragEnter);
            pictureBox1.DragDrop += new DragEventHandler(Form1_DragDrop);
        }


        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {

                otpEncrypt(file);
            }
        }

        void updateLV(string name, string path)
        {
            
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 1;
            lvi.Text = name;
            lvi.SubItems.Add(path);

            lvDirs.Items.Add(lvi);
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedFileName = " ";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                //openFileDialog1.Filter = "*.key";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedFileName = openFileDialog1.FileName;
                    //...
                }

            otpEncrypt(selectedFileName);
            File.Delete(selectedFileName);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Decrypt_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedKey = " ";
                string selectedFile = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Key files (*.key)|*.key";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedKey = openFileDialog1.FileName;
                    //...
                }
                byteKey = File.ReadAllBytes(selectedKey);


                OpenFileDialog openFileDialog2 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Locked files (*.lock)|*.lock";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = openFileDialog2.FileName;
                    //...
                }

                otpDecrypt(selectedKey,selectedFile);
                File.Delete(selectedKey);
                File.Delete(selectedFile);
            }
            catch (Exception)
            {

            }
        }

        void otpEncrypt(string selectedFileName)
        {

            byte[] bytes = File.ReadAllBytes(selectedFileName);
            //MessageBox.Show(bytes[4].ToString());
            ///////////////////////////////////////////////////////////////random bytes///
            byte[] random = new Byte[bytes.Length];

            //RNGCryptoServiceProvider is an implementation of a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random); // The array is now filled with cryptographically strong random bytes.
                                  //////////////////////////do the stuff///////////
                                  ///
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bytes.Length;

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(bytes[i] ^ random[i]);
                progressBar1.Value += 1;

            }

            File.WriteAllBytes(selectedFileName + ".lock", bytes);

            byteKey = random;
            File.WriteAllBytes(selectedFileName + ".key", random);
            progressBar1.Value = 0;
            progressBar1.Maximum = bytes.Length;

            output.Text = selectedFileName + " has been Succesfully encrypted";
            //delete the file after encryption
            updateLV(Path.GetFileName(selectedFileName),selectedFileName);
            File.Delete(selectedFileName);

        }

        void otpDecrypt(string selectedKey, string selectedFile)
        {
            byte[] bytes = File.ReadAllBytes(selectedFile);
            byte[] Key = File.ReadAllBytes(selectedKey);
            string file = Path.GetFileNameWithoutExtension(selectedFile);
            //string path = Path.GetFullPath(selectedFile);
            string path = GetDirectoryName(selectedFile);
            string FnP = path + @"\" + file;
            progressBar1.Value = 0;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = bytes.Length;

            MessageBox.Show(FnP);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(bytes[i] ^ Key[i]);
                progressBar1.Value += 1;
            }
            File.WriteAllBytes(FnP, bytes);
            

            output.Text = selectedFile + "has been succesfully decrypted";
        }


        static string GetDirectoryName(string f)
        {
            try
            {
                return f.Substring(0, f.LastIndexOf('\\'));
            }
            catch
            {
                return string.Empty;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Aes myAes = Aes.Create();
            //byte key_no = 0x00;
            //byte[] key = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //byte[] IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            myAes.Mode = CipherMode.CBC;
            myAes.KeySize = 128;
            myAes.BlockSize = 128;
            myAes.FeedbackSize = 128;
            myAes.Padding = PaddingMode.Zeros;
            try
            {
                string selectedFileName = " ";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                //openFileDialog1.Filter = "*.key";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedFileName = openFileDialog1.FileName;
                    //...
                }

                EncryptBytes_Aes(selectedFileName,myAes.Key,myAes.IV);
                File.Delete(selectedFileName);

            }
            catch (Exception)
            {
                throw;
            }

            //byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

        }

        private void AesDecrypt_Click(object sender, EventArgs e)
        {
            //try
            //{
                string selectedIV = "";
                string selectedKey = "";
                string selectedFile = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Key files (*.key)|*.key";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedKey = openFileDialog1.FileName;
                    //...
                }
                byteKey = File.ReadAllBytes(selectedKey);


                OpenFileDialog openFileDialog2 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Locked files (*.lock)|*.lock";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = openFileDialog2.FileName;
                    //...
                }

                OpenFileDialog openFileDialog3 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "IV files (*.IV)|*.IV";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog3.ShowDialog() == DialogResult.OK)
                {
                    selectedIV = openFileDialog3.FileName;
                    //...
                }


                byte[] bytes = DecryptAes(selectedFile, selectedKey, selectedIV);
                string f = Path.GetFileNameWithoutExtension(selectedFile);
                MessageBox.Show(f);

                File.Delete(selectedKey);
                File.Delete(selectedFile);
                File.Delete(selectedIV);
                writeFile(f, bytes);

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        void EncryptBytes_Aes(string selectedFileName, byte[] Key, byte[] IV)
        {

            byte[] plainText = File.ReadAllBytes(selectedFileName);

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = 128;
                aesAlg.BlockSize = 128;
                aesAlg.FeedbackSize = 128;
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.


                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {  
                        csEncrypt.Write(plainText,0,plainText.Length);
                        
                       
                        
                        //using (FileStream fs = new FileStream(selectedFileName + ".lock", FileMode.OpenOrCreate))
                        //{
                        //    msEncrypt.CopyTo(fs);
                            
                        //    fs.Flush();
                        //}
                        encrypted = msEncrypt.ToArray();
                        csEncrypt.FlushFinalBlock();
                    }
                }
                

                File.WriteAllBytes(selectedFileName + ".lock", encrypted);
                File.WriteAllBytes(selectedFileName + ".IV", IV);
                File.WriteAllBytes(selectedFileName + ".key", Key);
            }

        }

        private byte[] DecryptAes(string selectedFileName, string KeyFile, string IVFile)
        {
            try { 
                byte[] cipherText = File.ReadAllBytes(selectedFileName);
                byte[] Key = File.ReadAllBytes(KeyFile);
                byte[] IV = File.ReadAllBytes(IVFile);
                string f;
                byte[] fileBytes;
                int length = cipherText.Length;

                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aesAlg = Aes.Create())
                {
                    // aesAlg.Mode = CipherMode.CBC;
                    aesAlg.KeySize = 128;
                    aesAlg.BlockSize = 128;
                    aesAlg.FeedbackSize = 128;
                    aesAlg.Padding = PaddingMode.Zeros;
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    //using (MemoryStream mStream = new MemoryStream(cipherText))
                    //using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Padding = PaddingMode.None })
                    //using (CryptoStream cryptoStream = new CryptoStream(mStream, aesProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    //{
                    //    cryptoStream.Read(cipherText, 0, length);
                    //    //mStream.ToArray().Take(length).ToArray();
                    //    string f = Path.GetFileNameWithoutExtension(selectedFileName);
                    //    byte[] fileBytes = mStream.ToArray();
                    //    File.WriteAllBytes(f, fileBytes);
                    //}

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                      
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                        {
                           

                            csDecrypt.Write(cipherText, 0, length);
                            f = Path.GetFileNameWithoutExtension(selectedFileName);
                            FileStream file = new FileStream(f, FileMode.Create, FileAccess.Write);
                            msDecrypt.WriteTo(file);
                            file.Close();

                            return fileBytes = msDecrypt.ToArray();

                            //File.WriteAllBytes(f, fileBytes);


                        }

                    }

                }
                //writeFile(f,fileBytes);
                //File.WriteAllBytes(f, fileBytes);
                //File.WriteAllBytes("cool.text", fileBytes);
                //string result = System.Text.Encoding.UTF8.GetString(fileBytes);
                //MessageBox.Show(result);

                //File.WriteAllBytes("cool2.text", IV);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

                throw;
            }

        }
        void writeFile(string f, byte[] fileBytes)
        {
            try
            {
                //var bw = new BinaryWriter(File.Create(f));
                //bw.Write(fileBytes);

                File.WriteAllBytes(f, fileBytes);

                string result = System.Text.Encoding.UTF8.GetString(fileBytes);
                MessageBox.Show(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LvDirs_Click(object sender, EventArgs e)
        {
            //otpDecrypt(sender.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LvDirs_MouseClick(object sender, MouseEventArgs e)
        {//this will be the automatic feature 
         //select the file location from the second column
         //use this path to decrypt()
         
            string curitem = lvDirs.SelectedItems[0].Text;
            if (curitem.Contains("."))
            {
                if (curitem.Contains(".mrb"))
                {
                    
                }

            }
        }
    }
}

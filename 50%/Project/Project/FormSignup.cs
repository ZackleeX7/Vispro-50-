using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project
{
    public partial class FormSignup : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormSignup()
        {
            alamat = "server=localhost; database=db_admin; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                if (CreateusernameText.Text != "" && spasswordText.Text != "" && spasswordText2.Text != "")
                {

                    query = string.Format("insert into tbl_user  values ('{0}','{1}','{2}');", CreateusernameText.Text, spasswordText.Text, spasswordText2.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        FormSignup_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string username = CreateusernameText.Text.Trim();
            string password = spasswordText.Text;
            string confirmPassword = spasswordText2.Text;

            // --- Validation Logic ---

            // 1️⃣ Check if username is empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Check if password fields are empty
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm your password.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4️⃣ Check password strength
            if (password.Length < 0)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            // ✅ If all checks pass
            MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Open main form
            Form1 form1 = new Form1();
            form1.Show();

            // Optional: Close the signup form
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void CreateusernameText_TextChanged(object sender, EventArgs e)
        {
        }

        private void spasswordText_TextChanged(object sender, EventArgs e)
        {
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {

        }


        private void spasswordText2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

using Microsoft.Data.SqlClient;

namespace ConnectingDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection Successful!");

                    // List databases
                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Failed: {ex.Message}");
            }
        }
    }
}

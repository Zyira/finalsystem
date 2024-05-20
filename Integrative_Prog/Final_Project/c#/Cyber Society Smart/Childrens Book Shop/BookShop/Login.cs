using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

       
       
        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public class PersonalAccount
        {
            public int PersonalId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            // Add other properties as necessary
        }

        private async Task<PersonalAccount> GetPersonalAccountAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the API endpoint
                    string apiUrl = "http://localhost:3000/acc/personal-account";

                    // Create the JSON payload
                    var payload = new
                    {
                        username = username,
                        password = password
                    };

                    // Serialize the payload to JSON
                    string jsonContent = JsonConvert.SerializeObject(payload);

                    // Create the content object with the JSON payload
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Ensure the response status is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the response to PersonalAccount object
                    PersonalAccount personalAccount = JsonConvert.DeserializeObject<PersonalAccount>(responseBody);

                    return personalAccount;
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show($"Error fetching personal account: {httpRequestException.Message}");
                    return null;
                }
            }
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            // Assume you get the username and password from input fields
            string username = UnameTb.Text;
            string password = UPassTb.Text;

            // Call the method to get personal account info
            PersonalAccount personalAccount = await GetPersonalAccountAsync(username, password);

            if (personalAccount != null)
            {
                Students s = new Students();
                this.Hide();
                s.Show();
            }
            else
            {
                MessageBox.Show("Personal account not found.");
            }
        }

      

        private void Hidebtn_Click(object sender, EventArgs e)
        {
            if (UPassTb.PasswordChar == '\0')
            {
                showbtn.BringToFront();
                UPassTb.PasswordChar = '*';
            }
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            if (UPassTb.PasswordChar == '*')
            {
                Hidebtn.BringToFront();
                UPassTb.PasswordChar = '\0';
            }

        }

        private void UPassTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

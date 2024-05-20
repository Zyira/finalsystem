using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookShop
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
       
        }
        private void Reset() {
            Firstnametbx.Text = "";
            Middlenametbx.Text = "";
            Lastnametbx.Text = "";
            Coursetbx.Text = "";
            Agetbx.Text = "";
            Sextbx.Text = "";
            Campustbx.Text = "";
            Departmenttbx.Text = "";
            Coursetbx.Text = "";
            Majortbx.Text = "";
            Statustbx.Text = "";
            Yeartbx.Text = "";

        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
       

        private void button7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public class PersonalInfo
        {
            public int personal_id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string middlename { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public string campus { get; set; }
            public string department { get; set; }
            public string course { get; set; }
            public string major { get; set; }
            public string status { get; set; }
            public int year { get; set; }
        }

        private async Task LoadPersonalInfoAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:3000/api/personal-info");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<PersonalInfo> personalInfoList = JsonConvert.DeserializeObject<List<PersonalInfo>>(responseBody);
                    UserDGV.DataSource = personalInfoList;
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show($"Error fetching personal information: {httpRequestException.Message}");
                }
            }
        }


        public class PersonalInfos
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string middlename { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public string campus { get; set; }
            public string department { get; set; }
            public string course { get; set; }
            public string major { get; set; }
            public string status { get; set; }
            public int year { get; set; }
        }

        private async Task AddPersonalInfoAsync(PersonalInfos personalInfo)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the API endpoint
                    string apiUrl = "http://localhost:3000/api/personal-info";

                    // Serialize the personal info object to JSON
                    string jsonContent = JsonConvert.SerializeObject(personalInfo);

                    // Create the content object with the JSON payload
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Ensure the response status is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Optionally, you can deserialize the response if needed
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    // Display success message
                    MessageBox.Show($"Personal info added successfully with ID: {result.personalId}");
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show($"Error adding personal information: {httpRequestException.Message}");
                }
            }
        }
        private async void Students_Load_1(object sender, EventArgs e)
        {
            await LoadPersonalInfoAsync();
            lblId.Visible = false;
        }

        private async void Addbtn_Click_1(object sender, EventArgs e)
        {
            var personalInfo = new PersonalInfos
            {
                firstname = Firstnametbx.Text,
                lastname = Lastnametbx.Text,
                middlename = Middlenametbx.Text,
                age = int.Parse(Agetbx.Text),
                sex = Sextbx.Text,
                campus = Campustbx.Text,
                department = Departmenttbx.Text,
                course = Coursetbx.Text,
                major = Majortbx.Text,
                status = Statustbx.Text,
                year = int.Parse(Yeartbx.Text),
            };

            // Call the method to add personal info
            await AddPersonalInfoAsync(personalInfo);
            Reset();
            await LoadPersonalInfoAsync();

        }

        private  void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0 && UserDGV.Columns[e.ColumnIndex].Name == "firstname")
            {
                var studentid = int.Parse(UserDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                var firstname = UserDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                var lastname = UserDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                var middlename = UserDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                var age = UserDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                var sex = UserDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                var campus = UserDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
                var department = UserDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
                var course = UserDGV.Rows[e.RowIndex].Cells[8].Value.ToString();
                var major = UserDGV.Rows[e.RowIndex].Cells[9].Value.ToString();
                var status = UserDGV.Rows[e.RowIndex].Cells[10].Value.ToString();
                var year = UserDGV.Rows[e.RowIndex].Cells[11].Value.ToString(); 

                try
                {
                    Firstnametbx.Text = firstname;
                    Lastnametbx.Text = lastname;
                    Middlenametbx.Text = middlename;
                    Agetbx.Text = age;
                    Sextbx.Text = sex;
                    Campustbx.Text = campus;
                    Departmenttbx.Text = department;
                    Coursetbx.Text = course;
                    Majortbx.Text = major;
                    Statustbx.Text = status;
                    Yeartbx.Text = year;
                    lblId.Text = studentid.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private async Task UpdatePersonalInfoAsync(int personalId, PersonalInfos personalInfo)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the API endpoint
                    string apiUrl = $"http://localhost:3000/api/personal-info/{personalId}";

                    // Serialize the personal info object to JSON
                    string jsonContent = JsonConvert.SerializeObject(personalInfo);

                    // Create the content object with the JSON payload
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send the PUT request
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    // Ensure the response status is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Optionally, you can deserialize the response if needed
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    // Display success message
                    MessageBox.Show($"Personal info updated successfully for ID: {personalId}");
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show($"Error updating personal information: {httpRequestException.Message}");
                }
            }
        }

        private async void Updatebtn_Click(object sender, EventArgs e)
        {
           
            int personalId = int.Parse(lblId.Text); 
            var personalInfo = new PersonalInfos
            {
                firstname = Firstnametbx.Text,
                lastname = Lastnametbx.Text,
                middlename = Middlenametbx.Text,
                age = int.Parse(Agetbx.Text),
                sex = Sextbx.Text,
                campus = Campustbx.Text,
                department = Departmenttbx.Text,
                course = Coursetbx.Text,
                major = Majortbx.Text,
                status = Statustbx.Text,
                year = int.Parse(Yeartbx.Text),
            };

            // Call the method to update personal info
            await UpdatePersonalInfoAsync(personalId, personalInfo);
            Reset();
            await LoadPersonalInfoAsync();
        }

        private async Task DeletePersonalInfoAsync(int personalId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the API endpoint
                    string apiUrl = $"http://localhost:3000/api/personal-info/{personalId}";

                    // Send the DELETE request
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    // Ensure the response status is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Optionally, you can deserialize the response if needed
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    // Display success message
                    MessageBox.Show($"Personal info deleted successfully for ID: {personalId}");
                }
                catch (HttpRequestException httpRequestException)
                {
                    MessageBox.Show($"Error deleting personal information: {httpRequestException.Message}");
                }
            }
        }

        private async void Deletebtn_Click(object sender, EventArgs e)
        {
            // Assume you have the personal ID to be deleted
            int personalId = int.Parse(lblId.Text); // Example ID

            // Call the method to delete personal info
            await DeletePersonalInfoAsync(personalId);
            Reset();
            await LoadPersonalInfoAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using DemoAPIClient.Model;

namespace DemoAPIClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Employee objEmp = new Employee();
            objEmp.EmpName = txtName.Text;
            objEmp.Salary =Convert.ToInt32( txtSalary.Text);
            HttpResponseMessage response = await Program.APIClient.PostAsJsonAsync("Employee/AddEmployee",objEmp);
            response.EnsureSuccessStatusCode();
           
        }
        
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee objEmp = new Employee();
            objEmp.EmpId = Convert.ToInt32(txtSearch.Text);
            objEmp.EmpName = txtName.Text;
            objEmp.Salary = Convert.ToInt32(txtSalary.Text);
            HttpResponseMessage response = await Program.APIClient.PostAsJsonAsync("Employee/UpdatePost", objEmp);
            response.EnsureSuccessStatusCode();
        }
       // RequestUri: 'http://localhost:54065/Employee/GetEmployee3
        private async void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await Program.APIClient.GetAsync("Employee/GetEmployee?empId=" + Convert.ToInt32(txtSearch.Text));
                response.EnsureSuccessStatusCode();
                Employee emp = await response.Content.ReadAsAsync<Employee>();
                txtName.Text = emp.EmpName;
                txtSalary.Text = emp.Salary.ToString();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            Employee objEmp = new Employee();
            objEmp.EmpId = Convert.ToInt32(txtSearch.Text);
            
            HttpResponseMessage response = await Program.APIClient.PostAsJsonAsync("Employee/DeletePost", objEmp);
            response.EnsureSuccessStatusCode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnGetall_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage response = await Program.APIClient.GetAsync("Employee/GetEmployees");
                response.EnsureSuccessStatusCode();
               List< Employee> emplist = await response.Content.ReadAsAsync<List<Employee>>();
                dataGridView1.DataSource = emplist;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

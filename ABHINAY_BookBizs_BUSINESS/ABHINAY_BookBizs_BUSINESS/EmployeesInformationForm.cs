using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    public partial class EmployeesInformationForm : Form
    {
        public EmployeesInformationForm()
        {
            InitializeComponent();
        }

        // to clear all the fields
        private void ClearAll()
        {
            textBoxEID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            comboBoxDesignation.SelectedIndex = -1;
            textBoxEmail.Clear();
            textBoxPassword.Clear();
        }
    
        // to logout the user and return to the login form
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        // to exit from the application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // to validate the input fields and add hte details to the text file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Employees aEmps = new Employees();
            if ((EmployeesValidator.IsValidID(textBoxEID)) && (EmployeesValidator.IsValidField(textBoxFirstName)) && (EmployeesValidator.IsValidField(textBoxLastName)) && (EmployeesValidator.IsValidField(textBoxEmail)) && (EmployeesValidator.IsValidField(textBoxPassword)) && (EmployeesValidator.IsValidEmail(textBoxEmail)))
            {
                aEmps.EmployeeID = Convert.ToInt32(textBoxEID.Text);
                aEmps.FirstName = textBoxFirstName.Text;
                aEmps.LastName = textBoxLastName.Text;
                aEmps.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                aEmps.Email = textBoxEmail.Text;
                aEmps.Designation = comboBoxDesignation.Text;
                aEmps.Password = textBoxPassword.Text;

                EmployeesDA.Add(aEmps);
                ClearAll();
            }
        }

        // to list all the details from the text file to list view
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewEmployees.Items.Clear();
            EmployeesDA.ListEmployees(listViewEmployees);
        }

        // to delete the Employee from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            EmployeesDA.Delete(Convert.ToInt32(textBoxEID.Text));
            MessageBox.Show("Employee Deleted Successfully");
            ClearAll();
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case 0:
                    labelInputInfo.Text = "Please Obtain the EmployeeID";
                    textBoxInputInfo.Focus();
                    break;
                default: break;
            }
        }

        //to search and display the emplloyee from the text file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Employees emps = EmployeesDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (emps != null)
                    {
                        textBoxEID.Text = emps.EmployeeID.ToString();
                        textBoxFirstName.Text = emps.FirstName;
                        textBoxLastName.Text = emps.LastName;
                        maskedTextBoxPhoneNumber.Text = emps.PhoneNumber;
                        textBoxEmail.Text = emps.Email;
                        comboBoxDesignation.Text = emps.Designation;
                        textBoxPassword.Text = emps.Password;
                    }
                    else
                    {
                        MessageBox.Show("Author Not Found");
                        textBoxInputInfo.Clear();
                        textBoxInputInfo.Focus();
                    }
                    break;
            }
        }

        // to navigate to User Informatyion Form
        private void buttonUserInformationForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInformationForm userInformationForm = new UserInformationForm();
            userInformationForm.ShowDialog();
        }

        
    }
}

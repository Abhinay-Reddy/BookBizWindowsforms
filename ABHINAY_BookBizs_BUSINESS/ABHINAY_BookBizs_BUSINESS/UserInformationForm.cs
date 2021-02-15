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
    public partial class UserInformationForm : Form
    {
        public UserInformationForm()
        {
            InitializeComponent();
        }

        // to clear all the fields and reset in the form
        private void ClearAll()
        {
            textBoxUserID.Clear();
            textBoxUserName.Clear();
            comboBoxDesignation.SelectedIndex = -1;
            textBoxPassword.Clear();
        }

        // to logout from the application and navigate back to the login form
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

        // to validate all the fields in the form and then add the data to the text file accordingly
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Users aUser = new Users();
            if ((UserValidator.IsValidID(textBoxUserID)) && UserValidator.IsValidField(textBoxUserName) && UserValidator.IsValidField(textBoxPassword))
            {
                aUser.UserID = Convert.ToInt32(textBoxUserID.Text);
                aUser.UserName = textBoxUserName.Text;
                aUser.Designation = comboBoxDesignation.Text;
                aUser.Password = textBoxPassword.Text;

                UsersDA.Add(aUser);
                ClearAll();
            }
        }

        // to list the data present in the text file to list view table respectively
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewUser.Items.Clear();
            UsersDA.ListUsers(listViewUser);
        }

        // to delete a User from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            UsersDA.Delete(Convert.ToInt32(textBoxUserID.Text));
            MessageBox.Show("User Deleted Successfully");
            ClearAll();
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case 0:
                    labelInputInfo.Text = "Please Obtain the UserID";
                    textBoxInputInfo.Focus();
                    break;
                default: break;
            }
        }

        // to search for a particualr user from the text file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Users users = UsersDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (users != null)
                    {
                        textBoxUserID.Text = users.UserID.ToString();
                        textBoxUserName.Text = users.UserName;
                        comboBoxDesignation.Text = users.Designation;
                        textBoxPassword.Text = users.Password;
                    }
                    else
                    {
                        MessageBox.Show("User Not Found");
                        textBoxInputInfo.Clear();
                        textBoxInputInfo.Focus();
                    }
                    break;
            }
        }

        // to navigate to Employee Information from from User Information Form
        private void buttonEmployeeInformationForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeesInformationForm employeesInformationForm = new EmployeesInformationForm();
            employeesInformationForm.ShowDialog();
        }
    }
}

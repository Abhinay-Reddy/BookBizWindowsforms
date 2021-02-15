using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ABHINAY_BookBizs_BUSINESS
{
    public partial class AuthorInformationForm : Form
    {
        List<Author> listA = new List<Author>();
       
        public AuthorInformationForm()
        {
            InitializeComponent();
        }

        // to list the authors from the text file to view list
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewAuthor.Items.Clear();
            AuthorDA.ListAuthors(listViewAuthor);
        }

        // to delete an author from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            AuthorDA.Delete(Convert.ToInt32(textBoxAuthorID.Text));
            MessageBox.Show("Author Deleted Successfully");
            ClearAll();
        }

        // to clear all the fields in the form
        private void ClearAll()
        {
            textBoxAuthorID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxPassword.Clear();
        }

        // to search for an author from the text file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Author auths = AuthorDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if(auths != null)
                    {
                        textBoxAuthorID.Text = auths.AuthorID.ToString();
                        textBoxFirstName.Text = auths.FirstName;
                        textBoxLastName.Text = auths.LastName;
                        textBoxEmail.Text = auths.Email;
                        textBoxDesignation.Text = auths.Designation;
                        textBoxPassword.Text = auths.Password;
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

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case 0:
                    labelInputInfo.Text = "Please Obtain the AuthorID";
                    textBoxInputInfo.Focus();
                    break;
                default: break;
            }
        }

        // to logout the user
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

        // to validate the fields in the form and input the data to the text file
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            Author aAuthor = new Author();
            if ((AuthorValidator.IsValidID(textBoxAuthorID)) && (AuthorValidator.IsValidField(textBoxFirstName)) && (AuthorValidator.IsValidEmail(textBoxEmail)) && (AuthorValidator.IsValidField(textBoxLastName)) && (AuthorValidator.IsValidField(textBoxPassword)))
            {
                aAuthor.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                aAuthor.FirstName = textBoxFirstName.Text;
                aAuthor.LastName = textBoxLastName.Text;
                aAuthor.Email = textBoxEmail.Text;
                aAuthor.Designation = textBoxDesignation.Text;
                aAuthor.Password = textBoxPassword.Text;

                AuthorDA.Add(aAuthor);
                ClearAll();
            }
        }

       
    }
}

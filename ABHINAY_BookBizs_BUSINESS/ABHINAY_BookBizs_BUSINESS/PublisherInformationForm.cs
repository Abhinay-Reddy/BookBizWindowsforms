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
    public partial class PublisherInformationForm : Form
    {
        public PublisherInformationForm()
        {
            InitializeComponent();
        }

        // to clear and reset all the fields in the form
        private void ClearAll()
        {
            textBoxPublisherID.Clear();
            textBoxName.Clear();
            textBoxEmail.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxBookPublished.Clear();
            textBoxPassword.Clear();
        }

        // to validate the fields in the form and then add the data to the text file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Publisher aPublisher = new Publisher();
            if ((PublisherValidator.IsValidID(textBoxPublisherID)) && (PublisherValidator.IsValidField(textBoxName)) && (PublisherValidator.IsValidEmail(textBoxEmail)) && (PublisherValidator.IsValidField(textBoxBookPublished)) && (PublisherValidator.IsValidField(textBoxDesignation)) && (PublisherValidator.IsValidField(textBoxPassword)))
            {
                aPublisher.PublisherID = Convert.ToInt32(textBoxPublisherID.Text);
                aPublisher.Name = textBoxName.Text;
                aPublisher.Email = textBoxEmail.Text;
                aPublisher.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                aPublisher.BookPublished = textBoxBookPublished.Text;
                aPublisher.Designation = textBoxDesignation.Text;
                aPublisher.Password = textBoxPassword.Text;

                PublisherDA.Add(aPublisher);
                ClearAll();
            }
        }

        // to read the textfile and list the data from the text file to list view table accordingly
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewPublisher.Items.Clear();
            PublisherDA.ListPublisher(listViewPublisher);
        }

        // to delete a publisher from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            PublisherDA.Delete(Convert.ToInt32(textBoxPublisherID.Text));
            MessageBox.Show("Publisher Deleted Successfully");
            ClearAll();
        }

        // to search a particular publisher from the tet file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Publisher publisher = PublisherDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (publisher != null)
                    {
                        textBoxPublisherID.Text = publisher.PublisherID.ToString();
                        textBoxName.Text = publisher.Name;
                        textBoxEmail.Text = publisher.Email;
                        maskedTextBoxPhoneNumber.Text = publisher.PhoneNumber;
                        textBoxBookPublished.Text = publisher.BookPublished;
                        textBoxDesignation.Text = publisher.Designation;
                        textBoxPassword.Text = publisher.Password;
                    }
                    else
                    {
                        MessageBox.Show("Publisher Not Found");
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

        // to logout from the application and navigate back to the login page
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
    }
}

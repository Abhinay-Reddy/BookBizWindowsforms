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
    public partial class ClientInformationForm : Form
    {
        public ClientInformationForm()
        {
            InitializeComponent();
        }

        // to clear all the fields in the form
        private void ClearAll()
        {
            textBoxCID.Clear();
            textBoxName.Clear();
            textBoxCreditLimit.Clear();
            textBoxStreet.Clear();
            textBoxCity.Clear();
            textBoxCity.Clear();
            textBoxPostalCode.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxFaxNumber.Clear();
            textBoxPassword.Clear();
        }

        //to logout the user and navigate back to login page
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

        // to validate the fields in the forms and add the details to the text file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Client aClient = new Client();

            if (ClientValidator.IsValidID(textBoxCID) && ClientValidator.IsValidField(textBoxName) && ClientValidator.IsValidField(textBoxCreditLimit) && ClientValidator.IsValidField(textBoxStreet) && ClientValidator.IsValidField(textBoxCity) && ClientValidator.IsValidField(textBoxPostalCode) && ClientValidator.IsValidField(textBoxDesignation) && ClientValidator.IsValidField(textBoxPassword) && ClientValidator.IsValidField(textBoxFaxNumber) && ClientValidator.IsValidNumber(textBoxFaxNumber) && ClientValidator.IsValidNumber(textBoxFaxNumber) && ClientValidator.IsValidNumber(textBoxCreditLimit))
            {
                aClient.ClientID = Convert.ToInt32(textBoxCID.Text);
                aClient.Name = textBoxName.Text;
                aClient.CreditLimit = Convert.ToInt32(textBoxCreditLimit.Text);
                aClient.Street = textBoxStreet.Text;
                aClient.City = textBoxCity.Text;
                aClient.PostalCode = textBoxPostalCode.Text;
                aClient.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                aClient.FaxNumber = Convert.ToInt32(textBoxFaxNumber.Text);
                aClient.Designation = textBoxDesignation.Text;
                aClient.Password = textBoxPassword.Text;

                ClientDA.Add(aClient);
                ClearAll();
            }
        }

        // to read the data from the text file and display in the list view table
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewClient.Items.Clear();
            ClientDA.ListClients(listViewClient);
        }

        // to delete a particular Client from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ClientDA.Delete(Convert.ToInt32(textBoxCID.Text));
            MessageBox.Show("Client Deleted Successfully");
            ClearAll();
        }

        // to search the client from the text file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Client clients = ClientDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (clients != null)
                    {
                        textBoxCID.Text = clients.ClientID.ToString();
                        textBoxName.Text = clients.Name;
                        textBoxCreditLimit.Text = clients.CreditLimit.ToString();
                        textBoxStreet.Text = clients.Street;
                        textBoxCity.Text = clients.City;
                        textBoxPostalCode.Text = clients.PostalCode;
                        maskedTextBoxPhoneNumber.Text = clients.PhoneNumber;
                        textBoxFaxNumber.Text = clients.FaxNumber.ToString();
                        textBoxDesignation.Text = clients.Designation;
                        textBoxPassword.Text = clients.Password;
                    }
                    else
                    {
                        MessageBox.Show("Client Not Found");
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
                    labelInputInfo.Text = "Please Obtain the CLient ID";
                    textBoxInputInfo.Focus();
                    break;
                default: break;
            }
        }
    }
}

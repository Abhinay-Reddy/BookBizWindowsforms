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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login users = LoginDA.Search(Convert.ToInt32(textBoxUserID.Text),textBoxPassword.Text) ;

            // login the user and redirecting to the forms he is eligible to access
            if (users != null)
            {
                if(users.Designation == "MIS Manager")
                {
                    this.Hide();
                    EmployeesInformationForm employeesInformationForm = new EmployeesInformationForm();
                    employeesInformationForm.ShowDialog();
                }    
                else if(users.Designation == "Sales Manager")
                {
                    this.Hide();
                    ClientInformationForm clientInformationForm = new ClientInformationForm();
                    clientInformationForm.ShowDialog();
                }
                else if (users.Designation == "Inventory Controller")
                {
                    this.Hide();
                    BookInformationForm bookInformationForm = new BookInformationForm();
                    bookInformationForm.ShowDialog();
                }
                else if (users.Designation == "Publishers Manager")
                {
                    this.Hide();
                    PublisherInformationForm publisherInformationForm = new PublisherInformationForm();
                    publisherInformationForm.ShowDialog();
                    
                }
                else if (users.Designation == "Authors Manager")
                {
                    this.Hide();
                    AuthorInformationForm authorInformationForm = new AuthorInformationForm();
                    authorInformationForm.ShowDialog();
                }
                else
                {
                    this.Hide();
                    BooksAuthorPublisherViewForm booksAuthorPublisherViewForm = new BooksAuthorPublisherViewForm();
                    booksAuthorPublisherViewForm.ShowDialog();
                }
            }
            // if the user details are incorrect, it asks to enter the right details to login and access the forms according to his designation eligibility
            else
            {
                MessageBox.Show("User Details Incorrect! Try Again");
                textBoxUserID.Focus();
            }
        }

        // to exit from the application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class BooksAuthorPublisherViewForm : Form
    {
        public BooksAuthorPublisherViewForm()
        {
            InitializeComponent();
        }

        // As the form loads, we call the methods to load data into the respective list view
        private void BooksAuthorPublisherViewForm_Load(object sender, EventArgs e)
        {
            BookDA.ListBooks(listViewBooks);
            PublisherDA.ListPublisher(listViewPublishers);
            AuthorDA.ListAuthors(listViewAuthors);
        }

        //To logout user
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        // to exit the application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

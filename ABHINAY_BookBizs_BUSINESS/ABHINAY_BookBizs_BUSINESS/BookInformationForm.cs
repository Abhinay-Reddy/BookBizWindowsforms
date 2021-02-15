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
    public partial class BookInformationForm : Form
    {
        public BookInformationForm()
        {
            InitializeComponent();
        }

        // to logout the user
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        //to exit from the application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //to clear all the fields in the form
        private void ClearAll()
        {
            textBoxISBN.Clear();
            textBoxTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxYearPublished.Clear();
            textBoxQOH.Clear();
            textBoxAuthor.Clear();
            textBoxPublisher.Clear();
        }

        //to validate the input fields and add it to the file
        private void buttonAdd_Click(object sender, EventArgs e)
        {
           if ((BookValidator.IsValidID(textBoxISBN)) && (BookValidator.IsValidField(textBoxTitle)) && (BookValidator.IsValidField(textBoxUnitPrice)) && (BookValidator.IsValidField(textBoxYearPublished)) && (BookValidator.IsValidField(textBoxQOH)) && (BookValidator.IsValidField(textBoxAuthor)) && (BookValidator.IsValidField(textBoxPublisher)) && BookValidator.IsValidNumber(textBoxQOH) && BookValidator.IsValidNumber(textBoxUnitPrice) && BookValidator.IsValidNumber(textBoxYearPublished))
            {
                Book aBook = new Book();
                
                aBook.ISBN = Convert.ToInt32(textBoxISBN.Text);
                aBook.Title = textBoxTitle.Text;
                aBook.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text);
                aBook.YearPublished = Convert.ToInt32(textBoxYearPublished.Text);
                aBook.QOH = Convert.ToInt32(textBoxQOH.Text);
                aBook.Author = textBoxAuthor.Text;
                aBook.Publisher = textBoxPublisher.Text; 
                
                BookDA.Add(aBook);
                ClearAll();
            }
        }

        // to list the book information from the text file
        private void buttonList_Click(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();
            BookDA.ListBooks(listViewBook);
        }

        //to delete a record from the text file
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BookDA.Delete(Convert.ToInt32(textBoxISBN.Text));
            MessageBox.Show("Book Deleted Successfully");
            ClearAll();
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case 0:
                    labelInputInfo.Text = "Please Obtain the ISBN";
                    textBoxInputInfo.Focus();
                    break;
                default: break;
            }
        }

        // to search for a book from the text file
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBy.SelectedIndex;

            switch (choice)
            {
                case -1:
                    MessageBox.Show("Please select the Search Option");
                    break;
                case 0:
                    Book books = BookDA.Search(Convert.ToInt32(textBoxInputInfo.Text));
                    if (books != null)
                    {
                        textBoxISBN.Text = books.ISBN.ToString();
                        textBoxTitle.Text = books.Title;
                        textBoxUnitPrice.Text = books.UnitPrice.ToString();
                        textBoxYearPublished.Text = books.YearPublished.ToString();
                        textBoxQOH.Text = books.QOH.ToString();
                        textBoxAuthor.Text = books.Author;
                        textBoxPublisher.Text = books.Publisher;
                    }
                    else
                    {
                        MessageBox.Show("Book Not Found");
                        textBoxInputInfo.Clear();
                        textBoxInputInfo.Focus();
                    }
                    break;
            }
        }
    }
}

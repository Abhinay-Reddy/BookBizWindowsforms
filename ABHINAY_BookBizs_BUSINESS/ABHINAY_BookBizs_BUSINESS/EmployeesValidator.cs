using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ABHINAY_BookBizs_BUSINESS
{
    public class EmployeesValidator
    {
        // to check if the id is 5 digist
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid EmployeeID, must be 5 digits");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }

        // to check if the field is not empty
        public static bool IsValidField(TextBox text)
        {
            if (text.Text == "")
            {
                MessageBox.Show("Field Cannot be empty, Please enter the data");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }

        // to check if the id is unique
        public static bool IsUniqueID(List<Author> listA, int id)
        {
            foreach (Author a in listA)
                if (a.AuthorID == id)
                {
                    MessageBox.Show("Duplicate ID, Please Enter a Unique ID");
                    return false;
                }
            return true;
        }

        // to check if the email is valid
        public static bool IsValidEmail(TextBox Email)
        {
            Regex check = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            bool valid = false;
            valid = check.IsMatch(Email.Text);
            if (valid == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Email Format is incorrect");
                return false;
            }
        }
    }
}

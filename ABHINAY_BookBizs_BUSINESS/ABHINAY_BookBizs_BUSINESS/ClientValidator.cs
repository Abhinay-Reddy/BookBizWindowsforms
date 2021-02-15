using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    public class ClientValidator
    {
        // to check if the id is of 5 digits
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid ClientID, must be 5 digits");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }

        // to check if the field is empty
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

        // to check if the number field contains only number
        public static bool IsValidNumber(TextBox text)
        {
            Regex check = new Regex("^[0-9]");
            bool isValid = check.IsMatch(text.Text);
            if (!isValid)
            {
                MessageBox.Show("Please enter valid  number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }

        // to check if the id is unique
        public static bool IsUniqueID(List<Client> listA, int id)
        {
            foreach (Client a in listA)
                if (a.ClientID == id)
                {
                    MessageBox.Show("Duplicate ID, Please Enter a Unique ID");
                    return false;
                }
            return true;
        }
    }
}

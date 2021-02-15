using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    public class UserValidator
    {
        // to check if the id is of 5 digits
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid UserID, must be 5 digits");
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

        // to check if the id is unique
        public static bool IsUniqueID(List<Users> listU, int id)
        {
            foreach (Users a in listU)
                if (a.UserID == id)
                {
                    MessageBox.Show("Duplicate ID, Please Enter a Unique ID");
                    return false;
                }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class LoginDA
    {   
        // to search for the user from the text file and login by checking his credentials and redirect to the form based on his designation
        private static string filePathUser = Application.StartupPath + @"\User.txt";
        public static Login Search(int userId, string password)
        {
            Login login = new Login();

            StreamReader sReader = new StreamReader(filePathUser);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');

                if ((userId) == Convert.ToInt32(fields[0]) && (password == fields[3]))
                {
                    login.UserID = Convert.ToInt32(fields[0]);
                    login.UserName = fields[1];
                    login.Designation = fields[2];
                    login.Password = fields[3];

                    sReader.Close();

                    return login;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class UsersDA
    {
        private static string filePathUser = Application.StartupPath + @"\User.txt";
        private static string fileTempUser = Application.StartupPath + @"\UserTemp.txt";

        // to add user to the text file
        public static void Add(Users users)
        {
            StreamWriter sWriter = new StreamWriter(filePathUser, true);
            sWriter.WriteLine(users.UserID + "," + users.UserName + "," + users.Designation + "," + users.Password);
            sWriter.Close();
            MessageBox.Show("User Data has been Added Successfully");
        }

        // to list users from the text file
        public static void ListUsers(ListView listViewUser)
        {
            StreamReader sReader = new StreamReader(filePathUser);
            listViewUser.Items.Clear();

            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);

                listViewUser.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search for an user from the text file
        public static Users Search(int userId)
        {
            Users users = new Users();

            StreamReader sReader = new StreamReader(filePathUser);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                if (userId == Convert.ToInt32(fields[0]))
                {
                    users.UserID = Convert.ToInt32(fields[0]);
                    users.UserName = fields[1];
                    users.Designation = fields[2];
                    users.Password = fields[3];

                    sReader.Close();

                    return users;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete from the text file
        public static void Delete(int userId)
        {
            StreamReader sReader = new StreamReader(filePathUser);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempUser, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (userId != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathUser);
            File.Move(fileTempUser, filePathUser);
        }
    }
}

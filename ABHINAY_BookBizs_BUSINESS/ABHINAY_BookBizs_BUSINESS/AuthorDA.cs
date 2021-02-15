using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class AuthorDA
    {
        private static string filePathAuthor = Application.StartupPath + @"\Author.txt";
        private static string fileTempAuthor = Application.StartupPath + @"\AuthorTemp.txt";

        // to add the author
        public static void Add(Author auths)
        {
            StreamWriter sWriter = new StreamWriter(filePathAuthor, true);
            sWriter.WriteLine(auths.AuthorID + "," + auths.FirstName + "," + auths.LastName + "," + auths.Email + "," + auths.Designation + "," + auths.Password);
            sWriter.Close();
            MessageBox.Show("Author Data has been Added Successfully");
        }

        // to list the authors from the text file
        public static void ListAuthors(ListView listViewAuthor)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            listViewAuthor.Items.Clear();

            string line = sReader.ReadLine();
            
            while(line!=null)
            {
                string[] fields = line.Split(',');

                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);

                listViewAuthor.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search from the text file
        public static Author Search(int authId)
        {
            Author auths = new Author();

            StreamReader sReader = new StreamReader(filePathAuthor);
            string line = sReader.ReadLine();

            while(line != null)
            {
                string[] fields = line.Split(',');

                if (authId == Convert.ToInt32(fields[0]))
                {
                    auths.AuthorID = Convert.ToInt32(fields[0]);
                    auths.FirstName = fields[1];
                    auths.LastName = fields[2];
                    auths.Email = fields[3];
                    auths.Designation = fields[4];
                    auths.Password = fields[5];

                    sReader.Close();

                    return auths;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete from the text file
        public static void Delete(int authId)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempAuthor, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (authId != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathAuthor);
            File.Move(fileTempAuthor, filePathAuthor);
        }
    }

}

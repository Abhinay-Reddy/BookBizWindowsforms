using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class BookDA
    {
        private static string filePathBook = Application.StartupPath + @"\Book.txt";
        private static string fileTempBook = Application.StartupPath + @"\BookTemp.txt";

        // to add data to the text file
        public static void Add(Book books)
        {
            StreamWriter sWriter = new StreamWriter(filePathBook, true);
            sWriter.WriteLine(books.ISBN + "," + books.Title + "," + books.UnitPrice + "," + books.YearPublished +"," + books.QOH + "," + books.Author + "," + books.Publisher);
            sWriter.Close();
            MessageBox.Show("Book Data has been Added Successfully"); 
        }

        // to list the data from the text file
        public static void ListBooks(ListView listViewBook)
        {
            StreamReader sReader = new StreamReader(filePathBook);
            listViewBook.Items.Clear();

            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);

                listViewBook.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search the book from the text file
        public static Book Search(int ISBN)
        {
            Book books = new Book();

            StreamReader sReader = new StreamReader(filePathBook);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                if (ISBN == Convert.ToInt32(fields[0]))
                {
                    books.ISBN = Convert.ToInt32(fields[0]);
                    books.Title = fields[1];
                    books.UnitPrice = Convert.ToInt32(fields[2]);
                    books.YearPublished = Convert.ToInt32(fields[3]);
                    books.QOH = Convert.ToInt32(fields[4]);
                    books.Author = fields[5];
                    books.Publisher = fields[6];

                    sReader.Close();

                    return books;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete a book from the text file
        public static void Delete(int ISBN)
        {
            StreamReader sReader = new StreamReader(filePathBook);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempBook, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ISBN != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathBook);
            File.Move(fileTempBook, filePathBook);
        }

    }
}

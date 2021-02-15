using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class PublisherDA
    {
        private static string filePathPublisher = Application.StartupPath + @"\Publisher.txt";
        private static string fileTempPublisher = Application.StartupPath + @"\PublisherTemp.txt";
        
        // to add a publisher to the text file
        public static void Add(Publisher publisher)
        {
            StreamWriter sWriter = new StreamWriter(filePathPublisher, true);
            sWriter.WriteLine(publisher.PublisherID + "," + publisher.Name + "," + publisher.Email + "," + publisher.PhoneNumber + "," + publisher.BookPublished + "," +publisher.Designation + "," + publisher.Password);
            sWriter.Close();
            MessageBox.Show("Publisher Data has been Added Successfully");
        }

        // to list the publishers from the text file
        public static void ListPublisher(ListView listViewPublisher)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            listViewPublisher.Items.Clear();

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

                listViewPublisher.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search for a publisher from the text file
        public static Publisher Search(int publisherId)
        {
            Publisher publisher = new Publisher();

            StreamReader sReader = new StreamReader(filePathPublisher);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                if (publisherId == Convert.ToInt32(fields[0]))
                {
                    publisher.PublisherID = Convert.ToInt32(fields[0]);
                    publisher.Name = fields[1];
                    publisher.Email = fields[2];
                    publisher.PhoneNumber = fields[3];
                    publisher.BookPublished = fields[4];
                    publisher.Designation = fields[5];
                    publisher.Password = fields[6];

                    sReader.Close();

                    return publisher;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete the publisher from the text file
        public static void Delete(int publisherId)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempPublisher, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (publisherId != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathPublisher);
            File.Move(fileTempPublisher, filePathPublisher);
        }
    }
}

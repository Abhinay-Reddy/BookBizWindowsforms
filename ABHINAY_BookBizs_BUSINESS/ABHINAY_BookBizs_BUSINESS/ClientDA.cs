using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class ClientDA
    {
        private static string filePathClient = Application.StartupPath + @"\Client.txt";
        private static string fileTempClient = Application.StartupPath + @"\ClientTemp.txt";
        
        // to add a client to text file
        public static void Add(Client clients)
        {
            StreamWriter sWriter = new StreamWriter(filePathClient, true);
            sWriter.WriteLine(clients.ClientID + "," + clients.Name + "," + clients.CreditLimit + "," + clients.Street + "," + clients.City + "," + clients.PostalCode + "," +clients.PhoneNumber + "," + clients.FaxNumber + "," + clients.Designation + "," + clients.Password);
            sWriter.Close();
            MessageBox.Show("Client Data has been Added Successfully");
        }

        // to list the clients from the text file
        public static void ListClients(ListView listViewClient)
        {
            StreamReader sReader = new StreamReader(filePathClient);
            listViewClient.Items.Clear();

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
                item.SubItems.Add(fields[7]);
                item.SubItems.Add(fields[8]);
                item.SubItems.Add(fields[9]);


                listViewClient.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search for a client from the text file
        public static Client Search(int clientId)
        {
            Client clients = new Client();

            StreamReader sReader = new StreamReader(filePathClient);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                if (clientId == Convert.ToInt32(fields[0]))
                {
                    clients.ClientID = Convert.ToInt32(fields[0]);
                    clients.Name = fields[1];
                    clients.CreditLimit = Convert.ToInt32(fields[2]);
                    clients.Street = fields[3];
                    clients.City = fields[4];
                    clients.PostalCode = fields[5];
                    clients.PhoneNumber = fields[6];
                    clients.FaxNumber = Convert.ToInt32(fields[7]);
                    clients.Designation = fields[8];
                    clients.Password = fields[9];

                    sReader.Close();

                    return clients;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete a client from the text file
        public static void Delete(int clientId)
        {
            StreamReader sReader = new StreamReader(filePathClient);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempClient, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (clientId != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7] + "," + fields[8] + "," + fields[9]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathClient);
            File.Move(fileTempClient, filePathClient);
        }
    }
}

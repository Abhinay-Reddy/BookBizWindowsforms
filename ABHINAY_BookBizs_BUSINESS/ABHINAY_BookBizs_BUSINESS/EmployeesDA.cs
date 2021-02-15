using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ABHINAY_BookBizs_BUSINESS
{
    class EmployeesDA
    {
        private static string filePathEmployees = Application.StartupPath + @"\Employees.txt";
        private static string fileTempEmployees = Application.StartupPath + @"\EmployeesTemp.txt";

        // to add employee data to text file
        public static void Add(Employees emps)
        {
            StreamWriter sWriter = new StreamWriter(filePathEmployees, true);
            sWriter.WriteLine(emps.EmployeeID + "," + emps.FirstName + "," + emps.LastName + "," + emps.PhoneNumber + "," + emps.Email + "," + emps.Designation + "," + emps.Password);
            sWriter.Close();
            MessageBox.Show("Employee Data has been Added Successfully");
        }

        // to list the data fro the text file
        public static void ListEmployees(ListView listViewEmployee)
        {
            StreamReader sReader = new StreamReader(filePathEmployees);
            listViewEmployee.Items.Clear();

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

                listViewEmployee.Items.Add(item);

                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        // to search from the terxt file
        public static Employees Search(int empId)
        {
            Employees emps = new Employees();

            StreamReader sReader = new StreamReader(filePathEmployees);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');

                if (empId == Convert.ToInt32(fields[0]))
                {
                    emps.EmployeeID = Convert.ToInt32(fields[0]);
                    emps.FirstName = fields[1];
                    emps.LastName = fields[2];
                    emps.PhoneNumber = fields[3];
                    emps.Email = fields[4];
                    emps.Designation = fields[5];
                    emps.Password = fields[6];

                    sReader.Close();

                    return emps;
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            return null;
        }

        // to delete an employee from the text file
        public static void Delete(int empId)
        {
            StreamReader sReader = new StreamReader(filePathEmployees);
            string line = sReader.ReadLine();

            StreamWriter sWriter = new StreamWriter(fileTempEmployees, true);

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (empId != Convert.ToInt32(fields[0]))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6]);
                }
                line = sReader.ReadLine(); // to read the next line
            }
            sReader.Close();
            sWriter.Close();

            // Delete old File and replace it with updated data
            File.Delete(filePathEmployees);
            File.Move(fileTempEmployees, filePathEmployees);
        }
    }
}

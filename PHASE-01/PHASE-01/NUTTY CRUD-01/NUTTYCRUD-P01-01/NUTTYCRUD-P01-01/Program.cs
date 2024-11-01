using System;
using System.IO;
using System.Net.Mail;
using File = System.IO.File;

namespace NUTTYCRUD_P01_01
{
    class Program
    {
        
            public static int flag = 0, found = 0, a = 0;
            //Create function
            public class Createclass
            {
            public static void Create()
            {

                int n;
                Console.WriteLine("Enter how many customers data you want to enter :");
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter the customer ID :");
                    string si = Console.ReadLine();
                    int customer_ID = int.Parse(si);
                    searchid(si, 1);

                    Console.WriteLine("Enter the customer name :");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the customer email :");
                    string email = Console.ReadLine();
                    var mail = new MailAddress(email);
                    bool isvalidmail = mail.Host.Contains(".");
                    if (!isvalidmail)
                    {
                        Console.WriteLine("The email is invalid. Try again");
                    }
                    Console.WriteLine("Enter the customer creditperiod :");
                    string s = Console.ReadLine();
                    int credit_period = int.Parse(s);

                    Console.WriteLine("Enter the customer payment balance :");
                    string s1 = Console.ReadLine();
                    int payment_balance = int.Parse(s1);

                    Console.WriteLine("Enter the customer status :");
                    string status = Console.ReadLine();

                    static void searchid(string searchterm, int position)
                    {
                        position--;
                        string[] lines = File.ReadAllLines("cust.csv");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] fields = lines[i].Split(',');
                            if (Recordmatches(searchterm, fields, position))
                            {
                                Console.WriteLine("customer_ID should be unique try again");

                            }
                        }
                    }

                    using (StreamWriter file = new("cust.csv", true))
                    {
                        file.WriteLine(customer_ID + "," + name + "," + payment_balance + "," + email + "," + credit_period + "," + status);
                    }

                    Console.WriteLine("customer details created.");


                    static bool Recordmatches(string searchTerm, string[] record, int positionOfSearchTerm)
                    {
                        if (record[positionOfSearchTerm].Equals(searchTerm))
                        {
                            return true;
                        }
                        return false;

                    }
                }
            }
                //Read function()
                public class Read_class
                {
                    static int flag = 0;
                    static bool Recordmatches(string searchterm, string[] record, int position)//searching in file
                    {
                        if (record[position].Equals(searchterm))
                            return true;
                        return false;
                    }

                    public static void Searchid(string id) 
                    {
                        string[] lines = File.ReadAllLines("cust.csv");
                        for (int j = 0; j < lines.Length; j++)
                        {
                            string[] fields = lines[j].Split(',');
                            if (Recordmatches(id, fields, 0))
                            {
                                Console.WriteLine("\nCustomer record Found");
                                flag++;
                                
                                for (int l = 0; l < 6; l++)
                                {
                                    Console.Write(fields[l] + " ");
                                }
                                Console.Write(" \nEnter y if you want search more:");
                                string w = Console.ReadLine();
                                if (w == "y")
                                {
                                    Readmethod();
                                }

                            }
                        }
                        Console.Write("\nRecord not Found. If you want continue search enter y:");
                        string q = Console.ReadLine();
                        if (q == "y")
                        {
                            Readmethod();
                        }

                    }
                    public static void Readmethod()
                    {
                        try
                        {
                            Console.Write("\n Enter the Customer ID to be displayed:");
                            string CustomerID = Console.ReadLine();
                            Searchid(CustomerID);
                        }
                        catch 
                        {
                            Console.Error.WriteLine("error. Try again.");

                        }
                    }

                    //Update function()
                    public class Update_class
                    {

                        static bool Recordmatches(string searchterm, string[] record, int position)
                        {
                            if (record[position].Equals(searchterm))
                                return true;
                            return false;
                        }
                        public static bool Seaid(string id)
                        {
                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] fields = lines[j].Split(',');
                                if (Recordmatches(id, fields, 0))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        public static void Customeremailconstrains(string email) 
                        {
                            var mail = new MailAddress(email);
                            bool isvalidemail = mail.Host.Contains(".");
                            if (!isvalidemail)
                            {
                                Console.WriteLine("Email is not valid!..  Try again :)  You have " + (2 - a) + "chances");
                                a++;
                                Updatemethod();
                            }
                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] fields = lines[j].Split(',');
                                if (Recordmatches(email, fields, 2))
                                {
                                    Console.WriteLine("Customer Eamil is already available!.. Try with new ID :)  you have " + (2 - a) + "chances left");
                                    a++;
                                    Updatemethod();
                                }
                            }
                        }
                        public static void Customercreditperiodconstraints(int period)
                        {

                            if (!(period > 5 && period < 30))
                            {
                                Console.WriteLine("Customer Credit Period should be between 5-30!.. Try again:)  you have " + (2 - a) + "chances left");
                                a++;
                                Updatemethod();
                            }
                        }
                        public static void Changerecord(string id1, string record, int n)
                        {
                            
                            bool edited = false;
                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] fields = lines[j].Split(',');
                                if (!(fields[0].Equals(id1)))
                                {
                                    AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], "din.csv");
                                }
                                else
                                {
                                    if (!edited)
                                    {
                                        fields[n] = record;
                                        AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], "din.csv");
                                        Console.WriteLine("Edited!....");
                                        edited = true;
                                    }
                                }
                            }
                            File.Delete("cust.csv");
                            File.Move("din.csv", "cust.csv");
                            Console.WriteLine("Edited record");
                            Console.WriteLine("Do you want edit more press y");
                            string se = Console.ReadLine();

                            if (se == "y")
                                Updatemethod();
                           

                        }
                        public static void AddRecord(string CustomerID, string CustomerName, string CustomerEmail, string CustomerCreditPeriod, string CustomerStatus, string CustomerPaymentBalance, string filepath)
                        {

                           using StreamWriter file = new(filepath, true);
                           file.WriteLine(CustomerID + "," + CustomerName + "," + CustomerEmail + "," + CustomerCreditPeriod + "," + CustomerStatus + "," + CustomerPaymentBalance);
                    }
                        public static void Editrecord(string id)
                        {
                           
                            string customerid = Console.ReadLine();
                            Console.Write("\n Enter which part you have to edit \n 1.CustomerName \n 2.CustomerEmail \n 3.CreditPeriod \n 4.status \n 5.Payment Balance");
                            int select = int.Parse(Console.ReadLine());
                            int n = 0;
                            string CustomerEmailNew = "";
                            string newstatus_ = "";
                            switch (select)
                            {
                                case 1:
                                    Console.Write("Enter the new customer name:");
                                    string CustomerNameNew = Console.ReadLine();
                                    n = 1;
                                    Changerecord(customerid, CustomerNameNew, n);
                                    break;

                                case 2:
                                    Console.Write("Enter the new cutomer email:");
                                    CustomerEmailNew = Console.ReadLine();
                                    Customeremailconstrains("");
                                    n = 2;
                                    Changerecord(id, "", n);
                                    break;
                                case 3:
                                    Console.Write("Enter the new customer Credit Period:");
                                    string NewCreditPeriod = Console.ReadLine();
                                    int newcredit = int.Parse(NewCreditPeriod);
                                    if (newcredit != 0)
                                        Customercreditperiodconstraints(newcredit);
                                    n = 3;
                                    Changerecord(id, NewCreditPeriod, n);
                                    break;
                                case 4:
                                    Console.Write("Enter the new customer status:");
                                    newstatus_ = Console.ReadLine();
                                    n = 4;
                                    Changerecord(id, newstatus_, n);
                                    break;

                                case 5:
                                    Console.Write("Enter the new customer payment balance:");
                                    string newpaymentbalance = Console.ReadLine();
                                    n = 5;
                                    Changerecord(id, newpaymentbalance, n);
                                    break;

                                default:
                                    Console.WriteLine("Enter correct option and Try again:)  you have " + (2 - a) + "chances left");
                                    a++;
                                    Updatemethod();
                                    break;
                            }

                        }

                        public static void Updatemethod()
                        {
                            try
                            {
                                if (a < 3)
                                {
                                    Console.Write("\n Enter the customer id to Edit record:");
                                    string CustomerID = Console.ReadLine();
                                    if (Seaid(CustomerID))
                                    {
                                        Editrecord(CustomerID);
                                    }
                                    else
                                    {
                                        Console.Write("\n Record not found!.. try again :) You have" + (2 - a) + "Chances");
                                        Updatemethod();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("You have exceeded your chances");
                                    a = 0;
                                    
                                }
                            }

                            catch 
                            {
                                Console.Error.WriteLine("error. Try again.");
                            }
                        }

                    //Delete function()
                    public class Deleteclass
                    {

                        static bool Recordmatches(string searchterm, string[] record, int position)
                        {
                            if (record[position].Equals(searchterm))
                                return true;
                            return false;
                        }

                        public static void AddRecord(string CustomerID, string CustomerName, string CustomerEmail, string CustomerCreditPeriod, string CustomerStatus, string CustomerPaymentBalance, string filepath)
                        {

                            using StreamWriter file = new(filepath, true);
                            file.WriteLine(CustomerID + "," + CustomerName + "," + CustomerEmail + "," + CustomerCreditPeriod + "," + CustomerStatus + "," + CustomerPaymentBalance);

                        }
                        public static void Deleterecord(string searchterm)
                        {

                            bool deleted = false;

                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] fields = lines[i].Split(',');
                                if (!(Recordmatches(searchterm, fields, 0)) || deleted)
                                {
                                    AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], "dinesh.csv");//storing in tempfile
                                }
                                else
                                {
                                    deleted = true;
                                    Console.WriteLine("\n Deleted");
                                }
                            }
                            File.Delete("cust.csv");
                            File.Move("dinesh.csv", "cust.csv");
                        }
                        public static void Deleteid(string id)
                        {
                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] fields = lines[j].Split(',');
                                if (Recordmatches(id, fields, 0))
                                {
                                    Console.WriteLine("\n Customer record Found \n ");
                                    flag++;
                                    found++;

                                    for (int k = 0; k < 6; k++)
                                    {
                                        Console.Write(fields[k] + " ");
                                    }

                                }

                            }
                            if (found == 0)
                                Console.Write("\nRecord not Found!..");
                            found = 0;
                        }
                        public static void Searid(string id)
                        {
                            string[] lines = File.ReadAllLines("cust.csv");
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] fields = lines[j].Split(',');
                                if (Recordmatches(id, fields, 0))
                                {
                                    Console.WriteLine("\nCustomer record Found \n ");
                                    flag++;
                                    found++;

                                    for (int k = 0; k < 6; k++)
                                    {
                                        Console.Write(fields[k] + " ");
                                    }

                                }
                            }
                            if (found == 0)
                                Console.Write("Record not Found.");
                            found = 0;
                        }
                        public static void Deletemethod()
                        {
                            try
                            {
                                Console.Write("\nEnter the CustomerID to be deleted:");
                                string CustomerID = Console.ReadLine();
                                Searid(CustomerID);
                                if (flag != 0)
                                {
                                    Console.Write("\nEnter y to delete the record:");
                                    string k = Console.ReadLine();
                                    if (k == "y")
                                        Deleterecord(CustomerID);
                                    flag = 0;
                                }
                                Console.Write("\nEnter y if you want to delete more:");
                                string q = Console.ReadLine();
                                if (q == "y")
                                    Deletemethod();
                            }
                            catch
                            {
                                Console.Error.WriteLine(" error. Try again.");
                            }
                        }

                        static void Main(string[] args)
                        {
                        Loop:
                            {
                                string user, pwd;

                                Console.WriteLine("Enter role");
                                string role = Console.ReadLine();
                                Console.Write("Enter the Username :");
                                user = Console.ReadLine();
                                Console.Write("Enter the Password :");
                                pwd = Console.ReadLine();
                                string[] lines = File.ReadAllLines("users.csv");
                                if (role == "admin")
                                {
                                    string[] fields = lines[1].Split(',');
                                    if (!(user.Equals(fields[1]) && pwd.Equals(fields[2])))
                                    {
                                        Console.WriteLine("enter correct username and password");
                                        goto Loop;
                                    }
                                }

                                char c;
                                do
                                {
                                    Console.WriteLine("Which operation would you like to perform");
                                    Console.WriteLine("1. CREATE DOCUMENT (ENTER '1')");
                                    Console.WriteLine("2. READ DOCUMENT (ENTER '2')");
                                    Console.WriteLine("3. UPDATE DOCUMENT (ENTER '3') ");
                                    Console.WriteLine("4. DELETE DOCUMENT (ENTER '4') ");
                                    int n = Convert.ToInt32(Console.ReadLine());

                                    switch (n)
                                    {
                                        case 1:
                                            Create();
                                            break;
                                        case 2:
                                            Searchid("cust.csv");
                                            break;
                                        case 3:
                                            Updatemethod();
                                            break;
                                        case 4:
                                            Deletemethod();
                                            break;
                                        default:
                                            Console.WriteLine("enter valid input");
                                            break;
                                    }
                                    Console.WriteLine("Would You like to perform more operations on file, if yes press'y' otherwise press 'n' ");
                                    c = Convert.ToChar(Console.ReadLine());
                                }
                                while (c == 'y');
                            }
                        }
                    }
                    }
                }
            }
    }
}
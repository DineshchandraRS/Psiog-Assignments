using System;
using System.IO;


namespace NUTTYCRUD_P02_01
{
    class SALES
    {
        public class Createsale
        {
            void checkqos(string itemID, float qos)
            {
                string[] linesofinv = File.ReadAllLines("SALES.csv");
                for (int i = 0; i < linesofinv.Length; i++)
                {
                    string[] dinesh = linesofinv[i].Split(',');
                    if (dinesh[0] == itemID)
                    {
                        float stock = float.Parse(dinesh[2]);
                        if (stock < qos)
                        {
                            Console.WriteLine("quantity of sales less than stock enter correct qos according");
                            Createsales();
                            break;
                        }
                    }

                }
            }

            public void Createsales()
            {
                int n;
                Console.WriteLine("Enter how many sales records you want to enter :");
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter the sales ID :");
                    string sales_id = Console.ReadLine();
                    searchid(sales_id, 1);

                    Console.WriteLine("Enter the sales date within the last 30 days :");
                    DateTime sales_date = DateTime.Parse(Console.ReadLine());
                    DateTime current = DateTime.Now.Date;
                Dinesh:
                    {
                        if (!Datecheck(sales_date))
                        {
                            Console.WriteLine("Please Enter the date with in past 30 days : ");
                            sales_date = DateTime.Parse(Console.ReadLine());
                            goto Dinesh;
                        }
                    }

                    Console.WriteLine("Enter the sales type either wholesale or retailer :");
                    string sales_type = Console.ReadLine();
                    string wholesale, retail = sales_type ;

                    Console.WriteLine("Enter the ITEM ID :");
                    string item_id = Console.ReadLine();
                    searchid(item_id, 1);

                    Console.WriteLine("Enter the customer ID :");
                    string customer_id = Console.ReadLine();
                    searchid(customer_id, 1);

                    Console.WriteLine("enter the quality of sale(QOS) :");
                    float QOS = float.Parse(Console.ReadLine());
                    checkqos(item_id, QOS);
                    Console.WriteLine("Enter the sales value");
                    string salesvalue = Console.ReadLine();

                    static void searchid(string searchterm, int position)
                    {
                        position--;
                        string[] lines = File.ReadAllLines("SALES.csv");
                        string[] line = File.ReadAllLines("SALES.csv");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] fields = lines[i].Split(',');
                            if (Recordmatches(searchterm, fields, position))
                            {
                                Console.WriteLine("item_ID should be unique try again");

                            }
                        }
                    }

                    using (StreamWriter file = new("SALES.csv", true))
                    {
                        file.WriteLine(sales_id + "," + sales_date + "," + sales_type + "," + item_id + "," + customer_id + "," + QOS + "," + salesvalue);
                    }

                    Console.WriteLine("sales details created.");


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
        }



        public static bool Datecheck(DateTime t)
        {
            TimeSpan a = DateTime.Now - t;
            if (a.Days > 30)
            {
                return false;
            }
            Console.WriteLine("Date is valid.");
            return true;
        }

        //Read function()
        public class Readsales
        {
            static int flag = 0;
            static bool Recordmatches(string searchterm, string[] record, int position)
            {
                if (record[position].Equals(searchterm))
                    return true;
                return false;
            }

            public void Searchid(string id)
            {
                string[] lines = File.ReadAllLines("SALES.csv");
                for (int j = 0; j < lines.Length; j++)
                {
                    string[] fields = lines[j].Split(',');
                    if (Recordmatches(id, fields, 0))
                    {
                        Console.WriteLine("\n sales record Found \n ");
                        flag++;
                        for (int k = 0; k < fields.Length; k++)
                        {
                            Console.Write(fields[k] + " ");
                        }
                        Console.Write(" \n Enter y if you want search more:");
                        string w = Console.ReadLine();
                        if (w == "y")
                        {
                            Read_sales();
                        }

                    }

                }
                Console.Write("\n Record not Found!.. If you want continue search enter y:");
                string q = Console.ReadLine();
                if (q == "y")
                {
                    Read_sales();
                }
            }

            public  void Read_sales()
            {
                try
                {
                    Console.Write("\n Enter the sales ID to be displayed :");
                    string salesID = Console.ReadLine();
                    Searchid(salesID);


                }
                catch
                {
                    Console.Error.WriteLine("error. Try again.");

                }
            }

        }
    }
}

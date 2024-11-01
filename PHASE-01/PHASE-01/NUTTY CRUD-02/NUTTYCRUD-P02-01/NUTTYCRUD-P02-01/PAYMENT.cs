using System;
using System.Collections;
using System.IO;

namespace NUTTYCRUD_P02_01
{

    public class Createpayment
    {

        public static float Checkbalance(float payment, string salesid)
        { 

            float returnvalue = 0;

            string[] linesofsales = File.ReadAllLines("sales.csv");
            string customerid = " ";
            for (int i = 0; i < linesofsales.Length; i++)
            {
                string[] fields = linesofsales[i].Split(',');
                if (fields[0].Equals(salesid))
                {
                    customerid = fields[4];
                    break;
                }

            }

            string[] linesofcust = File.ReadAllLines("PAYMENT.csv");
            for (int i = 0; i < linesofcust.Length; i++)
            {
                string[] fields = linesofcust[i].Split(',');
                if (fields[0].Equals(customerid))
                {
                    returnvalue = int.Parse(fields[5]);
                    break;
                }

            }

            return returnvalue;

        }
        public void Create()
        {


            int n;
            Console.WriteLine("Enter how many payment records you want to enter :");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the payment ID :");
                string payment_id = Console.ReadLine();
                searchid(payment_id, 1);

                Console.WriteLine("Enter the payment date within the last 30 days :");
                DateTime payment_date = DateTime.Parse(Console.ReadLine());
                DateTime current = DateTime.Now.Date;
            Loops:
                {
                    if (!Datecheck(payment_date))
                    {
                        Console.WriteLine("Please Enter the date with in past 30 days : ");
                        payment_date = DateTime.Parse(Console.ReadLine());
                        goto Loops;
                    }
                }
                Console.WriteLine("Enter the sales ID :");
                string sales_id = Console.ReadLine();
                searchid(sales_id, 1);

                Console.WriteLine("enter the payment balance :");
                float paybalance = float.Parse(Console.ReadLine());
                paybalance = Checkbalance(paybalance, sales_id);

                static void searchid(string searchterm, int position)
                {
                    position--;
                    string[] lines = File.ReadAllLines("PAYMENT.csv");
                    string[] line = File.ReadAllLines("SALES.csv");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        if (Recordmatches(searchterm, fields, position))
                        {
                            Console.WriteLine("payment_ID should be unique try again");

                        }
                    }

                }

                using (StreamWriter file = new("PAYMENT.csv", true))
                {
                    file.WriteLine(payment_id + "," + payment_date + "," + sales_id + "," + paybalance);
                }

                Console.WriteLine("payment details created.");

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
    }
    //Read function()

    public class Read_payment
    {
        static int flag = 0;
        static bool Recordmatches(string searchterm, string[] record, int position)
        {
            if (record[position].Equals(searchterm))
                return true;
            return false;
        }
        public void Readpayments()
        {

            void Searchid(string id)
            {
                string[] lines = File.ReadAllLines("PAYMENT.csv");
                for (int n = 0; n < lines.Length; n++)
                {
                    string[] fields = lines[n].Split(',');
                    if (Recordmatches(id, fields, 0))
                    {
                        Console.WriteLine("\n payment record Found \n ");
                        flag++;
                        for (int l = 0; l < fields.Length; l++)
                        {
                            Console.Write(fields[l] + " ");
                        }
                        Console.Write(" \n Enter y if you want search more:");
                        string w = Console.ReadLine();
                        if (w == "y")
                        {
                            Read_payments();
                        }
                    }
                }
                Console.Write("\n Record not Found!.. If you want continue enter y:");
                string q = Console.ReadLine();
                if (q == "y")
                {
                    Read_payments();
                }

            }
            void Read_payments()
            {
                try
                {
                    Console.Write("\n Enter the payment ID to be displayed:");
                    string paymentID = Console.ReadLine();
                    Searchid(paymentID);
                }
                catch
                {
                    Console.Error.WriteLine("error.Try again.");
                }
            }

        }


    }

}    


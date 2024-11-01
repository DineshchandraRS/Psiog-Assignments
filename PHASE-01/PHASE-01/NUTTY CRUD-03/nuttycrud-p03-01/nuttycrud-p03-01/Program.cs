using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace nuttycrud_p03_01
{
    class Program
    {
        public static void Stock_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}  Report Title : stock report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();
            string[] rows;
            string[] columns;
            int index = 1;
            Console.WriteLine("index        Item_Id      Item_nmae       stock");
            rows = File.ReadAllLines("inventory.csv");
            while (index < rows.Length)
            {
                columns = rows[index].Split(',');
                Console.WriteLine(index + "             " + columns[0] + "           " + columns[1] + "           " + columns[2]);
                index++;

            }

            Console.Write("---------------------------------------------------------------------------------------------------");
        }

        public static void Customer_report()
        {


            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}  Report Title : customer report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();
            string[] rows;
            string[] columns;
            int index = 1;
            Console.WriteLine("index        Customer_Id      Customer_Name        Status           Payment Balance");
            rows = File.ReadAllLines("Customer.csv");
            while (index < rows.Length)
            {
                columns = rows[index].Split(',');
                Console.WriteLine(index + "             " + columns[0] + "             " + columns[1] + "                " + columns[4] + "             " + columns[5]);
                index++;
            }
            Console.Write("---------------------------------------------------------------------------------------------------");
        }

        public static void Sales_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}   Report Title : sales report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();

            Console.WriteLine("Enter the fromdate within the last 30 days :");
            DateTime from_date = DateTime.Parse(Console.ReadLine());
            DateTime current = DateTime.Now.Date;
        Loops:
            {
                if (!Datecheck(from_date))
                {
                    Console.WriteLine("Please Enter the date with in past 30 days : ");
                    from_date = DateTime.Parse(Console.ReadLine());
                    goto Loops;
                }
            }
            Console.WriteLine("Enter the todate within the last 30 days : ");
            DateTime to_date = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now.Date;
        Biloops:
            {
                if (!Bidatecheck(to_date))
                {
                    Console.WriteLine("please Enter the todate within the last 30 days : ");
                    to_date = DateTime.Parse(Console.ReadLine());
                    goto Biloops;
                }
            }
            bool flag;
            string[] rows;
            string[] columns;
            int index = 1;
            Console.WriteLine("index        sales_Id      sales_Date");
            rows = File.ReadAllLines("sales.csv");

            while (index < rows.Length)
            {
                columns = rows[index].Split(',');
                index++;
                DateTime SalesDate = DateTime.Parse(columns[1]);
                if (from_date <= SalesDate && to_date > SalesDate)
                {
                    // Console.WriteLine("index        sales_Id      sales_Date");
                    Console.WriteLine(index + "             " + columns[0] + "             " + columns[1]);
                    flag = true;
                }
                else
                {

                    flag = false;
                }
            }

            Console.Write("---------------------------------------------------------------------------------------------------");

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

        public static bool Bidatecheck(DateTime t1)
        {
            TimeSpan b = DateTime.Now - t1;
            if (b.Days > 30)
            {
                return false;
            }
            Console.WriteLine("Date is valid");
            return true;
        }

        public static void Selling_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}   Report Title : selling report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();

            Console.WriteLine("Enter the fromdate within the last 30 days :");
            DateTime from_date = new DateTime();
            from_date = DateTime.Parse(Console.ReadLine());
            DateTime current = DateTime.Now.Date;
        Loop:
            {
                if (!Datecheck(from_date))
                {
                    Console.WriteLine("Please Enter the from date with in past 30 days : ");
                    from_date = DateTime.Parse(Console.ReadLine());
                    goto Loop;
                }
            }
            Console.WriteLine("Enter the todate within the last 30 days : ");
            DateTime to_date = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now.Date;
        Biloop:
            {
                if (!Bidatecheck(to_date))
                {
                    Console.WriteLine("please Enter the todate within the last 30 days : ");
                    to_date = DateTime.Parse(Console.ReadLine());
                    goto Biloop;
                }
            }

            bool flag;
            string[] row;
            string[] column;
            int dinesh = 1;
            row = File.ReadAllLines("sale.csv");

            Console.WriteLine("index        sales_Id      sales_Date");
            string lines;
            IDictionary<string, int> myDict = new Dictionary<string, int>();
            using (StreamReader rows = new("sale.csv"))
            {
                while ((lines = rows.ReadLine()) != null)
                {
                    if (myDict.Keys.Contains(lines.Split(',')[3]))
                    {
                        myDict[lines.Split(',')[3]] += 1;
                    }
                    else
                    {
                        myDict.Add(lines.Split(',')[3], 1);
                    }

                }
                myDict = myDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine("top  10 selling items:");
                int index = 1;
                int check = 1;
                foreach (KeyValuePair<string, int> i in myDict)
                {
                    if (check == 11)
                    {
                        while (dinesh < row.Length)
                        {
                            column = row[dinesh].Split(',');
                            DateTime SalesDate = DateTime.Parse(column[1]);
                            dinesh++;
                            if (from_date <= SalesDate && to_date > SalesDate)
                            {
                                // Console.WriteLine("index        sales_Id      sales_Date");
                                Console.WriteLine(dinesh + "            " + column[0] + "             " + SalesDate);

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", index, i.Key);

                    }
                    index++;
                    check++;
                }
            }
            Console.Write("---------------------------------------------------------------------------------------------------");
        }

        public static void Wholesale_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}   Report Title : wholesale report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();

            Console.WriteLine("Enter the fromdate within the last 30 days :");
            DateTime from_date = new DateTime();
            from_date = DateTime.Parse(Console.ReadLine());
            DateTime current = DateTime.Now.Date;
        Loop:
            {
                if (!Datecheck(from_date))
                {
                    Console.WriteLine("Please Enter the from date with in past 30 days : ");
                    from_date = DateTime.Parse(Console.ReadLine());
                    goto Loop;
                }
            }
            Console.WriteLine("Enter the todate within the last 30 days : ");
            DateTime to_date = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now.Date;
        Biloop:
            {
                if (!Bidatecheck(to_date))
                {
                    Console.WriteLine("please Enter the todate within the last 30 days : ");
                    to_date = DateTime.Parse(Console.ReadLine());
                    goto Biloop;
                }
            }


            string wholesale;
            IDictionary<string, int> sale = new Dictionary<string, int>();
            using (StreamReader Whole = new("dineshsale.csv"))
            {
                while ((wholesale = Whole.ReadLine()) != null)
                {
                    if (sale.Keys.Contains(wholesale.Split(',')[4]))
                    {
                        sale[wholesale.Split(',')[4]] += Convert.ToInt32(wholesale.Split(',')[6]);
                    }
                    else
                    {
                        sale.Add(wholesale.Split(',')[4], Convert.ToInt32(wholesale.Split(',')[6]));
                    }

                }
                sale = sale.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine("top 10 wholesale report");
                int index = 1;
                int check = 1;
                foreach (KeyValuePair<string, int> i in sale)
                {
                    if (check == 11)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", index, i.Key);
                    }
                    index++;
                }
            }
            Console.Write("---------------------------------------------------------------------------------------------------");
        }

        public static void Retail_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}   Report Title : retail  report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();

            Console.WriteLine("Enter the fromdate within the last 30 days :");
            DateTime from_date = new DateTime();
            from_date = DateTime.Parse(Console.ReadLine());
            DateTime current = DateTime.Now.Date;
        Loop:
            {
                if (!Datecheck(from_date))
                {
                    Console.WriteLine("Please Enter the from date with in past 30 days : ");
                    from_date = DateTime.Parse(Console.ReadLine());
                    goto Loop;
                }
            }
            Console.WriteLine("Enter the todate within the last 30 days : ");
            DateTime to_date = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now.Date;
        Biloop:
            {
                if (!Bidatecheck(to_date))
                {
                    Console.WriteLine("please Enter the todate within the last 30 days : ");
                    to_date = DateTime.Parse(Console.ReadLine());
                    goto Biloop;
                }
            }
            string retail_customer;
            IDictionary<string, int> sales = new Dictionary<string, int>();
            using (StreamReader Retail = new("dineshsale1.csv"))
            {
                while ((retail_customer = Retail.ReadLine()) != null)
                {
                    if (sales.Keys.Contains(retail_customer.Split(',')[4]))
                    {
                        sales[retail_customer.Split(',')[4]] += Convert.ToInt32(retail_customer.Split(',')[6]);
                    }
                    else
                    {
                        sales.Add(retail_customer.Split(',')[4], Convert.ToInt32(retail_customer.Split(',')[6]));
                    }



                }
                sales = sales.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine("top 10 retail customers");
                int index = 1;
                int check = 1;
                foreach (KeyValuePair<string, int> i in sales)
                {
                    if (check == 11)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", index, i.Key);
                    }
                    index++;
                }
            }
        }

        public static void Paymentoverdue_report()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Report Date and Time :{0}   Report Title : paymentoverdue report", now);
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine();

            Console.WriteLine("Enter the fromdate within the last 30 days :");
            DateTime from_date = DateTime.Parse(Console.ReadLine());
            DateTime current = DateTime.Now.Date;
        Loops:
            {
                if (!Datecheck(from_date))
                {
                    Console.WriteLine("Please Enter the date with in past 30 days : ");
                    from_date = DateTime.Parse(Console.ReadLine());
                    goto Loops;
                }
            }
            Console.WriteLine("Enter the todate within the last 30 days : ");
            DateTime to_date = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now.Date;
        Biloops:
            {
                if (!Bidatecheck(to_date))
                {
                    Console.WriteLine("please Enter the todate within the last 30 days : ");
                    to_date = DateTime.Parse(Console.ReadLine());
                    goto Biloops;
                }
            }
            bool flag;
            string[] rows;
            string[] columns;
            int index = 1;
            Console.WriteLine("index        customer_Id      customer_name      payment overdue");
            rows = File.ReadAllLines("Customer.csv");

            while (index < rows.Length)
            {
                columns = rows[index].Split(',');
                index++;
                DateTime payment_overdue = DateTime.Parse(columns[6]);
                if (from_date <= payment_overdue && to_date >= payment_overdue)
                {
                    // Console.WriteLine("index        sales_Id      sales_Date");
                    Console.WriteLine(index + "             " + columns[0] + "             " + columns[1] + "             " + columns[6]);
                    flag = true;
                }
                else
                {

                    flag = false;
                }
            }

            Console.Write("---------------------------------------------------------------------------------------------------");

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
                    Console.WriteLine("Which report do you want to generate? /n");
                    Console.WriteLine("1.stock report as on current date and time.(Enter '1')");
                    Console.WriteLine("2.Current customer report with Status and Balance Payment details.(Enter '2')");
                    Console.WriteLine("3.Sales report between two dates.(Enter '3')");
                    Console.WriteLine("4.Top 10 selling items report between two dates.(Enter '4')");
                    Console.WriteLine("5.Top 10 wholesale customers report between two dates.(Enter '5')");
                    Console.WriteLine("6.Top 10 retailer customers report between two dates.(Enter '6')");
                    Console.WriteLine("7.Customers who have payment overdue report between two dates.(Enter '7')");
                    int n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            Stock_report();
                            break;
                        
                        case 2:
                            Customer_report();
                            break;

                        case 3:
                            Sales_report();
                            break;

                        case 4:
                            Selling_report();
                            break;

                        case 5:
                            Wholesale_report();
                            break;

                        case 6:
                            Retail_report();
                            break;

                        case 7:
                            Paymentoverdue_report();
                            break;

                        default:

                            Console.WriteLine("Enter the valid input");
                            break;

                    }

                    Console.WriteLine("\nwould you like to generate more reports from file, if yes press 'y' otherwise 'n'");
                    c = Convert.ToChar(Console.ReadLine());
                }
                while (c == 'y');

            }

        }

    }
}
using System.IO;
using System;
using static NUTTYCRUD_P02_01.SALES;

namespace NUTTYCRUD_P02_01
{
    class Program
    {

        static void Main(string[] args)
        {

        Loop:
            {
                string user, password;

                Console.WriteLine("Enter role");
                string role = Console.ReadLine();
                Console.Write("Enter the Username :");
                user = Console.ReadLine();
                Console.Write("Enter the Password :");
                password = Console.ReadLine();
                string[] lines = File.ReadAllLines("users.csv");
                if (role == "admin")
                {
                    string[] fields = lines[1].Split(',');
                    if (!(user.Equals(fields[1]) && password.Equals(fields[2])))
                    {
                        Console.WriteLine("enter correct username and password");
                        goto Loop;
                    }
                   
                        INVENTORY inv = new();
                        inv.Create();
                        Readinventory readinv = new();
                        readinv.Read_nutty();
                        Update_class up = new();
                        up.Updatemethod();
                        Deleteclass del = new();
                        del.Deletemethod();

                }
                if (role == "operator")
                {


                    string[] fields = lines[2].Split(',');
                    if (!(user.Equals(fields[1]) && password.Equals(fields[2])))
                    {
                        Console.WriteLine("enter correct username and password");
                        goto Loop;
                    }

                    SALES.Createsale sale = new();
                    sale.Createsales();
                    Readsales read_ = new();
                    read_.Read_sales();

                    Createpayment pay = new();
                    pay.Create();
                    Read_payment Read_paym = new();
                    Read_paym.Readpayments();

                }

            }

        }

    }
}
   
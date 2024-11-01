using System;
using System.Collections;
using System.IO;

namespace NUTTYCRUD_P02_01
{
    public class INVENTORY
    {

        public static int flag = 0, found = 0, a = 0;

        public void Create()
        {
            int n;
            Console.WriteLine("Enter how many inventory records you want to enter :");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the item ID :");
                string item_id = Console.ReadLine();
                searchid(item_id, 1);

                Console.WriteLine("Enter the item name :");
                string item_name = Console.ReadLine();


                Console.WriteLine("Enter the stock :");
                float stock = float.Parse(Console.ReadLine());


                Console.WriteLine("Enter the price :");
                float price = float.Parse(Console.ReadLine());


                Console.WriteLine("Enter the Discount :");
                float discount = float.Parse(Console.ReadLine());


                static void searchid(string searchterm, int position)
                {
                    position--;
                    string[] lines = File.ReadAllLines("INVENTORY.csv");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] fields = lines[i].Split(',');
                        if (Recordmatches(searchterm, fields, position))
                        {
                            Console.WriteLine("itemid should be unique try again");

                        }
                    }
                }

                using (StreamWriter file = new("INVENTORY.csv", true))
                {
                    file.WriteLine(item_id + "," + item_name + "," + stock + "," + price + "," + discount);
                }

                Console.WriteLine("inventory details created.");

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
    
    //Read function()
   
    public class Readinventory
    {
        public static int flag = 0, found = 0, a = 0;

        static bool Recordmatches(string searchterm, string[] record, int position)
        {
            if (record[position].Equals(searchterm))
                return true;
            return false;
        }


        public void Searchid(string id)
        {
            string[] lines = File.ReadAllLines("INVENTORY.csv");
            for (int j = 0; j < lines.Length; j++)
            {
                string[] fields = lines[j].Split(',');
                if (Recordmatches(id, fields, 0))
                {
                    Console.WriteLine("\nInventory records Found \n ");
                    flag++;
                    for (int k = 0; k < fields.Length; k++)
                    {
                        Console.Write(fields[k] + " ");
                    }
                    Console.Write(" \n Enter y if you want search more:");
                    string w = Console.ReadLine();
                    if (w == "y")
                    {
                        Read_nutty();
                    }

                }

            }
            Console.Write("\n Record not Found!.. If you want continue enter y.");
            string q = Console.ReadLine();
            if (q == "y")
            {
                Read_nutty();
            }

        }

        public void Read_nutty()
        {
            try
            {
                Console.Write("\nEnter the item ID to be displayed:");
                string itemID = Console.ReadLine();
                Searchid(itemID);


            }
            catch 
            {
                Console.Error.WriteLine("there is an error.try again.");

            }
        }


    }


    //update function()
    public class Update_class
    {

        public static int flag = 0, found = 0, a = 0;



        static bool Recordmatches(string searchterm, string[] record, int position)
        {
            if (record[position].Equals(searchterm))
                return true;
            return false;
        }

        public static bool Seaid(string id)
        {
            string[] lines = File.ReadAllLines("INVENTORY.csv");
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

        public void Changerecord(string id1, string record, int n)
        {

            bool edited = false;
            string[] lines = File.ReadAllLines("INVENTORY.csv");
            for (int j = 0; j < lines.Length; j++)
            {
                string[] fields = lines[j].Split(',');
                if (!(fields[0].Equals(id1)))
                {
                    AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], "din.csv");
                }
                else
                {
                    if (!edited)
                    {
                        fields[n] = record;
                        AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], "din.csv");
                        Console.WriteLine("Edited.");
                        edited = true;
                    }
                }
            }
            File.Delete("INVENTORY.csv");
            File.Move("din.csv", "INVENTORY.csv");
            Console.WriteLine("Edited record");
            Console.WriteLine("Do you want edit more press y");
            string s = Console.ReadLine();

            if (s == "y")
                Updatemethod();
        }

        public static void AddRecord(string item_id, string item_name, string stock, string price, string discount, string filepath)
        {

            using StreamWriter file = new(filepath, true);
            file.WriteLine(item_id + "," + item_name + "," + stock + "," + price + "," + discount);
        }

        public void Editrecord(string id)
        {

            string itemid = Console.ReadLine();
            Console.Write("\nEnter which part you have to edit \n 1.itemname \n 2.stock \n 3.price \n 4.discount ");
            int select = int.Parse(Console.ReadLine());
            int n = 0;

            switch (select)
            {
                case 1:
                    Console.Write("Enter the new item name:");
                    string itemNameNew = Console.ReadLine();
                    n = 1;
                    Changerecord(itemid, itemNameNew, n);
                    break;

                case 2:
                    Console.Write("Enter the new stock:");
                    string StockNew = Console.ReadLine();
                    float stocknew = float.Parse(StockNew);
                    n = 2;
                    Changerecord(id, StockNew, n);
                    break;
                case 3:
                    Console.Write("Enter the new Price:");
                    string Price = Console.ReadLine();
                    float price = float.Parse(Price);
                    n = 3;
                    Changerecord(id, Price, n);
                    break;
                case 4:
                    Console.Write("Enter the new Discount:");
                    string Discount = Console.ReadLine();
                    float discount = float.Parse(Discount);
                    n = 4;
                    Changerecord(id, Discount, n);
                    break;
                default:
                    Console.WriteLine("Enter correct option and Try again:)  you have " + (2 - a) + "chances left");
                    a++;
                    Updatemethod();
                    break;
            }

        }

        public void Updatemethod()
        {
                    
            try
            {
                if (a < 3)
                {
                    Console.Write("\n Enter the item id to Edit record:");
                    string itemID = Console.ReadLine();
                    if (Seaid(itemID))
                    {
                        Editrecord(itemID);
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
                    Environment.Exit(0);
                }
            }

            catch
            {
                Console.Error.WriteLine("there is an error!! Try again.");
            }
        }
    }

    //delete function()
    public class Deleteclass
    {

        static int flag = 0, found = 0, a = 0;

        static bool Recordmatches(string searchterm, string[] record, int position)
        {
            if (record[position].Equals(searchterm))
                return true;
            return false;
        }

        public static void AddRecord(string itemID, string itemName, string stock, string price, string discount, string filepath)
        {

            using StreamWriter file = new(filepath, true);
            file.WriteLine(itemID + "," + itemName + "," + stock + "," + price + "," + discount);

        }

        public static void Deleterecord(string searchterm)
        {

            bool deleted = false;
            string[] lines = File.ReadAllLines("INVENTORY.csv");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if (!(Recordmatches(searchterm, fields, 0)) || deleted)
                {
                    AddRecord(fields[0], fields[1], fields[2], fields[3], fields[4], "dinesh.csv");//storing in tempfile
                }
                else
                {
                    deleted = true;
                    Console.WriteLine("\nDeleted");
                }
            }
            File.Delete("INVENTORY.csv");
            File.Move("dinesh.csv", "INVENTORY.csv");
        }

        public void Deleteid(string id)
        {
            string[] lines = File.ReadAllLines("INVENTORY.csv");
            for (int j = 0; j < lines.Length; j++)
            {
                string[] fields = lines[j].Split(',');
                if (Recordmatches(id, fields, 0))
                {
                    Console.WriteLine("\ninventory record Found \n ");
                    flag++;
                    found++;

                    for (int k = 0; k < 6; k++)
                    {
                        Console.Write(fields[k] + " ");
                    }
                    break;
                }

            }
            if (found == 0)
                Console.Write("\nRecord not Found!..");

        }

        public void Searid(string id)
        {
            string[] lines = File.ReadAllLines("INVENTORY.csv");
            for (int j = 0; j < lines.Length; j++)
            {
                string[] fields = lines[j].Split(',');
                if (Recordmatches(id, fields, 0))
                {
                    Console.WriteLine("\ninventory record Found \n ");
                    flag++;
                    found++;

                    for (int k = 0; k < fields.Length; k++)
                    {
                        Console.Write(fields[k] + " ");
                    }

                }
            }
            if (found == 0)
                Console.Write("\nRecord not Found!..");
            found = 0;
        }

        public void Deletemethod()
        {
            try
            {
                Console.Write("\nEnter the itemID to be deleted:");
                string itemID = Console.ReadLine();
                Searid(itemID);
                if (flag != 0)
                {
                    Console.Write("\nEnter y to delete the record:");
                    string k = Console.ReadLine();
                    if (k == "y")
                        Deleterecord(itemID);
                    flag = 0;
                }
                Console.Write("\nEnter y if you want to delete more:");
                string q = Console.ReadLine();
                if (q == "y")
                    Deletemethod();
            }
            catch
            {
                Console.Error.WriteLine();

            }
        }


    }


}
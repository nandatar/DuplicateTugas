using System.Runtime.CompilerServices;
using System;

namespace DuplicateTugas
{
    class Program
    {
        static int id = 0;
        static string[] fn = { };
        static string[] ln = { };
        static string[] pw = { };
        static string[] uname = { };
        static int[] id_user= { };
        int indexUser;

        static void Main(string[] args)
        {
            TampilanUtama();
        }

        static void TampilanUtama()
        {
            Console.WriteLine("==BASIC AUTHENTICATON==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User  ");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User ");
            Console.WriteLine("5. Exit");
            Console.Write("Input : ");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (input)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    ShowUser();
                    break;
            }
        }

        public static void CreateUser()
        {
            Console.Clear();
            Console.Write("First Name: ");
            string f_name = Console.ReadLine();
            Console.Write("Last Name: ");
            string l_name = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            User(f_name, l_name, pass);
            Console.WriteLine("User Success to Created!");
            Console.ReadKey();
            TampilanUtama();
            Console.Clear();
        }

        public static void User(string first_name, string last_name, string password)
        {
            id_user = id_user.Append(id).ToArray();
            fn = fn.Append(first_name).ToArray();
            ln = ln.Append(last_name).ToArray();
            //pw = pw.Append(password).ToArray();
            //uname = (string[])uname.Append(string.Concat(first_name.AsSpan(0,2), last_name.AsSpan(0,2)));
            id++;
        }

        static void ShowUser()
        {
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            for (int i = 0; i < id_user.Length; i++)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("ID\t : " + (i+1));
                Console.WriteLine("Name\t : " + fn[i] + " " + ln[i]);
                //Console.WriteLine("Username\t : " + uname[i]);
                //Console.WriteLine("Password\t : " + pw[i]);
                Console.WriteLine("===================================");
            }
            Console.WriteLine("Menu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            int menu_user;
            menu_user = Convert.ToInt32(Console.ReadLine());
            switch (menu_user)
            {
                case 1:
                    bool edit = false;
                    while (true)
                    {
                        Console.Write("ID yang Ingin Diubah : ");
                        int input_id = Convert.ToInt32(Console.ReadLine());
                        if(input_id != id_user.Length)
                        {
                            Console.WriteLine("User Tidak Ditemukan!");
                            edit = true;
                        }
                        else
                        {
                            Console.Write("First Name\t : ");
                            fn[id - 1] = Console.ReadLine();
                            Console.Write("Last Name\t : ");
                            ln[id - 1] = Console.ReadLine();
                            Console.Write("Password\t : ");
                            pw[id - 1] = Console.ReadLine();
                            Console.WriteLine("User Success to Edited!");
                            edit = false;
                        }
                        if(!edit)
                        {
                            Console.ReadKey();
                            ShowUser();
                            return;
                        }
                    }

            }
        }

    }
}
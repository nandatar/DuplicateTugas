using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DuplicateTugas
{
    class Program
    {
        static int id = 0;
        static int[] ID = { };
        static string[] FirstName = { };
        static string[] LastName = { };
        static string[] UserName = { };
        static string[] Password = { };

        static void Main(string[] args)
        {
            TampilanUtama();
        }

        static void TampilanUtama()
        {
            Console.Clear();
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.Write("Input : ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Create();
                        break;

                    case 2:
                        View();
                        break;

                    case 3:
                        Console.WriteLine("Search User");
                        break;

                    case 4:
                        Console.WriteLine("Login User");
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("ERROR : Input Not Valid");
                        Console.ReadKey();
                        TampilanUtama();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                TampilanUtama();
            }
        }
        static void Create()
        {
            Console.Clear();
            Console.Write("First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            CekPassword(password);
            User(firstname, lastName, password);
            Console.WriteLine("User Success to Created!!!");
            Console.ReadKey();
            TampilanUtama();
        }


        static void User(string firstName, string lastName, string password)
        {
            ID = ID.Append(id).ToArray();
            FirstName = FirstName.Append(firstName).ToArray();
            LastName = LastName.Append(lastName).ToArray();
            UserName = UserName.Append(firstName.Substring(0, 2) + lastName.Substring(0, 2)).ToArray();
            Password = Password.Append(password).ToArray();
            id++;
        }



        static string CekPassword(string password)
        {
            while (true)
            {
                bool flag = true;
                if ((password.Length > 7) && (Enumerable.Any<char>((IEnumerable<char>)password, new Func<char, bool>(char.IsUpper)) && (Enumerable.Any<char>((IEnumerable<char>)password, new Func<char, bool>(char.IsLower)) && Enumerable.Any<char>((IEnumerable<char>)password, new Func<char, bool>(char.IsNumber)))))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("\nPassword must have at least 8 characters\n with at least one Capital letter, at least one lower case letter and at least one number.");
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                    flag = true;
                }
                if (!flag)
                {
                    return password;
                }
            }
        }
        
        static void View()
        {
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            for (int i = 0; i < ID.Length; i++)
            {
                Console.WriteLine("========================");
                Console.WriteLine($"ID	: " + (i+1));
                Console.WriteLine("Name\t: " + FirstName[i] + " " + LastName[i]);
                Console.WriteLine("Username: " + UserName[i]);
                Console.WriteLine("Password: " + Password[i]);
                Console.WriteLine("========================");

            }
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    bool flag = false;
                    while (true)
                    {
                        Console.Write("Id Yang Ingin Diubah : ");
                        int y = Convert.ToInt32(Console.ReadLine());
                        if (y > ID.Length)
                        {
                            Console.WriteLine("User Tidak Ditemukan!!!");
                            flag = true;
                        }
                        else
                        {
                            Console.Write("First Name : ");
                            FirstName[id-1] = Console.ReadLine();
                            Console.Write("Last Name : ");
                            LastName[id-1] = Console.ReadLine();
                            Console.Write("Password : ");
                            Password[id-1] = Console.ReadLine();
                            Console.Write("User Succes to Edited !!! ");
                            flag = false;
                        }
                        if (!flag)
                        {
                            Console.ReadKey();
                            View();
                            return;
                        }
                    }

                case 2:
                    Console.Write("Id Yang Ingin Dihapus : ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    if (x > ID.Length)
                    {
                        Console.WriteLine("User Not Found!!!");
                    }
                    int numToRemove = x;
                    int numIndex = Array.IndexOf(ID, numToRemove);
                    ID = ID.Where((val, idx) => idx != numIndex).ToArray();
                    numIndex = Array.IndexOf(FirstName, numToRemove);
                    FirstName = FirstName.Where((val, idx) => idx != numIndex).ToArray();
                    numIndex = Array.IndexOf(LastName, numToRemove);
                    LastName = LastName.Where((val, idx) => idx != numIndex).ToArray();
                    numIndex = Array.IndexOf(Password, numToRemove);
                    Password = Password.Where((val, idx) => idx != numIndex).ToArray();

                    Console.WriteLine("User Success to Deleted !!!");
                    Console.ReadKey();
                    View();
                    return;

                case 3:
                    TampilanUtama();
                    return;
            }
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            View();
        }


    }
}
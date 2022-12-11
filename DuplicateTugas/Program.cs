using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace DuplicateTugas
{
    class Program
    {
        //deklarasi variabel, 5 Array untuk menyimpan data
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
                        Show();
                        break;

                    case 3:
                        SearchUser();
                        break;

                    case 4:
                        Login();
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
            string new_firstname = CekNama(firstname); //cek nama harus >= 2char
            Console.Write("Last Name: ");
            string lastname = Console.ReadLine();
            string new_lastname = CekNama(lastname); //cek nama harus >= 2char
            Console.Write("Password: ");
            string password = Console.ReadLine();
            string new_password = CekPassword(password); // cek password
            User(new_firstname, new_lastname, new_password);
            Console.WriteLine("User Success to Created!!!");
            Console.ReadKey();
            TampilanUtama();
        }

        //Method User(); untuk menyimpan data pada Array
        static void User(string firstName, string lastName, string password)
        {
            ID = ID.Append(id).ToArray();
            FirstName = FirstName.Append(firstName).ToArray();
            LastName = LastName.Append(lastName).ToArray();
            UserName = UserName.Append(firstName.Substring(0, 2) + lastName.Substring(0, 2)).ToArray();
            Password = Password.Append(password).ToArray();
            id++;
        }

        //method cek firstname lastname >= 2 char
        static string CekNama(string nama)
        {
            bool flag = true;
            while (true)
            {
                if (nama.Length >= 2)
                {
                    flag= false;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Name has to be at least consisting 2 characters or more.");
                    Console.Write("Input : ");
                    nama = Console.ReadLine();
                }
                if (!flag)
                {
                    return nama;
                }
            }
        }

        // cek password lebih dari 7 char && memiliki 1 uppercase,lowercase,dan number
        static string CekPassword(string password)
        {
            bool flag = true;
            while (true)
            {
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
        
        static void Show()
        {
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            //looping show array <= array.length
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
                case 1: //edit
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
                            string firstname = Console.ReadLine();
                            string auth_firstname = CekNama(firstname); //cek nama >= 2 char
                            FirstName[y - 1] = auth_firstname;
                            Console.Write("Last Name: ");
                            string lastname = Console.ReadLine();
                            string auth_lastname = CekNama(lastname); //cek nama >= 2 char
                            LastName[y - 1] = auth_lastname;
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            string auth_password = CekPassword(password); //cek password
                            Password[y - 1] = auth_password;
                            Console.Write("User Succes to Edited !!! ");
                            flag = false;
                        }
                        if (!flag)
                        {
                            Console.ReadKey();
                            Show();
                            return;
                        }
                    }

                case 2: //hapus
                    Console.Write("Id Yang Ingin Dihapus : ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    //cek id exist or not
                    if (x > ID.Length)
                    {
                        Console.WriteLine("User Not Found!!!");
                        Console.ReadKey();
                        Show();
                    }

                    //splicing array dengan list (RemoveAt)
                    List<int> a = new List<int>(ID);
                    a.RemoveAt(x-1);
                    ID = a.ToArray();
                    List<string> b = new List<string>(FirstName);
                    b.RemoveAt(x - 1);
                    FirstName = b.ToArray();
                    List<string> c = new List<string>(LastName);
                    c.RemoveAt(x - 1);
                    LastName = c.ToArray();
                    List<string> d = new List<string>(Password);
                    d.RemoveAt(x - 1);
                    Password = d.ToArray();

                    Console.WriteLine("User Success to Deleted !!!");
                    Console.ReadKey();
                    Show();
                    return;

                case 3: //back to menu
                    TampilanUtama();
                    return;
            }
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Show();
        }

        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();

            //Mencari firstname/lastname dengan Array FindAllIndexOf
            //string[] myarr = new string[] { "s", "f", "s" };
            //int[] v = myarr.Select((b, i) => b == "s" ? i : -1).Where(i => i != -1).ToArray();
            //This will return 0, 2

            //search user dari array firstname dan lastname
            //harus sama persis karna array
            try
            {
                int[] v = FirstName.Select((b, i) => b == name ? i : -1).Where(i => i != -1).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine($"ID	: " + (v[i] + 1));
                    Console.WriteLine("Name\t: " + FirstName[v[i]] + " " + LastName[v[i]]);
                    Console.WriteLine("Username: " + UserName[v[i]]);
                    Console.WriteLine("Password: " + Password[v[i]]);
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    TampilanUtama();
                }
            }
            catch (Exception)
            {
                int[] v = LastName.Select((b, i) => b == name ? i : -1).Where(i => i != -1).ToArray();
                for (int i = 0; i < ID.Length; i++)
                {
                    Console.WriteLine($"ID	: " + (v[i] + 1));
                    Console.WriteLine("Name\t: " + FirstName[v[i]] + " " + LastName[v[i]]);
                    Console.WriteLine("Username: " + UserName[v[i]]);
                    Console.WriteLine("Password: " + Password[v[i]]);
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    TampilanUtama();
                }
            }
            Console.ReadKey();
            TampilanUtama();
        }
        //login (username dan password) mencocokan values array(password) dengan input password
        //nb: index dari input username
        static void Login()
        {
            int index = 0;
            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : ");
            string cekUser = Console.ReadLine();
            Console.Write("PASSWORD : ");
            string cekPassword = Console.ReadLine();
            try
            {
                index = Array.IndexOf(UserName, cekUser); // get index dari input username
                if (cekPassword == Password[index]) // mencocokan password
                {
                    Console.WriteLine("Berhasil Login!");
                    Console.ReadKey();
                    TampilanUtama();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Username atau Password Tidak Ditemukan");
                Console.ReadKey();
                TampilanUtama();
            }
            Console.WriteLine("Username atau Password Tidak Ditemukan");
            Console.ReadKey();
            TampilanUtama();
        }
    }
}

using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace DuplicateTugas
{
    class Program
    {
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
                        Console.WriteLine("Show User");
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
            TampilanUtama();
        }

      
        static void User(string firstName, string lastName, string password)
        {
            string FirstName = firstName;
            string LastName = lastName;
            string UserName = firstName.Substring(0, 2) + lastName.Substring(0, 2);
            string Password = password;
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
     
           
        }





        private void ShowUser()
        {

        }


    }
}
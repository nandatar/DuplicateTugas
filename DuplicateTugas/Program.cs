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
            Console.WriteLine("==BASIC AUTHENTICATON==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User  ");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User ");
            Console.WriteLine("5. Exit");
            Console.Write("Input : ");
            int input =Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Coba");
        }
    }
}
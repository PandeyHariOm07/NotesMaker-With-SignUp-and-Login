using NotesMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserAuthentication userAuthentication = new UserAuthentication();
            Console.WriteLine("Enter Email Id");
            string email = Console.ReadLine();
            Console.WriteLine("Enter UserName");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            int answer = userAuthentication.SignUp(email,user,password);
            if (answer != 1)
            {
                Console.WriteLine("SignUp Failed");
            }
            else
            {
                Console.WriteLine("User Created");
            }
        }
    }
}

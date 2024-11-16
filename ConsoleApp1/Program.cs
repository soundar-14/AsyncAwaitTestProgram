using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyNamespace
{
    public class FirstClass
    {
        static FirstClass()
        {
            Console.WriteLine("1st static Ctr");
        }

        public FirstClass()
        {
            Console.WriteLine("1st Ctr");
        }
        public FirstClass(int i, int o) {
            Console.WriteLine("1st Ctr with param");
        }

        public void FirstMethod()
        {
            Console.WriteLine("1st mtd");
        }
    }

    public class SecondClass : FirstClass
    {
        static SecondClass()
        {
            Console.WriteLine("2st static Ctr");
        }
        public SecondClass():base(1, 2)
        {
            Console.WriteLine("2st Ctr");
        }

        public virtual void SecondMethod()
        {
            Console.WriteLine("2st mtd");
        }
    }

    public class ThirdClass : SecondClass 
    {
        static ThirdClass()
        {
            Console.WriteLine("3st static Ctr");
        }
        public ThirdClass()
        {
            Console.WriteLine("3st Ctr");
        }

        public void ThirdMethod()
        {
            Console.WriteLine("3st mtd");
        }
    }

    public class ForthClass 
    {
        static ForthClass()
        {
            Console.WriteLine("4st static Ctr");
        }
        private ForthClass()
        {
            Console.WriteLine("4st Ctr");
        }

        public ForthClass(int i)
        {
            Console.WriteLine("4st Ctr with param");
        }

        public void ForthMethod()
        {
            Console.WriteLine("4st mtd");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
           SecondClass thirdClass = new SecondClass();
           ForthClass fourthClass = new ForthClass(1);

           thirdClass.SecondMethod();
           //Console.WriteLine(String.Join(',', args));
           Console.ReadLine();
        }
    }
}

//namespace MyNamespace
//{
//    public class Program
//    {
//        private static IList<User> _users = new List<User>();
//        public static void Main(string[] args)
//        {
//            Start();
//            Process();
//            Stop();
//        }

//        private static void Start()
//        {
//            Console.WriteLine("Welcome to User Portal!");
//            Console.WriteLine("----------------------------------------\n");
//        }

//        private static void Stop()
//        {
//            Console.WriteLine("Thank you for your time, Welcome back!");
//            Console.WriteLine("----------------------------------------\n");
//        }

//        private static void Process()
//        {
//            bool isProcessing = true;
//            while (isProcessing)
//            {
//                Console.WriteLine("Kindly follow the below key's to process!");
//                Console.WriteLine("1. Add User \n2. Delete User  \n3. Show All Users  \n4. Exit \n");
//                Console.WriteLine("Kindly enter the key to process:");

//                string key = Console.ReadLine();

//                switch (key)
//                {
//                    case "1":
//                        AddUser();
//                        break;
//                    case "2":
//                        DeleteUser();
//                        break;
//                    case "3":
//                        ShowAllUsers();
//                        break;
//                    case "4":
//                    default:
//                        isProcessing = false;
//                        break;
//                }
//                Console.WriteLine("\nThank you for the details.");
//                Console.WriteLine("=========================================\n\n");
//            }
//        }

//        private static void ShowAllUsers()
//        {
//            foreach (var user in _users)
//            {
//                Console.WriteLine($"{user.Name} is {user.Age} years old.");
//            };
//        }

//        private static void AddUser()
//        {
//            Console.WriteLine("Enter your name:");
//            string userName = Console.ReadLine();
//            Console.WriteLine("Enter your age:");
//            string age = Console.ReadLine(); ;
//            _users.Add(new User { Name = userName, Age = int.Parse(age) });
//        }

//        private static void DeleteUser()
//        {
//            Console.WriteLine("Enter name to delete:");
//            string userName = Console.ReadLine();
//            _users.Remove(_users.FirstOrDefault(p => p.Name == userName));
//        }
//    }

//    class User
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }
//    }
//}

// Welcome to User Portal
// ----------------------------------------
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 1
//  
// Enter your name:
// Ashok
//  
// Enter your age:
// 26
//  
// Thank you for the details.
// =========================================
//  
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 1
//  
// Enter your name:
// Sarathi
//  
// Enter your age:
// 27
//  
// Thank you for the details.
// =========================================
//  
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 3
//  
// List
// ++++++++++++++++
// Ashok is 26 years old.
// Sarathi is 27 years old.
// ++++++++++++++++
//  
// Thank you for the details.
// =========================================
//  
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 2
//  
// Enter name to delete:
// Ashok
//  
// Thank you for the details.
// =========================================
//  
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 3
//  
// List
// ++++++++++++++++
// Sarathi is 27 years old.
// ++++++++++++++++
//  
// Thank you for the details.
// =========================================
//  
//  
// Kindly follow the below key's to process
// 1. Add User
// 2. Delete User
// 3. Show All Users
// 4. Exit
//  
// Kindly enter the key to process:
// 4
//  
// Thank you for your time, Welcome back.
// ----------------------------------------
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using TaskDay4.Models;
using TaskDay4.Repository;

namespace TaskDay4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User Details");
            UserRepository userRepository = new UserRepository();
            Console.WriteLine("Select the options");
            Console.WriteLine("\t1 - Add User\n\t2 - Remove User\n\t3 - Get User\n\t4 - Get All Users\n\t5 - Active Users");
            Console.WriteLine("Enter the choice");
            try
            {
                int option = int.Parse(Console.ReadLine());
                do
                {
                    if (option == 1)
                    {
                        AddUser(userRepository);
                    }
                    else if (option == 2)
                    {
                        RemoveUser(userRepository);
                    }
                    else if (option == 3)
                    {
                        GetUserDetail(userRepository);
                    }
                    else if (option == 4)
                    {
                        GetAllUsers(userRepository);
                    }
                    else if (option == 5)
                    {
                        ActiveUsers(userRepository);
                    }
                    Console.WriteLine("Select the options");
                    Console.WriteLine("\t1 - Add User\n\t2 - Remove User\n\t3 - Get User\n\t4 - Get All Users\n\t5 - Active Users");
                    Console.WriteLine("Enter the choice");
                    option = int.Parse(Console.ReadLine());

                } while (option >= 1 && option <= 5);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Please check your input");
            }

            //AddUser(userRepository);
            //GetAllUsers(userRepository);
            //GetUserDetail(userRepository);
            //RemoveUser(userRepository);
            //ActiveUsers(userRepository);

        }

        private static void AddUser(UserRepository userRepository)
        {
            Console.WriteLine("\nEnter the User details to add");
            Console.WriteLine("Enter the name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Location");
            string location = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the User active status");
            Console.WriteLine("0 - inactive \t 1 - active");
            int activeStatus = int.Parse(Console.ReadLine());
            bool status = activeStatus == 0 ? false : true;

            var users = userRepository.AddUser(new User()
            {
                Name = userName,
                Email = email,
                Location = location,
                Address = address,
                IsActive = status
            });
            Console.WriteLine("UserID \t Name \t Email \t Location \t Address \t IsActive");
            foreach (var user in users)
            {
                Console.WriteLine(user.Id+"\t"+user.Name + "\t" + user.Email + "\t" + user.Location + "\t" + user.Address + "\t" + user.IsActive);
            }
        }

        private static void ActiveUsers(UserRepository userRepository)
        {
            var activeUser = userRepository.ActiveUsers();
            if (activeUser.Count != 0)
            {
                Console.WriteLine("UserID \t Name \t Email \t\t Location \t Address \t IsActive");
                foreach (var user in activeUser)
                {
                    Console.WriteLine(user.Id+"\t"+user.Name + "\t" + user.Email + "\t" + user.Location + "\t" + user.Address + "\t" + user.IsActive);
                }
            }
            else
            {
                Console.WriteLine("No Active User Found");
            }
        }

        private static void RemoveUser(UserRepository userRepository)
        {
            Console.WriteLine("\nEnter the id of user to delete");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var users = userRepository.DeleteUser(id);
                Console.WriteLine("List of user available after deleting");
                if (users.Count != 0)
                {
                    Console.WriteLine("UserID \t Name \t Email \t\t Location \t Address \t IsActive");
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.Id + "\t" + user.Name + "\t" + user.Email + "\t" + user.Location + "\t" + user.Address + "\t" + user.IsActive);
                    }

                }
                else
                {
                    Console.WriteLine("No User is found at id: " + id + "to delete");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Please Check your input. Id is invalid");
            }
            
        }

        private static void GetUserDetail(UserRepository userRepository)
        {
            Console.WriteLine("\nEnter the id to find user\n");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var user = userRepository.GetUser(id);
                if (user != null)
                {
                    Console.WriteLine("UserID \t Name \t Email \t\t Location \t Address \t IsActive");
                    Console.WriteLine(user.Name + "\t" + user.Email + "\t" + user.Location + "\t" + user.Address + "\t" + user.IsActive);
                }
                else
                {
                    Console.WriteLine("No User Found at id: " + id);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nPlease check your input. Id is invalid\n");
            }
            
        }

        private static void GetAllUsers(UserRepository userRepository)
        {
            var allUsers = userRepository.Users();
            if(allUsers.Count!=0)
            {
                Console.WriteLine("UserID \t Name \t Email \t\t Location \t Address \t IsActive");
                foreach (var user in allUsers)
                {
                    Console.WriteLine(user.Id+"\t"+user.Name + "\t" + user.Email + "\t" + user.Location + "\t" + user.Address + "\t" + user.IsActive);
                }
            }
            else
            {
                Console.WriteLine("No User is found");
            }
            
        }
    }
}

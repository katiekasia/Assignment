using System;
using System.Linq;
using RepositoryContracts;

namespace CLI1.UI.ManageUsers
{
    public class ListUsersView
    {
        private readonly IUserRepository userRepository;

        public ListUsersView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ListUsers()
        {
            var manageUsers = new ManageUsersView(userRepository);

            Console.Clear();
            Console.WriteLine("#-------------  ALL USERS PAGE  ---------------#");
            Console.WriteLine("---------------------------------------------------");
            
            var users = userRepository.GetMany().ToList();
            
            if (!users.Any())
            {
                Console.WriteLine("No users found.");
            }
            
            foreach (var user in users)
            {
                Console.WriteLine($"    NAME: {user.Name}" +
                                  $"\n  USERNAME: {user.Username}" +
                                  $"\n  SURNAME: {user.Surname}" +
                                  $"\n  PASSWORD: {user.Password}");
                Console.WriteLine("---------------------------------------------------");
            }

            Console.WriteLine("Type '#' to return:");
            string? input = Console.ReadLine();

            if (input.Equals("#"))
            {
                manageUsers.ManageUsers(); // Navigate to manage users page
            }
           
        }
    }
}
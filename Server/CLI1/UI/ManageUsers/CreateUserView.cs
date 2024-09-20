using System;
using Entities;
using RepositoryContracts;

namespace CLI1.UI.ManageUsers
{
    public class CreateUserView
    {
        private readonly IUserRepository userRepository;
        public CreateUserView(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }

        public void CreateUser()
        {
            var manageUsers = new ManageUsersView(userRepository);
            Console.Clear();
            
            Console.WriteLine("#----------------CREATING A USER----------------#");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("USERNAME: ");
            string username = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("NAME: ");
            string name = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("SURNAME: ");
            string surname = Console.ReadLine();

            User user = new User();
            user.Name= name;
            user.Surname = surname;
            user.Password = password;
            user.Username = username;

            userRepository.AddAsync(user);
            manageUsers.ManageUsers();
        }
    }
}
using System;
using RepositoryContracts;

namespace CLI1.UI.ManageUsers
{
    public class ManageUsersView
    {
        private readonly IUserRepository userRepository;
        public ManageUsersView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ManageUsers()
        {
            var listUsersView = new ListUsersView();
            var creatingUserView = new CreateUserView();
            Console.Clear();
            Console.WriteLine("#----------------  PICK AN OPTION BESTIEEE  -----------------#");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("<<1>> CREATE USER");
            Console.WriteLine("<<2>> SHOW ALL USERS");
            string? input = Console.ReadLine();
            if (input.Equals("1"))
            {
                creatingUserView.CreateUser();
            }
            else if (input.Equals("2"))
            {
                listUsersView.ListOfUsers();
            }
        }
    }
}
using System;
using CLI1.UI.ManagePosts;
using RepositoryContracts;

namespace CLI1.UI.ManageUsers
{
    public class ManageUsersView
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        public ManageUsersView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ManageUsers()
        {
            var listUsersView = new ListUsersView(userRepository);
            var creatingUserView = new CreateUserView(userRepository);
            var managePostsView = new ManagePostsView(postRepository);
            Console.Clear();
            Console.WriteLine("#----------------  PICK AN OPTION BESTIEEE  -----------------#");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("<<1>> CREATE USER");
            Console.WriteLine("<<2>> MANAGE POSTS");
            Console.WriteLine("<<3>> SHOW ALL USERS");
            string? input = Console.ReadLine();
            if (input.Equals("1"))
            {
                creatingUserView.CreateUser();
            }
            if (input.Equals("2"))
            {
                managePostsView.ManagePosts();
            }
            else if (input.Equals("3"))
            {
                listUsersView.ListUsers();
            }
        }
    }
}
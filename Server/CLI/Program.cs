// See https://aka.ms/new-console-template for more information

using InMemoryRepositories;
using RepositoryContracts;
using CLI.UI;

Console.WriteLine("Starting CLI App...");
IUserRepository userRepository = new UserInMemoryRepository();
ICommentRepository commentRepository = new CommentInMemoryRepository();


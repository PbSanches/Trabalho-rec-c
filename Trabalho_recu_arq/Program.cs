using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var database = new InMemoryDatabase();
        var userController = new UserController(database);
        var timeEntryController = new TimeEntryController(database);

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Criar usuário");
            Console.WriteLine("2. Editar usuário");
            Console.WriteLine("3. Registrar ponto");
            Console.WriteLine("4. Editar ponto");
            Console.WriteLine("5. Listar tudo");
            Console.WriteLine("6. Sair");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var userId = userController.GetAllUsers().Count + 1;

                    Console.WriteLine("Digite o nome do usuário:");
                    var userName = Console.ReadLine();

                    Console.WriteLine("Digite o email do usuário:");
                    var userEmail = Console.ReadLine();

                    Console.WriteLine("Digite a senha do usuário:");
                    var userPassword = Console.ReadLine();

                    var newUser = new User { Id = userId, Name = userName, Email = userEmail, Password = userPassword };
                    userController.CreateUser(newUser);
                    break;
                case "2":
                    Console.WriteLine("Digite o ID do usuário para editar:");
                    var editUserId = int.Parse(Console.ReadLine());

                    var userToEdit = userController.GetUserById(editUserId);
                    if (userToEdit != null)
                    {
                        Console.WriteLine($"Informações atuais do usuário: ID: {userToEdit.Id}, Nome: {userToEdit.Name}, Email: {userToEdit.Email}");

                        Console.WriteLine("Digite o novo nome do usuário:");
                        var editUserName = Console.ReadLine();

                        Console.WriteLine("Digite o novo email do usuário:");
                        var editUserEmail = Console.ReadLine();

                        Console.WriteLine("Digite a nova senha do usuário:");
                        var editUserPassword = Console.ReadLine();

                        var editUser = new User { Id = editUserId, Name = editUserName, Email = editUserEmail, Password = editUserPassword };
                        userController.UpdateUser(editUser);
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado.");
                    }
                    break;
                case "3":
                    var timeEntryId = timeEntryController.GetAllTimeEntries().Count + 1;

                    Console.WriteLine("Digite o ID do usuário para o ponto de tempo:");
                    var timeEntryUserId = int.Parse(Console.ReadLine());

                    var newTimeEntry = new TimeEntry { Id = timeEntryId, EntryTime = DateTime.Now, ExitTime = DateTime.Now.AddHours(8), UserId = timeEntryUserId };
                    timeEntryController.CreateTimeEntry(newTimeEntry);
                    break;
                case "4":
                    Console.WriteLine("Digite o ID do ponto de tempo para editar:");
                    var editTimeEntryId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o novo ID do usuário para o ponto de tempo:");
                    var editTimeEntryUserId = int.Parse(Console.ReadLine());

                    var editTimeEntry = new TimeEntry { Id = editTimeEntryId, EntryTime = DateTime.Now, ExitTime = DateTime.Now.AddHours(9), UserId = editTimeEntryUserId };
                    timeEntryController.UpdateTimeEntry(editTimeEntry);
                    break;
                case "5":
                    var users = userController.GetAllUsers();
                    Console.WriteLine("Usuários:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Nome: {user.Name}, Email: {user.Email}");
                    }

                    var timeEntries = timeEntryController.GetAllTimeEntries();
                    Console.WriteLine("Pontos de Tempo:");
                    foreach (var timeEntry in timeEntries)
                    {
                        Console.WriteLine($"ID: {timeEntry.Id}, Entrada: {timeEntry.EntryTime}, Saída: {timeEntry.ExitTime}, ID do Usuário: {timeEntry.UserId}");
                    }
                    break;
                case "6":
                    Console.WriteLine("Digite o ID do usuário para excluir:");
                    var deleteUserId = int.Parse(Console.ReadLine());

                    var userToDelete = userController.GetUserById(deleteUserId);
                    if (userToDelete != null)
                    {
                        userController.DeleteUser(deleteUserId);
                        Console.WriteLine("Usuário excluído com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado.");
                    }
                    break;
                case "7":
                    Console.WriteLine("Digite o ID do ponto de tempo para excluir:");
                    var deleteTimeEntryId = int.Parse(Console.ReadLine());

                    var timeEntryToDelete = timeEntryController.GetTimeEntryById(deleteTimeEntryId);
                    if (timeEntryToDelete != null)
                    {
                        timeEntryController.DeleteTimeEntry(deleteTimeEntryId);
                        Console.WriteLine("Ponto de tempo excluído com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Ponto de tempo não encontrado.");
                    }
                    break;
                                    
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}

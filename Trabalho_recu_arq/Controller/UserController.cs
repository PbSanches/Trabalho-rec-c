public class UserController
{
    private readonly InMemoryDatabase _database;

    public UserController(InMemoryDatabase database)
    {
        _database = database;
    }

    public List<User> GetAllUsers()
    {
        return _database.Users;
    }

    public User GetUserById(int id)
    {
        return _database.Users.FirstOrDefault(u => u.Id == id);
    }

    public User CreateUser(User user)
    {
        _database.Users.Add(user);
        return user;
    }

    public void UpdateUser(User user)
    {
        var existingUser = _database.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
        }
    }

    public void DeleteUser(int id)
    {
        var user = _database.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _database.Users.Remove(user);
        }
    }
}
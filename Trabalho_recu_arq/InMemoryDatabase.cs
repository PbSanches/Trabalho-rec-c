public class InMemoryDatabase
{
    public List<User> Users { get; set; } = new List<User>();
    public List<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}
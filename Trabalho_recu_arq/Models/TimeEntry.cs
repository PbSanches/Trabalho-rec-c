public class TimeEntry
{
    public int Id { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}
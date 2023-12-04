public class TimeEntryController
{
    private readonly InMemoryDatabase _database;

    public TimeEntryController(InMemoryDatabase database)
    {
        _database = database;
    }

    public List<TimeEntry> GetAllTimeEntries()
    {
        return _database.TimeEntries;
    }

    public TimeEntry GetTimeEntryById(int id)
    {
        return _database.TimeEntries.FirstOrDefault(t => t.Id == id);
    }

    public TimeEntry CreateTimeEntry(TimeEntry timeEntry)
    {
        _database.TimeEntries.Add(timeEntry);
        return timeEntry;
    }

    public void UpdateTimeEntry(TimeEntry timeEntry)
    {
        var existingTimeEntry = _database.TimeEntries.FirstOrDefault(t => t.Id == timeEntry.Id);
        if (existingTimeEntry != null)
        {
            existingTimeEntry.EntryTime = timeEntry.EntryTime;
            existingTimeEntry.ExitTime = timeEntry.ExitTime;
            existingTimeEntry.User = timeEntry.User;
            existingTimeEntry.UserId = timeEntry.UserId;
        }
    }

    public void DeleteTimeEntry(int id)
    {
        var timeEntry = _database.TimeEntries.FirstOrDefault(t => t.Id == id);
        if (timeEntry != null)
        {
            _database.TimeEntries.Remove(timeEntry);
        }
    }
}
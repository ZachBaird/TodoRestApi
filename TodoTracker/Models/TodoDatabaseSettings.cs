// The following class and interface here store the values from the appsettings.json file.
// The Json and C# property names are the same for ease of mapping.

namespace TodoTracker.Models
{
    public class TodoDatabaseSettings : ITodoDatabaseSettings
    {
        public string TodoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITodoDatabaseSettings
    {
        string TodoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

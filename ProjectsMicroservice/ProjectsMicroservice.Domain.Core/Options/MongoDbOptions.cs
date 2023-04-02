namespace ProjectsMicroservice.Domain.Core.Options;

public class MongoDbOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string UserSettingsCollection { get; set; } = string.Empty;
    public string ProjectsCollection { get; set; } = string.Empty;
}

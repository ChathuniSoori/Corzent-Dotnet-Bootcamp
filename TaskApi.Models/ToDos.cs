using Corzent_Dotnet_Bootcamp.Models;

namespace TaskApi.Models;

public class ToDos
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public PriorityLevel Priority { get;  set; }
}

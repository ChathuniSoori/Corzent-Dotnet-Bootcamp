using Corzent_Dotnet_Bootcamp.Models;

namespace Corzent_Dotnet_Bootcamp
{
    public class ToDoAppClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public PriorityLevel Priority { get; internal set; }
    }
}


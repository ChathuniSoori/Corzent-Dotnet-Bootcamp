using System.ComponentModel.DataAnnotations;

namespace Corzent_Dotnet_Bootcamp.Models
{
    public class ToDos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}
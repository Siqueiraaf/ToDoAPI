using System.ComponentModel.DataAnnotations;

namespace TodoAPi.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Todo()
        {
            IsCompleted = false;
        }
    }
}
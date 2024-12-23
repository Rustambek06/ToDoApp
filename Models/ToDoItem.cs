namespace ToDoList.Models
{
    public class ToDoItems
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}

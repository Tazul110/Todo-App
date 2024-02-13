namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Descrip { get; set; }
        public int IsActive { get; set; }

        public DateTime DueOn { get; set; }



    }
}

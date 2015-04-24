using System;
namespace Lisa.Website
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string References { get; set; }
    }
}
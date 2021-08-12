using System;
namespace _49_1.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public int? UserId { get; set; }
    }
}

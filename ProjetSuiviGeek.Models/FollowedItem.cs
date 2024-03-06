using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetSuiviGeek.Models
{
    public class FollowedItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool BeFollowed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        //public Manga Manga { get; set; }
    }
}

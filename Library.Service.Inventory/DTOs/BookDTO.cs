using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Service.Inventory.DTOs
{
    public class BookDTO
    {
        public Guid BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public string Description { get; set; }
    }
}
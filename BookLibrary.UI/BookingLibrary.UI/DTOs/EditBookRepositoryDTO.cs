using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class EditBookRepositoryDTO
    {
        public Guid BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        public string Description { get; set; }
    }
}
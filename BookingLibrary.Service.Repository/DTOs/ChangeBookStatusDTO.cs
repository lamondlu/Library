using System;
using System.ComponentModel.DataAnnotations;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.DTOs
{
    public class ChangeBookStatusDTO
    {
        public BookRepositoryStatus Status { get; set; }

        public string Notes { get; set; }
    }
}
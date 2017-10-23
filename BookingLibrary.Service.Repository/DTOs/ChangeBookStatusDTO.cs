using System;
using System.ComponentModel.DataAnnotations;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.DTOs
{
    public class ChangeBookStatusDTO
    {
        public BookStatus Status { get; set; }
    }
}
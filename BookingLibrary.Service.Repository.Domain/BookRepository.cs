using System;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain
{
    public class BookRepository : Entity
    {
        public BookRepository(Guid id) : base()
        {
            this.Id = id;
        }

        public BookRepositoryStatus Status { get; private set; }

        public void InStore()
        {
            this.Status = BookRepositoryStatus.InStore;
        }

        public void OutStore()
        {
            this.Status = BookRepositoryStatus.OutStore;
        }
    }
}
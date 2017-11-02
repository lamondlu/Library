using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.Events;
using System.Linq;

namespace BookingLibrary.Service.Repository.Domain
{
    public class Book : AggregateRoot,
    IHandler<BookAddedEvent>,
    IHandler<BookRemovedEvent>,
    IHandler<BookISBNChangedEvent>,
    IHandler<BookNameChangedEvent>,
    IHandler<BookIssuedDateChangedEvent>,
    IHandler<BookDescriptionChangedEvent>,
    IHandler<BookRepositoryInStoredEvent>,
    IHandler<BookRepositoryOutStoredEvent>,
    IHandler<BookRepositoryImportedEvent>
    {
        public Book()
        {

        }

        public Book(Guid bookId, string isbn, string bookName, string description, DateTime dateIssued)
        {
            ApplyChange(new BookAddedEvent
            {
                ISBN = isbn,
                BookName = bookName,
                DateIssued = dateIssued,
                AggregateId = bookId,
                Description = description
            });
        }

        public string ISBN { get; internal set; }

        public string BookName { get; internal set; }

        public string Description { get; internal set; }

        public DateTime DateIssued { get; internal set; }

        public List<BookRepository> BookRepositories { get; set; }

        public void ChangeBookName(string bookName)
        {
            ApplyChange(new BookNameChangedEvent
            {
                BookId = Id,
                NewBookName = bookName
            });
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new BookDescriptionChangedEvent
            {
                AggregateId = Id,
                Description = description
            });
        }

        public void ChangeISBN(string isbn)
        {
            ApplyChange(new BookISBNChangedEvent
            {
                AggregateId = Id,
                NewBookISBN = isbn
            });
        }

        public void ChangeIssuedDate(DateTime issuedDate)
        {
            ApplyChange(new BookIssuedDateChangedEvent
            {
                AggregateId = Id,
                NewBookIssuedDate = issuedDate
            });
        }

        public void OutStoreBookRepository(Guid bookRepositoryId, string notes)
        {
            var bookRepository = this.BookRepositories.FirstOrDefault(p => p.Id == bookRepositoryId);

            if (bookRepository == null)
            {
                throw new Exception("The book repository is not existed.");
            }
            else if (bookRepository.Status == BookRepositoryStatus.InStore)
            {
                throw new Exception("The book is still out store.");
            }
            else
            {
                ApplyChange(new BookRepositoryOutStoredEvent
                {
                    Notes = notes,
                    BookRepositoryId = bookRepository.Id,
                    AggregateId = this.Id
                });
            }
        }

        public void InStoreBookRepository(Guid bookRepositoryId, string notes)
        {
            var bookRepository = this.BookRepositories.FirstOrDefault(p => p.Id == bookRepositoryId);

            if (bookRepository == null)
            {
                throw new Exception("The book repository is not existed.");
            }
            else if (bookRepository.Status == BookRepositoryStatus.InStore)
            {
                throw new Exception("The book is still in store.");
            }
            else
            {
                ApplyChange(new BookRepositoryInStoredEvent
                {
                    Notes = notes,
                    BookRepositoryId = bookRepository.Id,
                    AggregateId = this.Id
                });
            }
        }

        public void Import(List<Guid> repositoryIds)
        {
            ApplyChange(new BookRepositoryImportedEvent
            {
                AggregateId = Id,
                BookRepositoryIds = repositoryIds
            });
        }

        public void Handle(BookAddedEvent evt)
        {
            this.BookName = evt.BookName;
            this.DateIssued = evt.DateIssued;
            this.Id = evt.AggregateId;
            this.ISBN = evt.ISBN;
            this.Description = evt.Description;
            this.BookRepositories = new List<BookRepository>();
        }

        public void Handle(BookRemovedEvent evt)
        {

        }

        public void Handle(BookIssuedDateChangedEvent evt)
        {
            this.DateIssued = evt.NewBookIssuedDate;
        }

        public void Handle(BookNameChangedEvent evt)
        {
            this.BookName = evt.NewBookName;
        }

        public void Handle(BookISBNChangedEvent evt)
        {
            this.ISBN = evt.NewBookISBN;
        }

        public void Remove()
        {
            ApplyChange(new BookRemovedEvent());
        }

        public void Handle(BookDescriptionChangedEvent evt)
        {
            this.Description = evt.Description;
        }

        public void Handle(BookRepositoryOutStoredEvent evt)
        {
            var repository = this.BookRepositories.First(p => p.Id == evt.BookRepositoryId);
            repository.OutStore();
        }

        public void Handle(BookRepositoryInStoredEvent evt)
        {
            var repository = this.BookRepositories.First(p => p.Id == evt.BookRepositoryId);
            repository.InStore();
        }

        public void Handle(BookRepositoryImportedEvent evt)
        {
            foreach (var id in evt.BookRepositoryIds)
            {
                var bookRepository = new BookRepository(id);

                bookRepository.InStore();
                this.BookRepositories.Add(bookRepository);
            }
        }
    }
}

using System;
using Lending.Cqrs;
using Lending.Cqrs.Command;

namespace Lending.Domain.AddBookToLibrary
{
    public class AddBookToLibrary : AuthenticatedCommand
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }

        public AddBookToLibrary(Guid processId, Guid aggregateId, Guid libraryId, string title, string author, string isbnnumber)
            : base(processId, aggregateId, libraryId)
        {
            Title = title;
            Author = author;
            Isbn = isbnnumber;
        }

        public AddBookToLibrary()
        {
            
        }

    }
}
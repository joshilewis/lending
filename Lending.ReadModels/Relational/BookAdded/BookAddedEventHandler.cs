﻿using System;
using Lending.Domain.AddBookToLibrary;
using Lending.Domain.OpenLibrary;
using NHibernate;

namespace Lending.ReadModels.Relational.BookAdded
{
    public class BookAddedEventHandler : Lending.Cqrs.EventHandler<BookAddedToLibrary>
    {
        private readonly Func<ISession> getSession;

        public BookAddedEventHandler(Func<ISession> sessionFunc)
        {
            getSession = sessionFunc;
        }

        public override void When(BookAddedToLibrary @event)
        {
            ISession session = getSession();

            string username = session.Get<OpenedLibrary>(@event.AggregateId).Name;

            session.Save(new LibraryBook(@event.ProcessId, @event.AggregateId, username, @event.Title, @event.Author,
                @event.Isbn));
        }
    }
}
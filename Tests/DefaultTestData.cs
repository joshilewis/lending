﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lending.Cqrs.Exceptions;
using Lending.Cqrs.Query;
using Lending.Domain.AcceptLink;
using Lending.Domain.AddBookToLibrary;
using Lending.Domain.Model;
using Lending.Domain.OpenLibrary;
using Lending.Domain.RemoveBookFromLibrary;
using Lending.Domain.RequestLink;
using Lending.Execution.Auth;

namespace Tests
{
    public class DefaultTestData
    {
        public static OpenedLibrary RegisteredUser1 => new OpenedLibrary(Guid.Empty, "Joshua Lewis");

        public static OpenedLibrary RegisteredUser2 => new OpenedLibrary(Guid.Empty, "User2");

        public static OpenedLibrary RegisteredUser3 => new OpenedLibrary(Guid.Empty, "User3");

        public static Guid processId = Guid.Empty;
        public static Guid Library1Id = Guid.NewGuid();
        public static Guid Library2Id = Guid.NewGuid();
        public static Guid Library3Id = Guid.NewGuid();
        public static Guid Library4Id = Guid.NewGuid();
        public static Guid Library5Id = Guid.NewGuid();
        public static Guid Library6Id = Guid.NewGuid();

        public static HttpResponseMessage Http201Created = new HttpResponseMessage(HttpStatusCode.Created);
        public static HttpResponseMessage Http200Ok = new HttpResponseMessage(HttpStatusCode.OK);

        public static OpenLibrary Library1Opens = new OpenLibrary(processId, Library1Id, Library1Id, "library1", Library1Id);

        public static LibraryOpened Library1Opened = new LibraryOpened(processId, Library1Id, Library1Opens.Name,
            Library1Opens.AdministratorId);

        public static string Title = "Title";
        public static string Author = "Author";
        public static string Isbnnumber = "isbn";

        public static AddBookToLibrary AddBook1ToLibrary = new AddBookToLibrary(processId, Guid.Empty, Library1Id, Title,
            Author, Isbnnumber);

        public static AddBookToLibrary UnauthorizedAddBookToLibrary = new AddBookToLibrary(processId, Guid.Empty, Guid.Empty, Title,
            Author, Isbnnumber);

        public static BookAddedToLibrary Book1AddedToUser1Library = new BookAddedToLibrary(processId, Library1Id, Title,
            Author, Isbnnumber);

        public static RemoveBookFromLibrary User1RemovesBookFromLibrary = new RemoveBookFromLibrary(processId, Guid.Empty,
            Library1Id, Title, Author, Isbnnumber);

        public static RemoveBookFromLibrary UnauthorizedRemoveBook = new RemoveBookFromLibrary(processId, Guid.Empty,
            Guid.Empty, Title, Author, Isbnnumber);

        public static BookRemovedFromLibrary Book1RemovedFromLibrary = new BookRemovedFromLibrary(processId, Library1Id,
            Title, Author, Isbnnumber);

        public static Result Succeed = new Result(Result.EResultCode.Ok);

        public static HttpResponseMessage Http400BecauseBookAlreadyInLibrary1 =
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = Library.BookAlreadyInLibrary,
            };

        public static HttpResponseMessage Http400BecauseBookNotInLibrary =
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = Library.BookNotInLibrary
            };
            
        public static HttpResponseMessage Http400BecauseNoPendingLinkRequest =
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = Library.NoPendingLinkRequest
            };
        public static HttpResponseMessage Http400BecauseLibrariesAlreadyLinked = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = Library.LibrariesAlreadyLinked,
        };
        public static OpenLibrary Library2Opens = new OpenLibrary(processId, Library2Id, Library2Id, "user2", Library2Id);

        public static RequestLink Library1RequestsLinkToLibrary2 = new RequestLink(processId, Guid.Empty, 
            Library1Id, Library2Id);

        public static LinkRequested LinkRequestedFrom1To2 = new LinkRequested(processId, Library1Id,
            Library2Id);

        public static LibraryOpened Library2Opened = new LibraryOpened(processId, Library2Id, Library2Opens.Name,
            Library2Opens.AdministratorId);

        public static LinkRequestReceived LinkRequestFrom1To2Received =
            new LinkRequestReceived(processId, Library2Id, Library1Id);

        public static AcceptLink Library2AcceptsLinkFromLibrary1 = new AcceptLink(processId, Guid.Empty, Library2Id,
            Library1Id);

        public static AcceptLink UnauthorizedAcceptLink = new AcceptLink(processId, Guid.Empty, Guid.Empty, Library1Id);

        public static LinkCompleted LinkCompleted = new LinkCompleted(processId, Library1Id, Library2Id);
        public static LinkAccepted LinkAccepted = new LinkAccepted(processId, Library2Id, Library1Id);
        public static HttpResponseMessage Http400BecauseLinkAlreadyRequested = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = Library.LinkAlreadyRequested,
        };

        public static HttpResponseMessage Http404BecauseTargetLibraryDoesNotExist =
            new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = $"Aggregate '{Library2Id}' (type {typeof (Library).Name}) was not found.",
            };

        public static HttpResponseMessage Http400BecauseReverseLinkAlreadyRequested =
            new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = Library.ReverseLinkAlreadyRequested
            };
        
        public static HttpResponseMessage Http400BecauseCantLinkToSelf = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            ReasonPhrase = RequestLinkHandler.CantConnectToSelf
        };

        public static RequestLink Library2RequestsLinkToLibrary1 = new RequestLink(processId, Guid.Empty,
            Library2Id, Library1Id);

        public static RequestLink Library1Requests2NdLinkToLibrary2 = new RequestLink(processId, Guid.Empty,
            Library1Id, Library2Id);

        public static LinkRequested LinkRequestedFrom2To1 = new LinkRequested(processId, Library2Id,
            Library1Id);

        public static LinkRequestReceived LinkRequestFrom2To1Received =
            new LinkRequestReceived(processId, Library1Id, Library2Id);

        public static RequestLink Library1RequestsLinkToSelf = new RequestLink(processId, Guid.Empty,
            Library1Id, Library1Id);

        public static RequestLink UnauthorizedRequestLink = new RequestLink(processId, Guid.Empty,
            Guid.Empty, Library2Id);

        public static OpenLibrary JoshuaLewisOpensLibrary = new OpenLibrary(processId, Library1Id, Library1Id,
            "Joshua Lewis", Library1Id);
        public static LibraryOpened JoshuaLewisLibraryOpened = new LibraryOpened(processId, Library1Id, "Joshua Lewis",
            Library1Id);

        public static OpenLibrary SuzaanHepburnOpensLibrary = new OpenLibrary(processId, Library2Id, Library2Id,
            "Suzaan Hepburn", Library2Id);
        public static OpenLibrary JosieDoeOpensLibrary = new OpenLibrary(processId, Library3Id, Library3Id,
            "Josie Doe", Library3Id);
        public static OpenLibrary AudreyHepburnOpensLibrary = new OpenLibrary(processId, Library4Id, Library4Id,
            "Audrey Hepburn", Library4Id);

        public static LibraryOpened SuzaanHepburnLibraryOpened = new LibraryOpened(processId, Library2Id, "Suzaan Hepburn",
            Library2Id);

        public static LibraryOpened JosieDoeLibraryOpened = new LibraryOpened(processId, Library3Id, "Josie Doe", Library3Id);

        public static LibraryOpened AudreyHepburnLibraryOpened = new LibraryOpened(processId, Library4Id,
            "Audrey Hepburn", Library4Id);

        public static string TestDrivenDevelopment = "Test-Driven Development";
        public static string KentBeck = "Kent Beck";
        public static string Isbn = "Isbn";
        public static string ExtremeProgrammingExplained = "Extreme Programming Explained";
        public static string ExtremeSnowboardStunts = "Extreme Snowboard Stunts";
        public static string SomeSkiier = "Some Skiier";
        public static string BeckAMusicalMaestro = "Beck: A musical Maestro";
        public static string SomeAuthor = "Some Author";

        public static LibraryOpened Library3Opened = new LibraryOpened(processId, Library3Id, "User3", Library3Id);
        public static LibraryOpened Library4Opened = new LibraryOpened(processId, Library4Id, "User4", Library4Id);
        public static LibraryOpened Library5Opened = new LibraryOpened(processId, Library5Id, "User5", Library5Id);
        public static LibraryOpened Library6Opened = new LibraryOpened(processId, Library6Id, "User6", Library6Id);

        public static LinkAccepted Link1To2Accepted = new LinkAccepted(processId, Library2Id, Library1Id);
        public static LinkAccepted Link1To3Accepted = new LinkAccepted(processId, Library3Id, Library1Id);
        public static LinkAccepted Link1To4Accepted = new LinkAccepted(processId, Library4Id, Library1Id);
        public static LinkAccepted Link1To5Accepted = new LinkAccepted(processId, Library5Id, Library1Id);
        public static LinkAccepted Link1To6Accepted = new LinkAccepted(processId, Library6Id, Library1Id);

        public static BookAddedToLibrary xpeByKbAddTo2 = new BookAddedToLibrary(processId, Library2Id,
            ExtremeProgrammingExplained, KentBeck, Isbn);

        public static BookAddedToLibrary xpeByKbAddTo4 = new BookAddedToLibrary(processId, Library4Id,
            ExtremeProgrammingExplained, KentBeck, Isbn);

        public static BookAddedToLibrary tddByKbAddTo3 = new BookAddedToLibrary(processId, Library3Id,
            TestDrivenDevelopment, KentBeck, Isbn);

        public static BookAddedToLibrary essBySSAddTo5 = new BookAddedToLibrary(processId, Library5Id,
            ExtremeSnowboardStunts, SomeSkiier, Isbn);

        public static BookAddedToLibrary bBySAAddTo6 = new BookAddedToLibrary(processId, Library6Id, BeckAMusicalMaestro,
            SomeAuthor, Isbn);

        public static BookRemovedFromLibrary xpeByKbRemoveFrom4 = new BookRemovedFromLibrary(processId, Library4Id,
            ExtremeProgrammingExplained, KentBeck, Isbn);

    }
}

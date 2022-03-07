using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Database;

namespace Bookish.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BookService_ConvertsDbModelsToClasses()
    {
        // Arrange
        var fakeBookRepo = A.Fake<IBookRepo>();
        A.CallTo(() => fakeBookRepo.GetAllBooks()).Returns(
            new List<BookDbModel>
            {
                new BookDbModel
                {
                    Title = "The Dispossessed",
                    Authors = new List<AuthorDbModel>
                    {
                        new AuthorDbModel
                        {
                            Name = "Ursula K. Le Guin",
                        },
                    },
                    CoverPhotoUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1353467455l/13651.jpg",
                    Blurb = "A great sci-fi book about things",
                },
                new BookDbModel
                {
                    Title = "Leviathan Wakes",
                    Authors = new List<AuthorDbModel>
                    {
                        new AuthorDbModel
                        {
                            Name = "James S.A. Corey",
                        },
                    },
                    CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/91Zzw-Mc5xL.jpg",
                    Blurb = "The first book in 'The Expanse' series",
                },
            }
        );
        var service = new BookService(fakeBookRepo);

        // Act
        var books = service.GetAllBooks();

        // Assert
        Assert.That(books, Has.Exactly(2).Items);
        Assert.That(books[0].Title, Is.EqualTo("The Dispossessed"));
    }
}
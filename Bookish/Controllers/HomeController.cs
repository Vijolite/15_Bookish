using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private BookService _bookService = new BookService();
    private MemberService _memberService = new MemberService();

     private LoanService _loanService = new LoanService();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BookList()
    {
        // var books = new List<Book>
        // {
        //     new Book
        //     {
        //         Title = "The Dispossessed",
        //         Author = "Ursula K. Le Guin",
        //         CoverPhotoUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1353467455l/13651.jpg",
        //         Blurb = "A great sci-fi book about things"
        //     },
        //     new Book
        //     {
        //         Title = "Harry Potter and the Philosopher's Stone",
        //         Author = "JK Rowling",
        //         CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/81YOuOGFCJL.jpg",
        //         Blurb = "A young wizard learns he is a wizard"
        //     },
        //     new Book
        //     {
        //         Title = "Leviathan Wakes",
        //         Author = "James S.A. Corey",
        //         CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/91Zzw-Mc5xL.jpg",
        //         Blurb = "The first book in 'The Expanse' series"
        //     },
        // };

        var books = _bookService.GetAllBooks();
        return View(books);
    }

    public IActionResult MemberList()
    {

        var members = _memberService.GetAllMembers();
        return View(members);
    }

    public IActionResult LoanList()
    {

        var loans = _loanService.GetAllLoans();
        return View(loans);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

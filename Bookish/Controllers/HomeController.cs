using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Request;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly ICopyService _copyService;
    private readonly IMemberService _memberService;

    private readonly IAuthorService _authorService;
    //private MemberService _memberService = new MemberService();
    private LoanService _loanService = new LoanService();

    private readonly IBookRepo _books;

    public HomeController(
        ILogger<HomeController> logger,
        IBookService bookService,
        ICopyService copyService,
        IMemberService memberService,
        IAuthorService authorService
    )
    {
        _logger = logger;
        _bookService = bookService;
        _copyService = copyService;
        _memberService = memberService;
        _authorService = authorService;
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
        var books = _bookService.GetAllBooks();
        return View(books);
    }

    public IActionResult AvailableCopyList()
    {
        var copies = _copyService.GetAvailableCopies();
        return View(copies);
    }

    public IActionResult AvailableExemplarsList()
    {
        var avEx = _copyService.GetAvailableCopiesCount();
        return View(avEx);
    }

    public IActionResult CreateBookForm()
    {
        var authors = _authorService.GetAllAuthors();
        //ViewBag.Authors = authors;
        ViewBag.Authors = authors.Select(
            a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }
        );
        ViewBag.AuthorPhotos = authors.Select(
            a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorPhotoUrl
            }
        );
        return View();
    }

    [HttpPost]
    public IActionResult CreateBook([FromForm] CreateBookRequest createBookRequest)
    {
        var newBook = _bookService.CreateBook(createBookRequest);

        return Created("/Home/BookList", newBook);
    }

    public IActionResult CreateCopyForm()
    {
        var books = _bookService.GetAllBooks();
        ViewBag.Books = books.Select(
            a => new SelectListItem
            {
                Value = a.Isbn,
                Text = a.Title + " (" + a.Isbn + ") " 
                
            }
        );
        ViewBag.Photos = books.Select(
            a => new SelectListItem
            {
                Value = a.Isbn,
                Text = a.CoverPhotoUrl
                
            }
        );
        
        return View();
    }

    [HttpPost]
    public IActionResult CreateCopy([FromForm] CreateCopyRequest createCopyRequest)
    {
           
        var newCopy = _copyService.CreateCopy(createCopyRequest);
        

        return Created("/Home/BookList", newCopy);
    }

    public IActionResult CreateLoanForm()
    {
        var members = _memberService.GetAllMembers();
        ViewBag.Members = members.Select(
            a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
                
            }
        );
        var copies = _copyService.GetAvailableCopiesCount();
        ViewBag.Copies = copies.Select(
            a => new SelectListItem
            {
                Value = a.TopCopyId.ToString(),
                Text = a.Title + " (" + a.Isbn + ") " 
                
            }
        );
        
        return View();
    }

    [HttpPost]
    public IActionResult CreateLoan([FromForm] CreateLoanRequest createLoanRequest)
    {
           
        var newLoan = _loanService.CreateLoan(createLoanRequest);
        return Created("/Home/MemberList", newLoan);
    }

    public IActionResult UpdateLoanForm()
    {
        var members = _memberService.GetAllMembers();
        ViewBag.Members = members.Select(
            a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
                
            }
        );
        ViewBag.MembersFullInfo = members;
        // var copies = _copyService.GetAvailableCopiesCount();
        // ViewBag.Copies = copies.Select(
        //     a => new SelectListItem
        //     {
        //         Value = a.TopCopyId.ToString(),
        //         Text = a.Title + " (" + a.Isbn + ") " 
                
        //     }
        // );
        
        return View();
    }

    [HttpPatch]
    public IActionResult UpdateLoan([FromForm] UpdateLoanRequest updateLoanRequest)
    {       
        var newLoan = _loanService.UpdateLoan(updateLoanRequest);
        return Created("/Home/MemberList", newLoan);
    }


    public IActionResult CreateAuthorForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateMember([FromForm] CreateMemberRequest createMemberRequest)
    {
        var newMember = _memberService.CreateMember(createMemberRequest);

        return Created("/Home/MemberList", newMember);
    }

    public IActionResult CreateMemberForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateAuthor([FromForm] CreateAuthorRequest createAuthorRequest)
    {
        var newAuthor = _authorService.CreateAuthor(createAuthorRequest);

        return Created("/Home/AuthorList", newAuthor);
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
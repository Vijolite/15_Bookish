﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Request;
using Bookish.Models.Response;

namespace Bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private MemberService _memberService = new MemberService();
    private LoanService _loanService = new LoanService();

    private readonly IBookRepo _books;

    public HomeController(
        ILogger<HomeController> logger,
        IBookService bookService,
        IAuthorService authorService
    )
    {
        _logger = logger;
        _bookService = bookService;
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

    public IActionResult CreateBookForm()
    {
        var authors = _authorService.GetAllAuthors();
        ViewBag.Authors = authors;
        return View();
    }

    [HttpPost]
    public IActionResult CreateBook([FromForm] CreateBookRequest createBookRequest)
    {
        var newBook = _bookService.CreateBook(createBookRequest);

        return Created("/Home/BookList", newBook);
    }

    // [HttpPost("create")]
    // public IActionResult Create([FromBody] CreateBookRequest newBook)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //     // var books = _books.GetAllBooks();
    //     // var book = books.Create(newBook);
    //     var book = _books.Create(newBook);

    //     var url = Url.Action("GetById", new { id = user.Id });
    //     var responseViewModel = new BookResponse(book);
    //     return Created(url, responseViewModel);
    // }

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
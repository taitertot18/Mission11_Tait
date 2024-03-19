using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11_Tait.Models;
using Mission11_Tait.Models.ViewModels;

namespace Mission11_Tait.Controllers;

public class HomeController : Controller
{
    private IBookRepository _repo;

    public HomeController(IBookRepository temp)
    {
        _repo = temp;
    }

    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;

        var newBookstore = new BookstoreListViewModel
        {
            Books = _repo.Books
                .Skip((pageNum -1) * pageSize)
                .Take(pageSize),

            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        
        return View(newBookstore);
    }
    
}
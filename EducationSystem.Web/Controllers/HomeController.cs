using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EducationSystem.Web.Models;

namespace EducationSystem.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICourseService _courseService;

    public HomeController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index(string search)
    {
        var courses = await _courseService.GetCoursesFilteredAsync(search);
        return View(courses);
    }
}

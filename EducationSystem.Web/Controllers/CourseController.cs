using Microsoft.AspNetCore.Mvc;
using EducationSystem.Domain.Models;
using System.Threading.Tasks;

public class CoursesController : Controller
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // GET: /Courses
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetCoursesAsync();
        return View(courses); // Pass list to the view
    }

    // GET: /Courses/Details/{id}
    public async Task<IActionResult> Details(Guid id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course); // Show details page
    }
}


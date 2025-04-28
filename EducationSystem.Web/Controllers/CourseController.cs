using EducationSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EducationSystem.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return View(course);
        }
    }
}

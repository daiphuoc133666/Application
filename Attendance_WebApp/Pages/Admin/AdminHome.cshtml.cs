using Attendance_WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Attendance_WebApp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminHomeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TeacherCount { get; set; }
        public int StudentCount { get; set; }
        public int ClassCount { get; set; }

        public async Task OnGetAsync()
        {
            TeacherCount = await _context.Teachers.CountAsync();
            StudentCount = await _context.Students.CountAsync();
            ClassCount = await _context.Classes.CountAsync();
        }
    }
}

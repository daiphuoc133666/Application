using Attendance_WebApp.Data;
using Attendance_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Attendance_WebApp.Pages.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class TeacherHomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TeacherHomeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Class> Classes { get; set; }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            Classes = await _context.Classes
                .Where(c => c.TeacherID.ToString() == userId) // Lọc lớp mà giáo viên quản lý
                .ToListAsync();
        }
    }
}

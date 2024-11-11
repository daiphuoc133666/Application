using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Attendance_WebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace Attendance_WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dùng để nhập thông tin
        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; } // Thông báo lỗi

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Chỉ cần gọi OnGet sẽ hiển thị trang mà không làm gì đặc biệt
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của input
            {
                // Kiểm tra trong database
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == Input.Username && u.Password == Input.Password);

                if (user != null)
                {
                    // Đăng nhập thành công, lưu thông tin vào Session
                    HttpContext.Session.SetString("UserId", user.ID.ToString());
                    HttpContext.Session.SetString("Role", user.Role);

                    // Chuyển hướng đến trang tương ứng
                    if (user.Role == "Admin")
                    {
                        return RedirectToPage("/Admin/Index"); // Trang quản lý Admin
                    }
                    else if (user.Role == "Teacher")
                    {
                        return RedirectToPage("/Teacher/Index"); // Trang giáo viên
                    }
                }

                // Nếu thông tin đăng nhập không chính xác, hiển thị thông báo
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }

            // Nếu ModelState không hợp lệ hoặc thông tin đăng nhập không chính xác, hiển thị lại trang
            return Page();
        }
    }
}
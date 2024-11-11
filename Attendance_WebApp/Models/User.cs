namespace Attendance_WebApp.Models
{
    public class User
    {
        public int ID { get; set; } // ID của người dùng
        public string Username { get; set; } // Tên tài khoản
        public string Password { get; set; } // Mật khẩu
        public string Role { get; set; } // Vai trò (Admin/Teacher)

    }
}

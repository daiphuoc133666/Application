namespace Attendance_WebApp.Models
{
    public class Teacher
    {
        public int ID { get; set; } // ID của giáo viên
        public string Name { get; set; } // Tên giáo viên
        public string Email { get; set; } // Email giáo viên
        public int UserID { get; set; } // ID của người dùng khớp với bảng Users

    }
}

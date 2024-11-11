namespace Attendance_WebApp.Models
{
    public class Student
    {
        public int ID { get; set; } // ID của học sinh
        public string Name { get; set; } // Tên học sinh
        public int ClassID { get; set; } // ID lớp học khớp với bảng Classes

    }
}

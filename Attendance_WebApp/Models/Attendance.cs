namespace Attendance_WebApp.Models
{
    public class Attendance
    {
        public int ID { get; set; } // ID của bản ghi điểm danh
        public int StudentID { get; set; } // ID học sinh khớp với bảng Students
        public int ClassID { get; set; } // ID lớp học khớp với bảng Classes
        public DateTime Date { get; set; } // Ngày điểm danh
        public string Status { get; set; } // Trạng thái điểm danh (Có mặt, Vắng mặt)

    }
}

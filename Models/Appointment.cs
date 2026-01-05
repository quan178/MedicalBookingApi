namespace MedicalBookingApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty; // Làm nhanh nên khỏi cần bảng User, nhập tên là được
        public string PatientPhone { get; set; } = string.Empty;
        public DateTime AppointmentTime { get; set; } // Giờ khám
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relationship
        public Doctor? Doctor { get; set; }
    }
}

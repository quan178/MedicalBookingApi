namespace MedicalBookingApi.DTOs
{
    public class BookingRequest
    {
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public DateTime AppointmentTime { get; set; }
    }
}

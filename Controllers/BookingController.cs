using MedicalBookingApi.Data;
using MedicalBookingApi.DTOs;
using MedicalBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách bác sĩ
        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }

        // 2. Đặt lịch khám (CORE FEATURE)
        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] BookingRequest request)
        {
            // Logic 1: Kiểm tra bác sĩ có tồn tại không
            var doctor = await _context.Doctors.FindAsync(request.DoctorId);
            if (doctor == null) return NotFound("Bác sĩ không tồn tại.");

            // Logic 2: VALIDATION - Kiểm tra xem giờ đó bác sĩ đã bận chưa?
            // Giả sử mỗi ca khám là 30 phút.
            var isBusy = await _context.Appointments.AnyAsync(a =>
                a.DoctorId == request.DoctorId &&
                a.AppointmentTime == request.AppointmentTime
            );

            if (isBusy)
            {
                return BadRequest("Bác sĩ đã có lịch hẹn vào giờ này. Vui lòng chọn giờ khác.");
            }

            // Logic 3: Lưu vào DB
            var appointment = new Appointment
            {
                DoctorId = request.DoctorId,
                PatientName = request.PatientName,
                PatientPhone = request.PatientPhone,
                AppointmentTime = request.AppointmentTime
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Đặt lịch thành công!", AppointmentId = appointment.Id });
        }
    }
}

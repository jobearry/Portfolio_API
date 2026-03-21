using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;

namespace Portfolio_API.Mapper.EmployeeManagement
{
    public class AttendanceMapper : IMapper<Attendance, DTOAttendance>
    {
        public DTOAttendance MapToDto(Attendance source)
        {
            return new DTOAttendance
            {
                AttendanceId = source.AttendanceId,
                EmployeeId = source.EmployeeId,
                Date = source.Date,
                CheckIn = source.CheckIn,
                CheckOut = source.CheckOut,
                Status = source.Status
            };
        }
        public Attendance MapToEntity(DTOAttendance destination)
        {
            return new Attendance
            {
                AttendanceId = destination.AttendanceId,
                EmployeeId = destination.EmployeeId,
                Date = destination.Date,
                CheckIn = destination.CheckIn,
                CheckOut = destination.CheckOut,
                Status = destination.Status
            };
        }
        public void UpdateEntity(Attendance entity, DTOAttendance destination)
        {
            entity.EmployeeId = destination.EmployeeId;
            entity.Date = destination.Date;
            entity.CheckIn = destination.CheckIn;
            entity.CheckOut = destination.CheckOut;
            entity.Status = destination.Status;
        }
    }
}

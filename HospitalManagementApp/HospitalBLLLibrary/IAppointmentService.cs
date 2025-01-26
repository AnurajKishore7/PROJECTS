using HospitalModelLibrary;

namespace HospitalBLLLibrary
{
    public interface IAppointmentService
    {
        Appointment? BookAppointment(Appointment appointment);
        IEnumerable<Appointment> GetAllAppointments();
        Appointment? GetAppointment(int id);
        Appointment? UpdateAppointment(int id, Appointment appointment);
        bool CancelAppointment(int id);
    }
}

using HospitalModelLibrary;
using HospitalDALLibrary;

namespace HospitalBLLLibrary
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentService(IRepository<int, Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        private bool ValidateAppointment(Appointment appointment, out string errorMessage)
        {
            if (appointment.PatientId <= 0)
            {
                errorMessage = "Invalid Patient ID.";
                return false;
            }

            if (appointment.DoctorId <= 0)
            {
                errorMessage = "Invalid Doctor ID.";
                return false;
            }

            if (appointment.AppointmentDateTime == default)
            {
                errorMessage = "Invalid appointment date and time.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(appointment.AppointmentReason))
            {
                errorMessage = "Appointment reason cannot be empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public Appointment? BookAppointment(Appointment appointment)
        {
            if (!ValidateAppointment(appointment, out string errorMessage))
            {
                Console.WriteLine($"Validation failed: {errorMessage}");
                return null;
            }

            try
            {
                return _appointmentRepository.Add(appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while booking appointment: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            try
            {
                return _appointmentRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving appointments: {ex.Message}");
                return Enumerable.Empty<Appointment>();
            }
        }

        public Appointment? GetAppointment(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid appointment ID.");
                return null;
            }

            try
            {
                return _appointmentRepository.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving appointment with ID {id}: {ex.Message}");
                return null;
            }
        }

        public Appointment? UpdateAppointment(int id, Appointment appointment)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid appointment ID.");
                return null;
            }

            if (!ValidateAppointment(appointment, out string errorMessage))
            {
                Console.WriteLine($"Validation failed: {errorMessage}");
                return null;
            }

            try
            {
                return _appointmentRepository.Update(id, appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating appointment with ID {id}: {ex.Message}");
                return null;
            }
        }

        public bool CancelAppointment(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid appointment ID.");
                return false;
            }

            try
            {
                _appointmentRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while canceling appointment with ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}

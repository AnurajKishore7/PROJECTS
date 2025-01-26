using HospitalModelLibrary;
using HospitalDALLibrary;

namespace HospitalBLLLibrary
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        private bool ValidateDoctor(Doctor doctor, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(doctor.Name))
            {
                errorMessage = "Doctor name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctor.Gender))
            {
                errorMessage = "Doctor gender cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctor.Specialization))
            {
                errorMessage = "Doctor specialization cannot be empty.";
                return false;
            }

            if (doctor.Age <= 0)
            {
                errorMessage = "Doctor age must be greater than zero.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctor.Mobile) || doctor.Mobile.Length != 10)
            {
                errorMessage = "Doctor mobile number must be exactly 10 digits.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public Doctor? AddDoctor(Doctor doctor)
        {
            if (!ValidateDoctor(doctor, out string errorMessage))
            {
                Console.WriteLine($"Validation failed: {errorMessage}");
                return null;
            }

            try
            {
                return _doctorRepository.Add(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding doctor: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            try
            {
                return _doctorRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors: {ex.Message}");
                return Enumerable.Empty<Doctor>();
            }
        }

        public IEnumerable<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                Console.WriteLine("Specialization cannot be empty.");
                return Enumerable.Empty<Doctor>();
            }

            try
            {
                return _doctorRepository.GetSpecializedDoctors(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors by specialization '{specialization}': {ex.Message}");
                return Enumerable.Empty<Doctor>();
            }
        }

        public Doctor? GetDoctor(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid doctor ID.");
                return null;
            }

            try
            {
                return _doctorRepository.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctor with ID {id}: {ex.Message}");
                return null;
            }
        }

        public Doctor? UpdateDoctor(int id, Doctor doctor)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid doctor ID.");
                return null;
            }

            if (!ValidateDoctor(doctor, out string errorMessage))
            {
                Console.WriteLine($"Validation failed: {errorMessage}");
                return null;
            }

            try
            {
                return _doctorRepository.Update(id, doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating doctor with ID {id}: {ex.Message}");
                return null;
            }
        }
        public bool DeleteDoctor(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid doctor ID.");
                return false;
            }

            try
            {
                _doctorRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting doctor with ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}

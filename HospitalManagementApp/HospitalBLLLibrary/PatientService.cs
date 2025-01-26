using HospitalDALLibrary;
using HospitalModelLibrary;

namespace HospitalBLLLibrary
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _patientRepository;

        public PatientService(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        private bool ValidatePatient(Patient patient, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(patient.Name))
            {
                errorMessage = "Patient name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(patient.Gender))
            {
                errorMessage = "Patient gender cannot be empty.";
                return false;
            }

            if (patient.Age <= 0)
            {
                errorMessage = "Patient age must be greater than zero.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public Patient? AddPatient(Patient patient)
        {
            if (!ValidatePatient(patient, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
                return null;
            }

            try
            {
                return _patientRepository.Add(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding patient: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            try
            {
                return _patientRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving patients: {ex.Message}");
                return Enumerable.Empty<Patient>();
            }
        }

        public Patient? GetPatient(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid patient ID.");
                return null;
            }

            try
            {
                return _patientRepository.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving patient with ID {id}: {ex.Message}");
                return null;
            }
        }

        public bool DeletePatient(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid patient ID.");
                return false;
            }

            try
            {
                _patientRepository.Delete(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting patient with ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}

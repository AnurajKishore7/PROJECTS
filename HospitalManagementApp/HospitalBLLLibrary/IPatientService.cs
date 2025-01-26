using HospitalModelLibrary;

namespace HospitalBLLLibrary
{
    public interface IPatientService
    {
        Patient? AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatient(int id);
        bool DeletePatient(int id);
    }
}

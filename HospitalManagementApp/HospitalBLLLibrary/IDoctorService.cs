using HospitalModelLibrary;

namespace HospitalBLLLibrary
{
    public interface IDoctorService
    {
        Doctor? AddDoctor(Doctor doctor);
        IEnumerable<Doctor> GetAllDoctors();

        IEnumerable<Doctor> GetDoctorsBySpecialization(string specialization);
        Doctor? GetDoctor(int id);
        Doctor? UpdateDoctor(int id, Doctor doctor);
        bool DeleteDoctor(int id);
    }
}

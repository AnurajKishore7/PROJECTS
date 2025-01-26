using HospitalModelLibrary;

namespace HospitalDALLibrary
{
    public interface IDoctorRepository : IRepository<int, Doctor>
    {
        IEnumerable<Doctor> GetSpecializedDoctors(string specialization);
    }
}
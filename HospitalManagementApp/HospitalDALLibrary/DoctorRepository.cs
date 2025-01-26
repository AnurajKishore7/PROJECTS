using System.Data;
using HospitalModelLibrary;
using Microsoft.Data.SqlClient;

namespace HospitalDALLibrary
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly SqlConnection _connection;
        public DoctorRepository()
        {
            _connection = MyConnection.GetConnection();
        }

        public Doctor? Add(Doctor doctor)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("AddDoctor", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", doctor.Name);
                    command.Parameters.AddWithValue("@gender", doctor.Gender);
                    command.Parameters.AddWithValue("@age", doctor.Age);
                    command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@mobile", doctor.Mobile);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    return rowsAffected > 0 ? doctor : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding doctor: {ex.Message}");
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();

            try
            {
                using (SqlCommand command = new SqlCommand("GetAllDoctors", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Age = reader.GetInt32(3),
                                Specialization = reader.GetString(4),
                                Mobile = reader.GetString(5)
                            });
                        }
                    }
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return doctors;
        }

        public IEnumerable<Doctor> GetSpecializedDoctors(string specialization)
        {
            var doctors = new List<Doctor>();

            try
            {
                using (SqlCommand command = new SqlCommand("GetDoctorsBySpecialization", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@specialization", specialization);

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Age = reader.GetInt32(3),
                                Specialization = reader.GetString(4),
                                Mobile = reader.GetString(5)
                            });
                        }
                    }
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return doctors;
        }

        public Doctor? Get(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GetDoctorById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Doctor
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Age = reader.GetInt32(3),
                                Specialization = reader.GetString(4),
                                Mobile = reader.GetString(5)
                            };
                        }
                        else
                        {
                            throw new CannotFindEntityException($"Doctor with ID {id} not found.");
                        }
                    }
                }

            }
            catch (CannotFindEntityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctor with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return null;
        }

        public Doctor? Update(int id, Doctor doctor)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("UpdateDoctorById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", doctor.Name);
                    command.Parameters.AddWithValue("@gender", doctor.Gender);
                    command.Parameters.AddWithValue("@age", doctor.Age);
                    command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@mobile", doctor.Mobile);
                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    return rowsAffected > 0 ? doctor : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating doctor with ID {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DeleteDoctorById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"No doctor found with the provided Id: {id}.");
                    }
                    else
                    {
                        Console.WriteLine($"Doctor with ID {id} has been successfully deleted.");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting doctor with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}

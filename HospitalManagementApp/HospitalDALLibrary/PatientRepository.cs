using System.Data;
using HospitalModelLibrary;
using Microsoft.Data.SqlClient;

namespace HospitalDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly SqlConnection _connection;

        public PatientRepository()
        {
            _connection = MyConnection.GetConnection();
        }

        public Patient? Add(Patient patient)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("InsertPatient", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", patient.Name);
                    command.Parameters.AddWithValue("@gender", patient.Gender);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@mobile", patient.Mobile);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    return rowsAffected > 0 ? patient : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding patient: {ex.Message}");
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = new List<Patient>();

            try
            {
                using (SqlCommand command = new SqlCommand("GetAllPatients", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Age = reader.GetInt32(3),
                                Mobile = reader.GetString(4)
                            });

                        }
                    }
                    _connection.Close();

                    if (!patients.Any())
                    {
                        throw new EmptyCollectionException("No patients found.");
                    }
                }
            }
            catch (EmptyCollectionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving patients: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return patients;
        }

        public Patient? Get(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GetPatientById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Age = reader.GetInt32(3),
                                Mobile = reader.GetString(4)
                            };
                        }
                        else
                        {
                            throw new CannotFindEntityException($"Patient with ID {id} not found.");
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
                Console.WriteLine($"Error while retrieving patient with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return null;
        }

        public Patient? Update(int id, Patient patient)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("UpdatePatientById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", patient.Name);
                    command.Parameters.AddWithValue("@gender", patient.Gender);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@mobile", patient.Mobile);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new CannotFindEntityException($"Patient with ID {id} not found.");
                    }

                    return patient;
                }
            }
            catch (CannotFindEntityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating patient with ID {id}: {ex.Message}");
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
                using (SqlCommand command = new SqlCommand("DeletePatientById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new CannotFindEntityException($"Patient with ID {id} not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Patient with ID {id} has been successfully deleted.");
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
                Console.WriteLine($"Error while deleting patient with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}

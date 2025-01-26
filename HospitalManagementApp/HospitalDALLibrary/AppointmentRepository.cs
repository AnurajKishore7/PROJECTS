using System.Data;
using HospitalModelLibrary;
using Microsoft.Data.SqlClient;

namespace HospitalDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly SqlConnection _connection;

        public AppointmentRepository()
        {
            _connection = MyConnection.GetConnection();
        }

        public Appointment? Add(Appointment appointment)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("InsertAppointment", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@appointmentDateTime", appointment.AppointmentDateTime);
                    command.Parameters.AddWithValue("@appointmentReason", appointment.AppointmentReason);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    return rowsAffected > 0 ? appointment : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding appointment: {ex.Message}");
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            var appointments = new List<Appointment>();

            try
            {
                using (SqlCommand command = new SqlCommand("GetAllAppointments", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                DoctorId = reader.GetInt32(2),
                                AppointmentDateTime = reader.GetDateTime(3),
                                AppointmentReason = reader.GetString(4)
                            });
                        }
                    }
                    _connection.Close();

                    if (!appointments.Any())
                    {
                        throw new EmptyCollectionException("No appointments found.");
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
                Console.WriteLine($"Error while retrieving appointments: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return appointments;
        }

        public Appointment? Get(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GetAppointmentById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Appointment
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                DoctorId = reader.GetInt32(2),
                                AppointmentDateTime = reader.GetDateTime(3),
                                AppointmentReason = reader.GetString(4)
                            };
                        }
                        else
                        {
                            throw new CannotFindEntityException($"Appointment with ID {id} not found.");
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
                Console.WriteLine($"Error while retrieving appointment with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return null;
        }

        public Appointment? Update(int id, Appointment appointment)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("UpdateAppointmentById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@appointmentDateTime", appointment.AppointmentDateTime);
                    command.Parameters.AddWithValue("@appointmentReason", appointment.AppointmentReason);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new CannotFindEntityException($"Appointment with ID {id} not found.");
                    }

                    return appointment;
                }
            }
            catch (CannotFindEntityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating appointment with ID {id}: {ex.Message}");
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
                using (SqlCommand command = new SqlCommand("DeleteAppointmentById", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new CannotFindEntityException($"Appointment with ID {id} not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Appointment with ID {id} has been successfully deleted.");
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
                Console.WriteLine($"Error while deleting appointment with ID {id}: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}

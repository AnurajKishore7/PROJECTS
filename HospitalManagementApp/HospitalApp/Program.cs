﻿using HospitalBLLLibrary;
using HospitalDALLibrary;
using HospitalModelLibrary;

namespace HospitalManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Patient
            IRepository<int, Patient> patientRepository = new PatientRepository();
            IPatientService patientService = new PatientService(patientRepository);

            //Doctor
            IDoctorRepository doctorRepository = new DoctorRepository();
            IDoctorService doctorService = new DoctorService(doctorRepository);

            //Appointment
            // Appointment
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository();
            IAppointmentService appointmentService = new AppointmentService(appointmentRepository);



            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Hospital Management System ===");
                Console.WriteLine("1. Manage Patients");
                Console.WriteLine("2. Manage Doctors");
                Console.WriteLine("3. Manage Appointments");
                Console.WriteLine("4. Exit");

                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManagePatients(patientService);
                        break;

                    case "2":
                        ManageDoctors(doctorService);
                        break;

                    case "3":
                        ManageAppointments(appointmentService);
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ManagePatients(IPatientService patientService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Patients ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Get Patient by ID");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Back to Main Menu");

                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPatient(patientService);
                        break;

                    case "2":
                        ViewAllPatients(patientService);
                        break;

                    case "3":
                        GetPatientById(patientService);
                        break;

                    case "4":
                        DeletePatient(patientService);
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddPatient(IPatientService patientService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Add Patient ===");

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Mobile: ");
                string mobile = Console.ReadLine();

                var patient = new Patient(name, gender, age, mobile);
                var addedPatient = patientService.AddPatient(patient);

                if (addedPatient != null)
                    Console.WriteLine("Patient added successfully!");
                else
                    Console.WriteLine("Failed to add patient.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding patient: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ViewAllPatients(IPatientService patientService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== View All Patients ===");
                var patients = patientService.GetAllPatients();

                if (patients.Any())
                {
                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient.ToString());
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No patients found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving patients: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void GetPatientById(IPatientService patientService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Get Patient by ID ===");

                Console.Write("Enter Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var patient = patientService.GetPatient(id);

                if (patient != null)
                    Console.WriteLine(patient.ToString());
                else
                    Console.WriteLine("No patient found with the provided ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving patient: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DeletePatient(IPatientService patientService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Delete Patient ===");

                Console.Write("Enter Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var success = patientService.DeletePatient(id);

                if (success)
                    Console.WriteLine("Patient deleted successfully!");
                else
                    Console.WriteLine("Failed to delete patient.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting patient: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManageDoctors(IDoctorService doctorService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Doctors ===");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Get Doctor by ID");
                Console.WriteLine("4. Get Doctors by Specialization");
                Console.WriteLine("5. Delete Doctor");
                Console.WriteLine("6. Back to Main Menu");

                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDoctor(doctorService);
                        break;

                    case "2":
                        ViewAllDoctors(doctorService);
                        break;

                    case "3":
                        GetDoctorById(doctorService);
                        break;

                    case "4":
                        GetDoctorsBySpecialization(doctorService);
                        break;

                    case "5":
                        DeleteDoctor(doctorService);
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddDoctor(IDoctorService doctorService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Add Doctor ===");

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Specialization: ");
                string specialization = Console.ReadLine();

                Console.Write("Enter Mobile: ");
                string mobile = Console.ReadLine();

                var doctor = new Doctor(name, gender, age, specialization, mobile);
                var addedDoctor = doctorService.AddDoctor(doctor);

                if (addedDoctor != null)
                    Console.WriteLine("Doctor added successfully!");
                else
                    Console.WriteLine("Failed to add doctor.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding doctor: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ViewAllDoctors(IDoctorService doctorService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== View All Doctors ===");
                var doctors = doctorService.GetAllDoctors();

                if (doctors.Any())
                {
                    foreach (var doctor in doctors)
                    {
                        Console.WriteLine(doctor.ToString());
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No doctors found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void GetDoctorById(IDoctorService doctorService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Get Doctor by ID ===");

                Console.Write("Enter Doctor ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var doctor = doctorService.GetDoctor(id);

                if (doctor != null)
                    Console.WriteLine(doctor.ToString());
                else
                    Console.WriteLine("No doctor found with the provided ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctor: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DeleteDoctor(IDoctorService doctorService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Delete Doctor ===");

                Console.Write("Enter Doctor ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var success = doctorService.DeleteDoctor(id);

                if (success)
                    Console.WriteLine("Doctor deleted successfully!");
                else
                    Console.WriteLine("Failed to delete doctor.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting doctor: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void GetDoctorsBySpecialization(IDoctorService doctorService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Get Doctors by Specialization ===");

                Console.Write("Enter Specialization: ");
                string specialization = Console.ReadLine();

                var doctors = doctorService.GetDoctorsBySpecialization(specialization);

                if (doctors.Any())
                {
                    foreach (var doctor in doctors)
                    {
                        Console.WriteLine(doctor.ToString());
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No doctors found for the given specialization.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving doctors by specialization: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManageAppointments(IAppointmentService appointmentService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Appointments ===");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. Get Appointment by ID");
                Console.WriteLine("4. Delete Appointment");
                Console.WriteLine("5. Back to Main Menu");

                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAppointment(appointmentService);
                        break;

                    case "2":
                        ViewAllAppointments(appointmentService);
                        break;

                    case "3":
                        GetAppointmentById(appointmentService);
                        break;

                    case "4":
                        DeleteAppointment(appointmentService);
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddAppointment(IAppointmentService appointmentService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Add Appointment ===");

                Console.Write("Enter Patient ID: ");
                int patientId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Doctor ID: ");
                int doctorId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Appointment Date and Time (yyyy-MM-dd HH:mm): ");
                DateTime appointmentDateTime = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Appointment Reason: ");
                string appointmentReason = Console.ReadLine();

                var appointment = new Appointment(patientId, doctorId, appointmentDateTime, appointmentReason);
                var addedAppointment = appointmentService.BookAppointment(appointment);

                if (addedAppointment != null)
                    Console.WriteLine("Appointment added successfully!");
                else
                    Console.WriteLine("Failed to add appointment.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding appointment: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ViewAllAppointments(IAppointmentService appointmentService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== View All Appointments ===");
                var appointments = appointmentService.GetAllAppointments();

                if (appointments.Any())
                {
                    foreach (Appointment appointment in appointments)
                    {
                        Console.WriteLine(appointment.ToString());
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No appointments found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving appointments: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void GetAppointmentById(IAppointmentService appointmentService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Get Appointment by ID ===");

                Console.Write("Enter Appointment ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var appointment = appointmentService.GetAppointment(id);

                if (appointment != null)
                    Console.WriteLine(appointment.ToString());
                else
                    Console.WriteLine("No appointment found with the provided ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving appointment: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DeleteAppointment(IAppointmentService appointmentService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Delete Appointment ===");

                Console.Write("Enter Appointment ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                bool success = appointmentService.CancelAppointment(id);

                if (success)
                    Console.WriteLine("Appointment deleted successfully!");
                else
                    Console.WriteLine("Failed to delete appointment.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting appointment: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }


    }
}

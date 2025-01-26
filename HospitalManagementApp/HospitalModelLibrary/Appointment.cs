namespace HospitalModelLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string AppointmentReason { get; set; } = string.Empty;

        public Appointment() { }

        public Appointment(int patientId, int doctorId, DateTime appointmentDateTime, string appointmentReason)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDateTime = appointmentDateTime;
            AppointmentReason = appointmentReason;
        }
        public Appointment(int id, int patientId, int doctorId, DateTime appointmentDateTime, string appointmentReason) : this(patientId, doctorId, appointmentDateTime, appointmentReason)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nPatientId: {PatientId}\nDoctorId: {DoctorId}\nAppointment Date and Time: {AppointmentDateTime}\nAppointment Reason: {AppointmentReason}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Appointment))
                return false;
            Appointment other = (Appointment)obj;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}




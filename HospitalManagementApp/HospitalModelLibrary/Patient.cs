namespace HospitalModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Mobile { get; set; } = string.Empty;

        public Patient() { }

        public Patient(string name, string gender, int age, string mobile)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Mobile = mobile;
        }

        public Patient(int id, string name, string gender, int age, string mobile) : this(name, gender, age, mobile)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nGender: {Gender}\nAge: {Age}\nMobile: {Mobile}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Patient))
                return false;

            Patient other = (Patient)obj;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
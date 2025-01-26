namespace HospitalModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

        public Doctor() { }

        public Doctor(string name, string gender, int age, string specialization, string mobile)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Specialization = specialization;
            Mobile = mobile;
        }

        public Doctor(int id, string name, string gender, int age, string specialization, string mobile) : this(name, gender, age, specialization, mobile)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nGender: {Gender}\nAge: {Age}\nSpecialization: {Specialization}\nMobile: {Mobile}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Doctor))
                return false;
            Doctor other = (Doctor)obj;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}